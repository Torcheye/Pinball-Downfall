using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public Rigidbody2D push;
    public Transform startPush, endPush;
    public Transform spring;

    private float _counter, _rotateCounter = 10;
    private bool _isRotatingPositive = true;

    private void OnEnable()
    {
        transform.localEulerAngles = new Vector3(0, 0, 10);
        _rotateCounter = 10;
        _isRotatingPositive = true;
    }

    private void Update()
    {
        if (GameManager.Instance.gameState != 0)
            return;
        
        if (Input.GetMouseButtonDown(0))
        {
            _counter = 0;
        }
        
        if (Input.GetMouseButton(0))
        {            
            _counter += Time.deltaTime * .5f;
            push.MovePosition(Vector2.Lerp(startPush.position, endPush.position, _counter));
            spring.localScale = new Vector3(.27f, Mathf.Lerp(.27f, .05f, _counter), 1);
        }
        else
        {
            _rotateCounter += Time.deltaTime * 20 * (_isRotatingPositive ? 1 : -1);
            Mathf.Clamp(_rotateCounter, 10, 65);
            if (_rotateCounter >= 65)
                _isRotatingPositive = false;
            if (_rotateCounter <= 10)
                _isRotatingPositive = true;
            transform.localEulerAngles = new Vector3(0, 0, _rotateCounter);
        }

        if (Input.GetMouseButtonUp(0))
        {
            AudioManager.Instance.Play(2);
            GameManager.Instance.gameState = 1;
            spring.DOScaleY(.27f, .13f).SetEase(Ease.OutElastic);
            push.DOMove(startPush.position, .13f);
            StartCoroutine(SetInactive());
        }
    }

    private IEnumerator SetInactive()
    {
        yield return new WaitForSecondsRealtime(1);
        gameObject.SetActive(false);
    }
}