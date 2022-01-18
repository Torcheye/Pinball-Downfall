using System;
using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Sprite[] sprites;
    public float maxVel;
    public bool title;
    
    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;
    private Vector2 _tempVel;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        
        if (title)
        {
            _rigidbody.AddForce(new Vector2(300, 450));
            _rigidbody.AddTorque(1);
        }
    }

    private void Update()
    {
        if (title) 
            return;
        
        if (GameManager.Instance.gameState == 3 && _rigidbody.velocity != Vector2.zero)
        {
            _tempVel = _rigidbody.velocity;
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = Vector2.zero;
        }
        if (GameManager.Instance.gameState == 1 && _rigidbody.velocity == Vector2.zero)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = _tempVel;
        }
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.magnitude > maxVel)
            _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, maxVel);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        StartCoroutine(SwapSprite());
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("BallBound"))
        {
            GameManager.Instance.BallOutOfBound();
        }
    }

    private IEnumerator SwapSprite()
    {
        _renderer.sprite = sprites[1];
        yield return new WaitForSeconds(.5f);
        _renderer.sprite = sprites[0];
    }
}