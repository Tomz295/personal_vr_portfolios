using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelUtils;

public class SpawnPearl : MonoBehaviour
{
    public GameObject pearlPrefab;
    public GameObject Rig;

    GameObject pearl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputMan.GetDown(VRInput.Grip))
        {
            if (pearl == null)
            {
                pearl = GameObject.Instantiate(pearlPrefab);
                pearl.GetComponent<VRCustomThrowable>().Rig = Rig;
            } else if(pearl.GetComponent<VRCustomThrowable>().wasThrown)
            {
                return;
            }
            pearl.transform.position = transform.position + (transform.rotation * Vector3.forward) * 0.5f;
            pearl.transform.rotation = transform.rotation;
        }
    }
}
