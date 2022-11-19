using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    public float maxTime = 10;
    private float timer = 0;
    public GameObject pipePrefab;
    public float height = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        instantiatePipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            instantiatePipe();
            timer = 0;
            Destroy(this, 15);
        }

        timer += Time.deltaTime;
    }

    private void instantiatePipe()
    {
        GameObject newpipe = Instantiate(pipePrefab);
        newpipe.transform.position = transform.position + new Vector3(5, Random.Range(-height, height), 0);
    }
}
