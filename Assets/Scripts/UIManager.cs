using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moneyDisplay, scoreDisplay;
    public Button[] obstacleList;
    public GameObject[] prefabList;
    public GameObject preview;
    public GameObject noMoney;
    public Button restart;

    private int _previewID;
    private Transform _previewTransform;
    private SpriteRenderer _previewSpriteRenderer;
    private Camera _cam;

    private void Start()
    {
        for (var i = 0; i < obstacleList.Length; i++)
        {
            var i1 = i;
            obstacleList[i1].GetComponent<Button>().onClick.AddListener(delegate { AddListener(i1); });
        }
        
        restart.onClick.AddListener(delegate { SceneManager.LoadScene(0); });

        _previewID = -1;
        _previewSpriteRenderer = preview.GetComponent<SpriteRenderer>();
        _previewTransform = preview.GetComponent<Transform>();
        _cam = Camera.main; 
        
        TogglePreview(-1);
    }

    private async void AddListener(int i1)
    {
        if (GameManager.Instance.gameState != 1 && GameManager.Instance.gameState != 3)
            return;

        var tempMoney = GameManager.Instance.Money - prefabList[i1].GetComponent<Placable>().value;
        if (tempMoney < 0)
        {
            var position = noMoney.transform.position;
            
            noMoney.GetComponent<CanvasGroup>().alpha = 1;
            var tween = noMoney.transform.DOMoveY(position.y + 80, .8f).SetEase(Ease.InCirc);
            noMoney.GetComponent<CanvasGroup>().DOFade(0, .8f).SetEase(Ease.InCirc);
            
            await tween.AsyncWaitForCompletion();
            noMoney.transform.DOMoveY(position.y - 80, .01f);
            return;
        }

        GameManager.Instance.Money = tempMoney;
        TogglePreview(i1);
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
        _previewSpriteRenderer.sprite = prefabList[id].GetComponent<SpriteRenderer>().sprite;
    }

    private void Update()
    {
        moneyDisplay.text = "$" + GameManager.Instance.Money;
        scoreDisplay.text = ((int) GameManager.Instance.Score).ToString();

        if (_previewID != -1)
        {
            var tempPos = _cam.ScreenToWorldPoint(Input.mousePosition);
            var pos = new Vector2(tempPos.x, tempPos.y);
            _previewTransform.position = pos;

            if (Input.GetMouseButtonDown(0))
            {
                if (preview.GetComponent<Preview>().placementHittingCount > 0) return;
                Instantiate(prefabList[_previewID], pos, Quaternion.identity);
                TogglePreview(-1);
            }
        }
    }
}