using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; 

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // TextMeshPro
    private float timeRemaining = 0f; // 남은 시간

    void Start()
    {
        timeRemaining = 210f; // 3분 30초 설정 (210초)
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime; // 매 프레임마다 시간 차감
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // 00:00 형식으로 표시
    }
}