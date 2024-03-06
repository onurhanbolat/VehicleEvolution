using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    MeshRenderer cubeMeshRenderer;

    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] myColors;

    int colorIndex = 0,len;

    float t = 0f;

    void Start()
    {
        cubeMeshRenderer = GetComponent<MeshRenderer>();
        len = myColors.Length;
    }
    void Update()
    {
        cubeMeshRenderer.material.color = Color.Lerp(cubeMeshRenderer.material.color, myColors[colorIndex], lerpTime * Time.fixedDeltaTime);
        t = Mathf.Lerp(t, 1f, lerpTime * Time.fixedDeltaTime);
        if (t > .9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }


    }
}
