using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;

    public float traveltime = 0.5f;
    float timer;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(Random.Range(-1f, 1f) * 10, 25, Random.Range(-1f, 1f) * 10);
        transform.LookAt(explosion.transform.position);
        startPos = transform.position;

        timer = traveltime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        transform.position = Vector3.Lerp(startPos, explosion.transform.position, 1 - (timer / traveltime));

        if (timer < 0)
        {
            explosion.SetActive(true);
            Destroy(gameObject);
        }
    }
}
