using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Sprite[] sprites;
    public float maxVel;
    public bool title;
    
    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;

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