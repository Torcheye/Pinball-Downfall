using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeder : Scroller
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ObstacleEdge"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ball"))
        {
            col.attachedRigidbody.AddForce(Vector2.up * 1500 * Time.deltaTime);
        }
    }
}