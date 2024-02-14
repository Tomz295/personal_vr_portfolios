using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelUtils.VRInteraction;

public class VRCustomThrowable : VRMoveable
{

    [SerializeField] GameObject pearl1;
    [SerializeField] GameObject pearl2;
    [SerializeField] AudioSource audiosrc;
    [SerializeField] AudioSource audiosrcDing;

    [SerializeField] float gravityFactor = 9.8f;
    [SerializeField] float maxSpeed = 10f;
    public bool isThrowing = false;
    public bool wasThrown = false;
    bool breakAndTeleport = false;
    Rigidbody rigb;
    LineRenderer lineRenderer;

    public GameObject Rig;
    public override void HandleGrab(VRGrabbableHand h)
    {
        base.HandleGrab(h);
        removeDrags();
    }

    public override void HandleRelease(VRGrabbableHand h = null)
    {
        base.HandleRelease(h);
        isThrowing = true;
        wasThrown = true;
        audiosrc.Play();
        lineRenderer.SetPosition(0, transform.position);
    }

    void removeDrags()
    {
        rigb.drag = 0;
        rigb.angularDrag = 0f;
    }

    void addLinePoint()
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);
    }


    // Start is called before the first frame update
    void Start()
    {
        rigb = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
    }


    float timer = 0;
    float speed = 1;
    float accel = 4f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (isThrowing && timer >= 0.25f)
        {
            addLinePoint();
        }

        if (breakAndTeleport)
        {
            if(speed >= maxSpeed) 
            {
                speed = maxSpeed;
            }
            else
            {
                speed += accel * Time.deltaTime;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isThrowing)
        {
            rigb.velocity += Vector3.down * Time.fixedDeltaTime * gravityFactor;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isThrowing)
        {
            breakAndTeleport = true;
            isThrowing = false;
            rigb.velocity = Vector3.zero;
            rigb.angularVelocity = Vector3.zero;
            rigb.drag = 10;
            rigb.angularDrag = 10;
            StartCoroutine(teleportRig());
        }
    }

    IEnumerator teleportRig()
    {
        GameObject.Destroy(pearl1);
        GameObject.Destroy(pearl2);
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 target = lineRenderer.GetPosition(i);
            while(Vector3.Distance(Rig.transform.position, target) > 0.1f)
            {
                Rig.transform.position = Vector3.MoveTowards(Rig.transform.position, target, speed * Time.deltaTime);
                yield return null;
            }
        }
        audiosrcDing.Play();
        GameObject.Destroy(gameObject);
        yield break;
    }
}
