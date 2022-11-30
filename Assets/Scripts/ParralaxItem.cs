using UnityEngine;

namespace DefaultNamespace
{
    public class ParralaxItem : MonoBehaviour
    {
        private MeshRenderer meshRenderer;
        public static float parallaxSpeed = 0.5f;
        public float multiplier = 1;
    
        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            meshRenderer.material.mainTextureOffset += new Vector2(parallaxSpeed * Time.deltaTime * multiplier, 0);
        }
    }
}