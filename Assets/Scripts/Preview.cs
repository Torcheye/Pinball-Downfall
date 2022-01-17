using UnityEngine;

public class Preview : MonoBehaviour
{
    private SpriteRenderer _renderer;
    public int placementHittingCount;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (placementHittingCount > 0)
        {
            _renderer.color = new Color(1, .4f, .4f, .4f);
        }
        else
        {
            _renderer.color = new Color(0.4f, 1f, 0.4f, 0.4f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("obstacle") || other.CompareTag("Speeder") || other.CompareTag("BallBound"))
        {
            placementHittingCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("obstacle") || other.CompareTag("Speeder") || other.CompareTag("BallBound"))
        {
            placementHittingCount--;
        }
    }
}