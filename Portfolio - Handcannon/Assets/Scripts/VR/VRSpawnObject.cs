using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSpawnObject : MonoBehaviour
{
    public float spawnTimer = 2;
    public float startScale = 1;
    float startTimer;

    [SerializeField]
    Mesh newmesh;

    Renderer rend;
    Rigidbody rb;

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
    }

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
        
        transform.localScale = Vector3.one * ((startScale * spawnTimer + 0.001f) / startTimer);
        if (spawnTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            //change gameobject mesh to cube
            GetComponent<MeshFilter>().mesh = newmesh;

        }
    }
}
