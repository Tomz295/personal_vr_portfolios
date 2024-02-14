using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using VelUtils;
using static VelUtils.Movement;

public class HandSpawner : MonoBehaviour
{
    [Header("VR Settings")]
    public Rig rig;
    public Side side;

    [Tooltip("What to press to spawn objects")]
    public VRInput ShootInput = VRInput.Trigger;

    [SerializeField]
    GameObject shootPoint;

    [Header("Spawnobject Settings")]
    [SerializeField]
    VRSpawnObject spawnObjectPrefab;
    [SerializeField]
    float spawnTimer = 2; 
    [SerializeField]
    float startScale = 2;
    [SerializeField]
    [Tooltip("Spawn an object every X seconds")]
    float spawnFrecuency = 1;
    [SerializeField]
    float shootForceFactor = 1f;

    float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputMan.Get(ShootInput, side))
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                spawnTheObject();
                timer = spawnFrecuency;
            }
        } else
        {
            timer = 0;
        }
    }

    void spawnTheObject()
    {
        Vector3 startPos = shootPoint.transform.position + (transform.forward * startScale * 0.5f);
        VRSpawnObject spawnObject = GameObject.Instantiate(spawnObjectPrefab, startPos, transform.rotation);
        //spawnObject.transform.position = shootPoint.transform.position + (transform.forward * startScale * 0.5f);
        spawnObject.spawnTimer = spawnTimer;
        spawnObject.startScale = startScale;
        spawnObject.transform.GetComponent<Rigidbody>().AddForce(transform.forward * shootForceFactor, ForceMode.VelocityChange);
    }
}
