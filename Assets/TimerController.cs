using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool timerActive = false;

    void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        startTime = Time.time;
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;

        // Enregistrer le temps dans PlayerPrefs (si il est meilleur que le temps actuel)
        float actualBestTime = PlayerPrefs.GetFloat("Level1Time", 0);
        float finalTime = Time.time - startTime;
        Debug.Log("Comparing " + finalTime + " to " + actualBestTime);
        if (actualBestTime == 0 || finalTime < actualBestTime)
        {
            PlayerPrefs.SetFloat("Level1Time", finalTime);
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        if (timerActive)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString("00");
            string seconds = ((int)t % 60).ToString("00");
            string milliseconds = ((int)(t * 1000) % 1000).ToString("000");

            timerText.text = minutes + ":" + seconds + ":" + milliseconds;
        }
    }
}