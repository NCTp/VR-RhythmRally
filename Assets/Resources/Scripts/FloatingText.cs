using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; 


public class FloatingText : MonoBehaviour
{
    public TextMeshProUGUI floatingText; // ȭ�鿡 ǥ�õ� TextMeshPro �ؽ�Ʈ
    public float displayTime = 2f; // �ؽ�Ʈ�� �������� �ð�

    public void ShowText(string message, Vector3 position)
    {
        floatingText.text = message;
        floatingText.transform.position = position;
        floatingText.gameObject.SetActive(true); // �ؽ�Ʈ Ȱ��ȭ

        // ���� �ð��� ���� �� �ؽ�Ʈ�� ��Ȱ��ȭ
        StartCoroutine(HideTextAfterTime());
    }

    private IEnumerator HideTextAfterTime()
    {
        yield return new WaitForSeconds(displayTime);
        floatingText.gameObject.SetActive(false); // �ؽ�Ʈ ��Ȱ��ȭ
    }
}