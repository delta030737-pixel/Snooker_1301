using UnityEngine;

public class Test : MonoBehaviour
{
    private int n = 1;
    private float timer = 0f;

    private void Awake()
    {
        Debug.Log("Awake");
    }
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        n++;

        Debug.Log(Time.deltaTime);

        if(timer >= 1f)
        {
            Debug.Log(n);
            timer = 0f;
        }
    }
}
