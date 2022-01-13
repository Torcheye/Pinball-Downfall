using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moneyDisplay;
    public Button[] obstacleList;
    public GameObject[] prefabList;
    public GameObject preview;

    private int _previewID;
    private Transform _previewTransform;
    private SpriteRenderer _previewSpriteRenderer;
    private Camera _cam;

    private void Start()
    {
        for (var i = 0; i < obstacleList.Length; i++)
        {
            var i1 = i;
            obstacleList[i1].GetComponent<Button>().onClick.AddListener(delegate
            {
                TogglePreview(i1);
                GameManager.Instance.money -= prefabList[i1].GetComponent<Obstacle>().value;
            });
        }

        _previewID = -1;
        _previewSpriteRenderer = preview.GetComponent<SpriteRenderer>();
        _previewTransform = preview.GetComponent<Transform>();
        _cam = Camera.main; 
        
        TogglePreview(-1);
    }

    private void TogglePreview(int id)
    {
        _previewID = id;
        if (id == -1)
        {
            preview.SetActive(false);
            return;
        }
        preview.SetActive(true);
        _previewTransform.localScale = prefabList[id].transform.localScale;
        _previewSpriteRenderer.color = new Color(0.41f, 1f, 0.4f, 0.41f);
        _previewSpriteRenderer.sprite = prefabList[id].GetComponent<SpriteRenderer>().sprite;
    }

    private void Update()
    {
        moneyDisplay.text = "$ " + GameManager.Instance.money;

        if (_previewID != -1)
        {
            var tempPos = _cam.ScreenToWorldPoint(Input.mousePosition);
            var pos = new Vector2(tempPos.x, tempPos.y);
            _previewTransform.position = pos;

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(prefabList[_previewID], pos, Quaternion.identity);
                TogglePreview(-1);
            }
        }
    }
}