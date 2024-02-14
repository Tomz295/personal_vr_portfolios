using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketPaintScript : MonoBehaviour
{

    [SerializeField] Color color;
    [SerializeField] bool useMaterialColor = false;

    // Start is called before the first frame update
    void Start()
    {
        if (useMaterialColor)
        {
            color = GetComponent<Renderer>().material.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        if (other.gameObject.tag.Equals("Pencil"))
        {
            VRDrawController controler = other.GetComponent<VRDrawController>();
            if (controler != null)
            {
                controler.setLineColor(color);
            }
        }
    }
}
