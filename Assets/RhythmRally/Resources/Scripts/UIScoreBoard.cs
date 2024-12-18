using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI text_Score;

    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        text_Score.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
