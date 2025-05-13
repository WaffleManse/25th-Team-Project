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
    public TMP_Text scoreText; // ����ǥ�� txt
    public TMP_Text bestScoreText;

    //private void Awake()
    //{
    //    PlayerPrefs.SetInt("BestScore", 0);

    //}

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
        if (scoreText != null)
            scoreText.text = "���� ����: " + score.ToString(); //�׽�Ʈ�� txt�� ���ڿ��� ��ȯ
    }


    public DataCenter GetDataCenter()
    {
        return dataCenter;
    }

}
