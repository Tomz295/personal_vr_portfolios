using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Material vacuumingMat;
    public Material vacuumableMat;

    public float spawnTimer = 2;
    public float startScale = 1;

    public GameObject playerObj = null;

    float startTimer;

    Renderer rend;
    Rigidbody rb;
    bool vacuumable = false;
    bool forcevacuum = false;
    bool vacuuming = false;
    float vacuumDist = 10;

    public float diffdist;

    // Start is called before the first frame update
    void Start()
    {
        startTimer = spawnTimer;
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        transform.localScale = Vector3.one * ( (startScale * spawnTimer + 0.001f) / startTimer);

        if (spawnTimer <= 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space) & playerObj != null & vacuumable)
        {
            forcevacuum = true;
        }

    }

    private void FixedUpdate()
    {
        if (playerObj != null)
        {
            diffdist = Vector3.Distance(playerObj.transform.position, transform.position);

            if (forcevacuum || (vacuumable && diffdist < vacuumDist))
            {
                if (!vacuuming)
                {
                    vacuuming = true;
                    rend.material = vacuumingMat;
                }
                float vaccumModifier = 0.5f;
                rb.velocity += (playerObj.transform.position - transform.position).normalized * Mathf.Max(vaccumModifier, (vacuumDist * vaccumModifier) / diffdist);
            }
            else if (vacuuming)
            {
                vacuuming = false;
                rend.material = vacuumableMat;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!vacuumable && collision.gameObject.tag == "Floor")
        {
            if(vacuumableMat != null)
            {
                rend.material = vacuumableMat;
            }
            else
            {
                rend.material.SetColor("_Color", Color.green);
            }
            vacuumable = true;
        }
    }
}
