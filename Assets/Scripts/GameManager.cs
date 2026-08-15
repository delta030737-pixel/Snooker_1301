using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore {  get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameObject[] ballPosition;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject QueBall;

    [SerializeField]
    private float xInput = 0f;

    [SerializeField]
    private GameObject ballLine;

    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private TMP_Text notiText;

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

        CameraBehindQueBall();
    }

    void Update()
    {
        RotateBall();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ShootBall();
        }
        if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.isPressed)
        {
            xInput = -0.1f;
        }
        else if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.isPressed)
        {
            xInput = 0.1f;
        }
        else
        {
            xInput = 0f;
        }

        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
            StopBall();
    }

    private void Setball(BallColor col,int i)
    {
        GameObject  obj = Instantiate(ballPrefab,
                                      ballPosition[i].transform.position + Vector3.up,
                                      Quaternion.identity);

        Ball b = obj.GetComponent<Ball>();
        b.Color(col);
    }

    private void ShootBall()
    {
        Rigidbody rb = QueBall.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);
        ballLine.SetActive(false);

        cam.transform.parent = null;
        cam.transform.position = new Vector3(0f, 30f, -42f);
        cam.transform.eulerAngles = new Vector3(45f, 0f, 0f);
    }

    private void RotateBall()
    {
        if (QueBall != null)
            QueBall.transform.Rotate(0f, xInput, 0f);
    }

    private void StopBall()
    {
        Rigidbody rb = QueBall.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        QueBall.transform.eulerAngles = new Vector3(0f, 0f, 0f);

        ballLine.SetActive(true);
        CameraBehindQueBall();
    }

    private void CameraBehindQueBall()
    {
        cam.transform.parent = QueBall.transform;
        cam.transform.position = QueBall.transform.position + new Vector3(0f, 7f, -15f);
        cam.transform.eulerAngles = new Vector3(30f, 0f, 0f);
    }

    public void ShowNotiText(string text)
    {
        notiText.text = text;
    }    
}
