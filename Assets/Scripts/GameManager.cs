using System.Runtime.InteropServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore {  get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameObject[] ballPosition;

    [SerializeField]
    private GameObject ballPrefab;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Setball(BallColor.Red, 1);
        Setball(BallColor.Yellow, 2);
        Setball(BallColor.Green, 3);
        Setball(BallColor.Brown, 4);
        Setball(BallColor.Blue, 5);
        Setball(BallColor.Pink, 6);
        Setball(BallColor.Black, 7);
    }

    void Update()
    {
        
    }

    private void Setball(BallColor col,int i)
    {
        GameObject  obj = Instantiate(ballPrefab,
                                      ballPosition[i].transform.position + Vector3.up,
                                      Quaternion.identity);

        Ball b = obj.GetComponent<Ball>();
        b.Color(col);
    }
}
