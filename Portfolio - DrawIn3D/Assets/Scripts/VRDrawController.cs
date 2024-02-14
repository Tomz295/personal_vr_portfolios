using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelUtils;

public class VRDrawController : MonoBehaviour
{

    [Header("VR Settings")]
    public Side side;
    [Tooltip("What to press to spawn objects")]
    public VRInput DrawInput = VRInput.Trigger;

    [Header("Draw Settings")]
    [SerializeField] LineDrawer lineDrawerObject;
    [SerializeField] Color lineColor = Color.white;
    [SerializeField] float lineWidth = 0.02f;
    [SerializeField] float segmentLength = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setLineColor(Color color)
    {
        lineColor = color;
    }

    // Update is called once per frame
    void Update()
    {
        if(lineDrawerObject != null)
        {
            if(InputMan.GetDown(DrawInput, side))
            {
                lineDrawerObject.startDrawing(segmentLength, lineWidth, lineColor);
            }

            if(InputMan.GetUp(DrawInput, side))
            {
                lineDrawerObject.stopDrawing();
            }
        }
    }
}
