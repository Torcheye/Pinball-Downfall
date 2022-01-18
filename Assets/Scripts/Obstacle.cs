using DG.Tweening;
using UnityEngine;

public class Obstacle : Scroller
{
    private async void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ObstacleEdge"))
        {
            Destroy(gameObject);
        }
        
        if (col.gameObject.CompareTag("Ball"))
        {
            AudioManager.Instance.Play(2);
            GameManager.Instance.Score += GetComponent<Placable>().score;

            GetComponent<Collider2D>().enabled = false;
            var tween = transform.DOPunchScale(transform.localScale * .3f, .4f);
            await tween.AsyncWaitForCompletion();
            GetComponent<Collider2D>().enabled = true;
        }
    }
}