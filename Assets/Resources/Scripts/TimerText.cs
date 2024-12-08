using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; 

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // TextMeshPro
    private float timeRemaining = 0f; // ���� �ð�

    void Start()
    {
        timeRemaining = 210f; // 3�� 30�� ���� (210��)
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime; // �� �����Ӹ��� �ð� ����
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // 00:00 �������� ǥ��
    }
}