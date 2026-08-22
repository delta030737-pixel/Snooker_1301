using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Ball b = other.GetComponent<Ball>();

        if (b == null) return;
        GameManager instance = GameManager.instance;

        instance.SetScore(instance.PlayerScore + b.GetScore());
        GameManager.instance.ShowNotiText($"Score : {instance.PlayerScore}");
        if (b.GetScore() == 0)
        {
            GameManager.instance.ShowNotiText($"Game Over\n Score : {instance.PlayerScore}");
            Time.timeScale = 0f;
        }
        Destroy(other.gameObject);
    }
}
