using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    [SerializeField]
    private DataCenter dataCenter;
    public int score = 0; // 점수 변수선언
    public Text scoreText; // 점수표시 txt
    
    void Start()
    {
        UpdateScoreUI(); // 아마도 UI초기화
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("점수: " + score); // 테스트용 디버그로그
        UpdateScoreUI();
    }
    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "현재 점수: " + score.ToString(); //테스트용 txt에 문자열로 변환
    }


    public DataCenter GetDataCenter()
    {
        return dataCenter;
    }

}
