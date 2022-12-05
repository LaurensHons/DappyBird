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
    private float maxRotation = 0.2f;
    
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
            var zRotation = transform.rotation.z;
            var yVelocity = rb.velocity.y;

            if ((yVelocity < 0 && zRotation > -maxRotation) || (yVelocity > 0 && zRotation < maxRotation))
            {
                transform.Rotate(new Vector3(0, 0, yVelocity / 4));
            }
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
