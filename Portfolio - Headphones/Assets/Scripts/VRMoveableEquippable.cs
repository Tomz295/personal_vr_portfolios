using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelUtils.VRInteraction;

public class VRMoveableEquippable : VRMoveable
{

    [Header("Equippable Settings")]
    bool isBeingGrabbed = false;
    GameObject region;
    bool equiped = false;

    public Vector3 EquippedOffset;

    private void Update()
    {
        if(region == null)
        {
            equiped = false;
        }

        if (equiped)
        {
            transform.position = region.transform.position;
            transform.rotation = region.transform.rotation;
            transform.position += transform.rotation * EquippedOffset;
        }
    }

    public override void HandleGrab(VRGrabbableHand h)
    {
        breakEquip();
        base.HandleGrab(h);
        isBeingGrabbed = true;
    }

    public override void HandleRelease(VRGrabbableHand h = null)
    {
        base.HandleRelease(h);
        attemptEquip();
        isBeingGrabbed = false;
    }

    public void setEquipRegion(GameObject newEquipRegion)
    {
        if (isBeingGrabbed)
        {
            if (region == null)
            {
                region = newEquipRegion;
            }
            else
            {
                float distance = Vector3.Distance(region.transform.position, transform.position);
                float newdistance = Vector3.Distance(newEquipRegion.transform.position, transform.position);
                if (newdistance < distance)
                {
                    region = newEquipRegion;
                }
            }
        }
    }

    public void removeEquipRegion(GameObject equipRegion)
    {
        if (region == equipRegion)
        {
            region = null;
        }
    }

    public void attemptEquip()
    {
        if (region != null)
        {
            equiped = true;
        }
    }

    public void breakEquip()
    {
        equiped = false;
    }
}
