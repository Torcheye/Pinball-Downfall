using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    protected virtual void Update()
    {
        if (GameManager.Instance.gameState == 1)
            transform.Translate(Vector3.up * .65f * Time.deltaTime, Space.World);
    }
}