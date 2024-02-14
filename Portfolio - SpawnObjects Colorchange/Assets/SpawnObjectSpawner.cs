using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectSpawner : MonoBehaviour
{

    [SerializeField]
    SpawnObject spawnObjectPrefab;
    [SerializeField]
    Material touchedFloorMat;

    [SerializeField]
    float objectLifespan = 2;
    [SerializeField]
    float startScale = 5;
    [SerializeField]
    float spawnVelocity = 5;

    [SerializeField]
    float spawnDelay = 1;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnDelay)
        {
            timer = 0;
            SpawnObject spawnObject = GameObject.Instantiate(spawnObjectPrefab);
            spawnObject.transform.position = transform.position;
            spawnObject.lifespan = objectLifespan;
            spawnObject.startScale = startScale;
            spawnObject.floormat = touchedFloorMat;

            Rigidbody spawnObjectRb = spawnObject.GetComponent<Rigidbody>();
            spawnObjectRb.velocity = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * spawnVelocity;

        }
    }
}
