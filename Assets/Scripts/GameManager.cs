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
    }

    void Update()
    {
        
    }

    private void Setball(BallColor col,int i)
    {
        GameObject  obj = Instantiate(ballPrefab,
                                      ballPosition[i].transform.position,
                                      Quaternion.identity);

        Ball b = obj.GetComponent<Ball>();
        b.Color(col);
    }
}
