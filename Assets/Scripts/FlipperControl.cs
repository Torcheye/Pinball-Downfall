using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperControl : MonoBehaviour
{
    public float maxVel;
    private Rigidbody2D _rbody;

    private void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.Instance.gameState != 1)
            return;
        
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.Instance.Play(0);
            _rbody.AddTorque(1000, ForceMode2D.Impulse);
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            AudioManager.Instance.Play(0);
            _rbody.AddTorque(-1000, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (_rbody.angularVelocity > maxVel)
            _rbody.angularVelocity = maxVel;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            AudioManager.Instance.Play(1);
        }
    }
}