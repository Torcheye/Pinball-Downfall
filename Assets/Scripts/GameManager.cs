using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const float Speed = 1;
    public static int GameState;

    public Transform reposition;
    public static GameManager Instance { get; private set; }
    public GameObject[] obstacleList;
    public int money { get; set; }
    
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
        GameState = 1;
        _life = 3;
        money = 100;
    }

    public void BallOutOfBound()
    {
        if (--_life == 0)
        {
            Fail();
        }

        GameState = 2;
        //
    }

    private void Fail()
    {
        GameState = 3;
    }

    private void SpawnObstacle(int id, Vector2 pos)
    {
        var obj = Instantiate(obstacleList[id], pos, Quaternion.identity);
    } 
}
