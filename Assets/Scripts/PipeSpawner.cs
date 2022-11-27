using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float InitalMaxTime = 3;
    [SerializeField]
    private float maxTime; 
    public float timer = 0;
    
    public float InitialPipeSpeed = 2;
    [SerializeField]
    private float pipeSpeed;
    public float pipeSpeedMultiplier = 0.01f;
    
    public GameObject pipePrefab;

    public float height = 2;

    public List<GameObject> _pipes_not_passed = new List<GameObject>();
    public ScoreManager ScoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        pipeSpeed = InitialPipeSpeed;
        maxTime = InitalMaxTime;
        instantiatePipe();
    }

    // Update is called once per frame
    void Update()
    {
        pipeSpeed += pipeSpeedMultiplier * Time.deltaTime;
        maxTime = InitalMaxTime / (pipeSpeed / 2);
        
        if (timer > maxTime)
        {
            instantiatePipe();
            timer = 0;
        }

        timer += Time.deltaTime;

        for (int i = _pipes_not_passed.Count - 1; i >= 0 ; i--)
        {
            var pipe = _pipes_not_passed[i];
            if (pipe.transform.position.x < 0)
            {
                ScoreManager.Score += 1;
                _pipes_not_passed.RemoveAt(i);
            }
        }
        
        
    }

    private void instantiatePipe()
    {
        GameObject newpipe = Instantiate(pipePrefab);
        newpipe.transform.position = transform.position + new Vector3(5, Random.Range(-height, height), 0);
        foreach (var pipe in newpipe.GetComponentsInChildren<BackGroundItem>())
        {
            pipe.speed = pipeSpeed;
        }
        _pipes_not_passed.Add(newpipe);
        Destroy(newpipe, 10);
        
    }
}
