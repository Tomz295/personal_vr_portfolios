using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectSpawner : MonoBehaviour
{

    [SerializeField]
    SpawnObject spawnObjectPrefab;
    [SerializeField]
    Material vacuumableMat;
    [SerializeField]
    Material vacuumingMat;
    float colorHSV = 0;
    [SerializeField]
    float colorSpeed = 1;

    [SerializeField]
    float spawnTimer = 2;
    [SerializeField]
    float startScale = 5;
    [SerializeField]
    float spawnVelocity = 5;

    [SerializeField]
    float spawnFrecuency = 1;
    float timer;

    [SerializeField]
    GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnFrecuency)
        {
            timer = 0;
            SpawnObject spawnObject = GameObject.Instantiate(spawnObjectPrefab);
            spawnObject.transform.position = transform.position;
            spawnObject.spawnTimer = spawnTimer;
            spawnObject.startScale = startScale;
            spawnObject.playerObj = playerObj;
            spawnObject.vacuumingMat = vacuumingMat;
            spawnObject.vacuumableMat = vacuumableMat;

            Rigidbody spawnObjectRb = spawnObject.GetComponent<Rigidbody>();
            spawnObjectRb.velocity = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * spawnVelocity;

        }

        colorHSV += Time.deltaTime * colorSpeed;
        if(colorHSV > 1)
        {
            colorHSV = 0f;
        }
        vacuumingMat.color = Color.HSVToRGB(colorHSV, 1, 1);
    }
}
