using System;
using DG.Tweening;
using UnityEngine;

public class Obstacle : Scroller
{
    public int value;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ObstacleEdge"))
        {
            Destroy(gameObject);
        }
    }

    private async void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.money += value;

            GetComponent<Collider2D>().enabled = false;
            var tween = transform.DOPunchScale(transform.localScale * .3f, .4f);
            await tween.AsyncWaitForCompletion();
            GetComponent<Collider2D>().enabled = true;
        }
    }
}