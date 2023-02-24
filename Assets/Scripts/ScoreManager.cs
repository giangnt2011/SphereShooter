using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    public Text scoreText;
    int score;

    void Awake()
    {
        if (scoreManager)
        {
            Destroy(this.gameObject);
        }
        else
        {
            scoreManager = this;
        }
        UpdateScore();
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
