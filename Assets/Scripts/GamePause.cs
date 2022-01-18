using System;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    private void OnMouseEnter()
    {
        GameManager.Instance.withIn = false;
    }

    private void OnMouseOver()
    {
        GameManager.Instance.withIn = false;
    }

    private void OnMouseExit()
    {
        GameManager.Instance.withIn = true;
    }
}