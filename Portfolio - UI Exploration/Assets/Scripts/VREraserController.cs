using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelUtils;

public class VREraserController : MonoBehaviour
{
    [Header("VR Settings")]
    public Side side;
    [Tooltip("What to press to spawn objects")]
    public VRInput DrawInput = VRInput.Trigger;

    [Header("Eraser Settings")]
    [SerializeField] GameObject EraserBody;
    [SerializeField] Material OnUseMaterial;
    Material startMaterial;
    Renderer eraserRend;


    // Start is called before the first frame update
    void Start()
    {
        eraserRend = EraserBody.GetComponent<Renderer>();
        startMaterial = eraserRend.material;
    }

    // Update is called once per frame
    void Update()
    {
        eraserRend.material = InputMan.Get(DrawInput, side) ? OnUseMaterial : startMaterial;
    }

    private void OnTriggerStay(Collider other)
    {
        if(InputMan.Get(DrawInput, side))
        {
            if(other.gameObject.tag == "Line")
            {
                Destroy(other.gameObject);
            }
        }
    }
}
