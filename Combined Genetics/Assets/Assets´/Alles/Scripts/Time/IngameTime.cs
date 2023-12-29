using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using TMPro;

public class IngameTime : MonoBehaviour
{
    [Header("Time Settings")]
    [Range(0f, 24f)] 
    public float currentTime;
    public float timeSpeed = 1f;

    [Header("CurrentTime")]
    public string currentTimeString;

    [Header("Light Settings")]
    public Light sunLight;
    public float sunPosition = 1f; 
    public float sunIntensity = 1f;
    public AnimationCurve sunIntensityMult;
    public AnimationCurve lightTemperatureCurve;

    public bool isDay = true;


    void Start()
    {
        UpdateTextTime();
        CheckShadowStatus();
    }
    void Update()
    {
        currentTime += Time.deltaTime * timeSpeed;

        if(currentTime >= 24)
        {
            currentTime = 0;    
        }

        UpdateTextTime();
        UpdateLight();
        CheckShadowStatus();
    }



    private void OnValidate()
    {
        UpdateLight();
        CheckShadowStatus();
    }

    void UpdateTextTime()
    {
        currentTimeString = Mathf.Floor(currentTime).ToString("00") + ":" + ((currentTime % 1) * 60).ToString("00");
    }

    void UpdateLight()
    {
        float sunRotation = currentTime / 24f * 360f;
        sunLight.transform.rotation = Quaternion.Euler(sunRotation - 90f, sunPosition, 0f);

        float normalizedTime = currentTime / 24f;
        float intensityCurve = sunIntensityMult.Evaluate(normalizedTime);

        HDAdditionalLightData sunLightData = sunLight.GetComponent<HDAdditionalLightData>();

        if(sunLightData != null ) 
        {
            sunLightData.intensity = intensityCurve * sunIntensity;
        }

        float TemperatureMult = lightTemperatureCurve.Evaluate(normalizedTime);
        Light lightComponent = sunLight.GetComponent<Light>();

        if(lightComponent != null ) 
        {
            lightComponent.colorTemperature = TemperatureMult * 10000f;
        }
    }

    void CheckShadowStatus()
    {
        HDAdditionalLightData sunLightData = sunLight.GetComponent<HDAdditionalLightData>();
        float currentSunRotation = currentTime;
        if(currentSunRotation >= 6f && currentSunRotation <= 18f)
        {
            sunLightData.EnableShadows(true);
            isDay = true;
        }
        else
        {
            sunLightData.EnableShadows(false);
            isDay = false;
        }
    }
}
