
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    [SerializeField]
    private DataCenter dataCenter;
    public int score = 0; // ���� ��������
    private int bestScore = 0;
    public Text scoreText; // ����ǥ�� txt
    public Text bestScoreText;

    private void Awake()
    {
        PlayerPrefs.SetInt("score", 50);

    }

    void Start()
    {

        UpdateScoreUI(); // �Ƹ��� UI�ʱ�ȭ
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("����: " + score); // �׽�Ʈ�� ����׷α�
        UpdateScoreUI();
    }
    void UpdateScoreUI()
    {
        score = PlayerPrefs.GetInt("score", 0);
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        Debug.Log("���� ���� = " + score);
        Debug.Log("�ְ� ���� = " + bestScore);

        if (score > bestScore)
        {
            bestScore = score;
            

            PlayerPrefs.SetInt("bestScore", bestScore);
        }

        if (scoreText != null)
            scoreText.text = score.ToString(); //�׽�Ʈ�� txt�� ���ڿ��� ��ȯ

        if (bestScoreText != null)
            bestScoreText.text = bestScore.ToString();

        //bestScore = PlayerPrefs.GetInt(score, 50);



    }


    public DataCenter GetDataCenter()
    {
        return dataCenter;
    }

}
