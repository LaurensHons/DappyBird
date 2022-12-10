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
    
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex = 0;

    public GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * velocity;
        }

        if (Time.timeScale != 0)
        {
            var yVelocity = rb.velocity.y;
            rb.transform.eulerAngles = new Vector3(0, 0, yVelocity * 5);
        }
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
