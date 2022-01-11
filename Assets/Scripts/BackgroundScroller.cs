using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.IsScrolling)
            transform.Translate(Vector3.up * GameManager.Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Finish"))
        {
            transform.position = GameManager.Instance.reposition.position;
        }
    }
}
