
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    [SerializeField]
    private DataCenter dataCenter;
    public int score = 0; // 점수 변수선언
    private int bestScore = 0;
    public Text scoreText; // 점수표시 txt
    public Text bestScoreText;

    private void Awake()
    {
        PlayerPrefs.SetInt("score", 50);

    }

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
        score = PlayerPrefs.GetInt("score", 0);
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        Debug.Log("현재 점수 = " + score);
        Debug.Log("최고 점수 = " + bestScore);

        if (score > bestScore)
        {
            bestScore = score;
            

            PlayerPrefs.SetInt("bestScore", bestScore);
        }

        if (scoreText != null)
            scoreText.text = score.ToString(); //테스트용 txt에 문자열로 변환

        if (bestScoreText != null)
            bestScoreText.text = bestScore.ToString();

        //bestScore = PlayerPrefs.GetInt(score, 50);



    }


    public DataCenter GetDataCenter()
    {
        return dataCenter;
    }

}
