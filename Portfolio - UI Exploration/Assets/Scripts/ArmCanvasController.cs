using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class ArmCanvasController : MonoBehaviour
{

    [SerializeField] CanvasGroup armCanvas;
    [SerializeField] Camera rigHead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 handPos = rigHead.transform.InverseTransformPoint(transform.position);
        float xdif = handPos.x;

        if (xdif > -0.2)
        {
            if (xdif > 0f)
            {
                armCanvas.alpha = 1;
            }
            armCanvas.alpha = (xdif-0.07f)/(0.14f-0.07f);
        }
        else
        {
            armCanvas.alpha = 0;
        }
    }
}
