using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawnManager : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    GameObject missilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(missilePrefab != null && Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;
            Ray r = mainCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if( Physics.Raycast(r, out hit))
            {
                if (hit.collider.tag == "Floor")
                {
                    var missile = GameObject.Instantiate(missilePrefab);
                    missile.transform.position = hit.point;
                }
            }
        }
    }
}
