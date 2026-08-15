using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Ball b = other.GetComponent<Ball>();

        if (b == null) return;
        int score = GameManager.instance.PlayerScore;

        score += b.GetScore();
        GameManager.instance.ShowNotiText($"Score : {score}");
        if (b.GetScore() == 0)
        {
            GameManager.instance.ShowNotiText($"Game Over\n Score : {score}");
            Time.timeScale = 0f;
        }
        Destroy(other.gameObject);
    }
}
