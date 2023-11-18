using System;
using TMPro;
using UnityEngine;

public class MenuScoreDisplay : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("Level1Time"))
        {
            float level1Time = PlayerPrefs.GetFloat("Level1Time", 0);
            if (level1Time > 0)
            {
                TextMeshProUGUI textMeshProUGUI = GetComponent<TextMeshProUGUI>();
                textMeshProUGUI.text = "Meilleur temps : " + Math.Round(level1Time, 2);
                textMeshProUGUI.enabled = true;
            }
        }
    }

}
