using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
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
        instantiatePipe(5);
        instantiatePipe(10);
    }

    // Update is called once per frame
    void Update()
    {
        pipeSpeed += pipeSpeedMultiplier * Time.deltaTime;
        BackGroundItem.speed = pipeSpeed;
        ParralaxItem.parallaxSpeed = pipeSpeed;
        maxTime = InitalMaxTime / (pipeSpeed / 2);
        
        if (timer > maxTime)
        {
            instantiatePipe(10);
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

    private void instantiatePipe(int x)
    {
        GameObject newpipe = Instantiate(pipePrefab);
        newpipe.transform.position = transform.position + new Vector3(x, Random.Range(-height, height), 0);
        _pipes_not_passed.Add(newpipe);
        Destroy(newpipe, 10);
        
    }
}
