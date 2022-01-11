using System.Security.Cryptography;
using UnityEngine;
    public class ObstacleScroller : MonoBehaviour
    {
        private void Update()
        {
            if (GameManager.IsScrolling)
                transform.Translate(Vector3.up * GameManager.Speed * Time.deltaTime, Space.World);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("ObstacleEdge"))
            {
                Destroy(gameObject);
            }
        }
    }
