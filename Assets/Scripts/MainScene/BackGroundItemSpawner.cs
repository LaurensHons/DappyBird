using UnityEngine;

namespace DefaultNamespace
{
    public class BackGroundItemSpawner  : MonoBehaviour
    {
        public GameObject prefabs;
        public float spawnTime = 1f;
        public float minHeight = -1f;
        public float maxHeight = 1f;

        private void OnEnable()
        {
            InvokeRepeating(nameof(Spawn), spawnTime, spawnTime);
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(Spawn));
        }

        private void Spawn()
        {
            GameObject pipes = Instantiate(prefabs, transform.position, Quaternion.identity);
            pipes.transform.position = new Vector3(pipes.transform.position.x, Random.Range(minHeight, maxHeight), pipes.transform.position.z);
        }
    }
}