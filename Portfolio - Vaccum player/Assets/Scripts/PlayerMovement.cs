using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    public int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        int Akey = Input.GetKey(KeyCode.A) ? 1 : 0;
        int Dkey = Input.GetKey(KeyCode.D) ? 1 : 0;
        int Wkey = Input.GetKey(KeyCode.W) ? 1 : 0;
        int Skey = Input.GetKey(KeyCode.S) ? 1 : 0;

        rb.AddForce(new Vector3((Skey - Wkey) * speed, 0, (Dkey - Akey) * speed));
    }
}
