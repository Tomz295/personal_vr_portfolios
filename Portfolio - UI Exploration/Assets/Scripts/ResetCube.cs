using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCube : MonoBehaviour
{

    Vector3 startpos;
    Quaternion startrot;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        startrot = transform.rotation;
    }

    public void Reset()
    {
        transform.position = startpos;
        transform.rotation = startrot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
