using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        // Charger la valeur enregistrée ou utiliser une valeur par défaut
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
    }

    public void OnVolumeChange()
    {
        // Mettre à jour le volume dans PlayerPrefs lorsque le slider change
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        Debug.Log("Volume changed to " + volumeSlider.value);
    }
}
