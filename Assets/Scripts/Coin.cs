using System;
using UnityEngine;

public class Coin : Scroller
{
    public int money;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball"))
        {
            AudioManager.Instance.Play(9);
            GameManager.Instance.Money += money;
            Destroy(gameObject);
        }
    }
}