using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundItem : MonoBehaviour
{
    [SerializeField]
    public static float speed;
    public static float multiplier = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime * multiplier;
    }
}
