using System;
using UnityEngine;
using UnityEngine.EventSystems;
public enum BallColor
{
    White,
    Red,
    Yellow,
    Green,
    Brown,
    Blue,
    Pink,
    Black
}
public class Ball : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int point = 0;
    public int Point {  get { return point; } set { point = value; } }
    
    [SerializeField]
    private BallColor color;

    [SerializeField]
    private Material[] materials = new Material[8];
    private MeshRenderer meshRenderer;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(point);
        GameManager.instance.PlayerScore += point;
        Destroy(gameObject);
    }

    void OnValidate()
    {
        point = (int)color;
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = materials[point];
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Color(BallColor ball)
    {
        color = ball;
        point = (int)color;
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = materials[point];
    }

    public int GetScore()
    {
        return point;
    }
}
