
using UnityEngine;
using UnityEngine.UI;

public class ReadScoreUI : MonoBehaviour
{
    public int score = 0; // 현재 점수
    public Text scoreText; // UI에 연결할 텍스트

    [SerializeField]
    private DataCenter dataCenter; // 데이터 모음 (예: 점수 값)

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public DataCenter GetDataCenter()
    {
        return dataCenter;
    }
}
