using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; 


public class FloatingText : MonoBehaviour
{
    public TextMeshProUGUI floatingText; // 화면에 표시될 TextMeshPro 텍스트
    public float displayTime = 2f; // 텍스트가 보여지는 시간

    public void ShowText(string message, Vector3 position)
    {
        floatingText.text = message;
        floatingText.transform.position = position;
        floatingText.gameObject.SetActive(true); // 텍스트 활성화

        // 일정 시간이 지난 후 텍스트를 비활성화
        StartCoroutine(HideTextAfterTime());
    }

    private IEnumerator HideTextAfterTime()
    {
        yield return new WaitForSeconds(displayTime);
        floatingText.gameObject.SetActive(false); // 텍스트 비활성화
    }
}