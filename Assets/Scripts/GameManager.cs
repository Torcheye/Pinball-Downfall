using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public int gameState;

    public Transform reposition;
    public static GameManager Instance { get; private set; }
    public int Money { get; set; }
    public float Score { get; set; }
    public GameObject[] coins;
    public Image[] lives;
    public Sprite live, dead;
    public GameObject spring;
    public Transform paper1, paper2;
    public GameObject FailUI;
    
    private int _life;
    private List<GameObject> _pool;
        
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _pool = new List<GameObject>();

        Score = 0;
        _life = 3;
        Money = 0;
        FailUI.SetActive(false);
        ResetScene();

        StartCoroutine(SpawnCoins());
    }

    private void Update()
    {
        if (gameState == 1)
            Score += Time.deltaTime;
    }

    public void BallOutOfBound()
    {
        if (--_life == 0)
        {
            UpdateLife();
            Fail();
        }
        else
        {
           ResetScene(); 
        }
    }

    private void ResetScene()
    {
        foreach (var o in _pool)
        {
            Destroy(o);
        }
        _pool.Clear();

        var ball = GameObject.Find("Ball");
        ball.transform.position = new Vector3(3.8f, -1.35f, 0);
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameState = 0;
        spring.SetActive(true);
        UpdateLife();
        paper1.position = new Vector3(0, -12.3600006f, 0);
        paper2.position = new Vector3(0, -0.8100004f, 0);
    }

    private void UpdateLife()
    {
        for (var i = 0; i < 3; i++)
        {
            lives[i].sprite = i < 3 - _life ? dead : live;
        }
    }

    private void Fail()
    {
        gameState = 2;
        StopCoroutine(SpawnCoins());
        FailUI.SetActive(true);
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(1f, 3f));
            
            if (gameState != 1)
                continue;

            _pool.Add(Instantiate(coins[Random.Range(0, 2)], new Vector3(Random.Range(-4f, 4f), -5.6f, 0), Quaternion.identity));
        }
    }
}