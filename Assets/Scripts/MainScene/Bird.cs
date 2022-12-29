using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    [SerializeField]
    private float velocity = 2.5f;
    private Rigidbody2D rb;
    
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex = 0;

    public GameManager gameManager;

    public GameObject[] BirdItems;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = (float)Math.Sqrt(Input.touchCount) * velocity * Vector2.up;
        }

        if (Time.timeScale != 0)
        {
            var yVelocity = rb.velocity.y;
            rb.transform.eulerAngles = Math.Abs(yVelocity) < 18 ? new Vector3(0, 0, yVelocity * 5) : new Vector3(0, 0, Math.Sign(yVelocity) * 90);
        }
        
        var gyro = Input.gyro.gravity.normalized;
        spriteRenderer.color = new Color(1-Math.Abs(gyro.x), 1-Math.Abs(gyro.y), 1-Math.Abs(gyro.z));
    }

    public void SetUpBirdItems(BirdItemData[] birdItemData)
    {
        foreach (var itemData in birdItemData)
        {
            var go = getBirdItem(itemData.Name);
            if (go == null) continue;
            Debug.Log("penis");
            go.SetActive(itemData.Enabled);
        }
    }

    private GameObject getBirdItem(string name)
    {
        foreach (var birdItem in BirdItems)
        {
            if (birdItem.name == name) return birdItem;
        }
        Debug.Log("penis");
        return null;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        gameManager.GameOver();
    }
    
    private void AnimateSprite()
    {
        spriteIndex = (spriteIndex + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
