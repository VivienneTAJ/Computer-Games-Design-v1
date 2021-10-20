using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTexture : MonoBehaviour
{
    public GameObject go;
    private Renderer rend;

    void Start()
    {
        rend = go.GetComponentInChildren<MeshRenderer>();
    }

    void Update()
    {
        // Animates main texture scale in a funky way!
        float scaleX = 1f;
        float scaleY = 1f;
        rend.material.mainTextureScale = new Vector2(scaleX, scaleY);
    }
}
