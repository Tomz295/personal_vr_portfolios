using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipRegion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        // check if other is VRMoveableEquippable
        VRMoveableEquippable equippable = other.GetComponent<VRMoveableEquippable>();
        if (equippable != null)
        {
            equippable.setEquipRegion(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        VRMoveableEquippable equippable = other.GetComponent<VRMoveableEquippable>();
        if (equippable != null)
        {
            equippable.removeEquipRegion(gameObject);
        }
    }
}
