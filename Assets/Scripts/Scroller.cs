using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    protected virtual void Update()
    {
        if (GameManager.IsScrolling)
            transform.Translate(Vector3.up * GameManager.Speed * Time.deltaTime, Space.World);
    }
}
