
using UnityEngine;
using UnityEngine.UI;

public class ReadScoreUI : MonoBehaviour
{
    public int score = 0; // ���� ����
    public Text scoreText; // UI�� ������ �ؽ�Ʈ

    [SerializeField]
    private DataCenter dataCenter; // ������ ���� (��: ���� ��)

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
