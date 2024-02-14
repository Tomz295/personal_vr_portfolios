using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObject : MonoBehaviour
{


    float colorHSV = 1;
    float transparency = 1;
    float explosionScale = 0.1f;

    public float explosionDuration = 2f;
    public float maxScale = 1f;

    float timer = 0f;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        colorHSV = (50f/360f) * (timer / explosionDuration);
        transparency = 1 - (timer / explosionDuration);
        explosionScale = maxScale * (timer / explosionDuration);

        Color newcolor = Color.HSVToRGB(colorHSV, 1, 1);
        newcolor.a = transparency;
        rend.material.SetColor("_Color", newcolor);

        transform.localScale = Vector3.one * explosionScale;

        if (timer > explosionDuration)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}

