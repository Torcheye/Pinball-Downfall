using System;
using UnityEngine;

public class Coin : Scroller
{
    public int money;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball"))
        {
            GameManager.Instance.Money += money;
            Destroy(gameObject);
        }
    }
}