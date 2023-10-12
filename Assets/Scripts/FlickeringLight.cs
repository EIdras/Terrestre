using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class FlickeringLight : MonoBehaviour
{
    public float minIntensity = 0.05f;
    public float maxIntensity = 0.5f;
    public float flickeringSpeed = 0.5f;

    private Light2D _light;
    private float targetIntensity;
    private float currentIntensity;

    void Start()
    {
        _light = GetComponent<Light2D>();
        currentIntensity = _light.intensity;
        targetIntensity = Random.Range(minIntensity, maxIntensity);
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            currentIntensity = _light.intensity;
            targetIntensity = Random.Range(minIntensity, maxIntensity);
            float elapsedTime = 0.0f;

            while (elapsedTime < flickeringSpeed)
            {
                _light.intensity = Mathf.Lerp(currentIntensity, targetIntensity, elapsedTime / flickeringSpeed);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _light.intensity = targetIntensity;
            yield return new WaitForSeconds(flickeringSpeed);
        }
    }
}