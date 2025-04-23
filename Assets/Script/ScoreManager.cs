using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ������ ǥ���� TextMeshPro ��ü
    private int score = 0; // ���� ����

    void Start()
    {
        UpdateScoreText();
    }

    // ���� ���� �޼���
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    // ���� �ؽ�Ʈ ������Ʈ
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // ���� ������Ʈ
    }
}
