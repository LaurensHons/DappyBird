using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float parallaxSpeed = 0.5f;
    
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(parallaxSpeed * Time.deltaTime, 0);
    }
}