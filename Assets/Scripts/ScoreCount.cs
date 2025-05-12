using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public int score = 0; // ���� ��������
    public Text scoreText; // ����ǥ�� txt
    
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

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //�׽�Ʈ�� �����̽��� ������ ��������
        {
            AddScore(10);
        }
    }
}
