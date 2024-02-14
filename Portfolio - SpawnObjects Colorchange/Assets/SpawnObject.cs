using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public float lifespan = 2;
    public float startScale = 1;

    bool touchedFloor = false;

    public Material floormat;

    float timer;

    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        timer = lifespan;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        transform.localScale = Vector3.one * (startScale * timer / lifespan);

        if (timer <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!touchedFloor && collision.gameObject.tag == "Floor")
        {
            if(floormat != null)
            {
                rend.material = floormat;
            }
            else
            {
                rend.material.SetColor("_Color", Color.green);
            }
        }
    }
}
