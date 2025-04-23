using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 점수를 표시할 TextMeshPro 객체
    private int score = 0; // 점수 변수

    void Start()
    {
        UpdateScoreText();
    }

    // 점수 증가 메서드
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    // 점수 텍스트 업데이트
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // 점수 업데이트
    }
}
