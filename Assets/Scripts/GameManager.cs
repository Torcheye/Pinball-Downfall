using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEditor.Build;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const float Speed = 1;
    public static bool IsScrolling;

    public Transform reposition;
    public static GameManager Instance { get; private set; }
    public GameObject[] obstacleList;
    
    private int _life;

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
        IsScrolling = true;
        _life = 3;
    }

    public void BallOutofBound()
    {
        if (--_life == 0)
        {
            Fail();
        }

        IsScrolling = false;
        //
    }

    private void Fail()
    {
        
    }

    private void SpawnObstacle(int id, Vector2 pos)
    {
        var obj = Instantiate(obstacleList[id], pos, Quaternion.identity);
    } 
}
