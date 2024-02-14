using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelUtils.VRInteraction;

public class ColorDice : VRMoveable
{
    bool isBeingGrabbed = false;
    bool isThrown = false;
    Rigidbody rigb;

    [Header("Dice Settings")]
    [SerializeField] GameObject[] diceFaces;

    Color[] colorarray = { Color.white, Color.white, Color.black, Color.green, Color.red, Color.blue };

    [Header("VRDrawController Reference")]
    [SerializeField] VRDrawController drawController;


    public override void HandleGrab(VRGrabbableHand h)
    {
        base.HandleGrab(h);
        isBeingGrabbed = true;
        isThrown = false;
    }

    public override void HandleRelease(VRGrabbableHand h = null)
    {
        base.HandleRelease(h);
        isBeingGrabbed = false;
        isThrown = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        rigb = GetComponent<Rigidbody>();
    }

    void chooseColor()
    {
        for (int i = 1; i < 6; i++)
        {
            if (diceFaces[i].transform.position.y > transform.position.y + 0.02f)
            {
                drawController.setLineColor(colorarray[i]);
                return;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!isBeingGrabbed && isThrown) 
        {
            if (rigb.velocity.magnitude == 0)
            {
                isThrown = false;
                chooseColor();
            }
        }
    }
}
