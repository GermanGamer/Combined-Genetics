using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceHandler : MonoBehaviour
{
    public AudioSource ambienceNorm;
    public AudioSource ambienceComb;
    [Space]
    public float normVolume = 0.5f;
    public float combVolume = 0f;
    public float desiredCombVolume;

    bool lerpMusic;

    void Start()
    {
        
    }

    void Update()
    {
        if (lerpMusic) ambienceComb.pitch = Mathf.Lerp(combVolume, desiredCombVolume, 0.2f * Time.deltaTime);
    }

    public void EnableCombat()
    {
        lerpMusic = true;
        Invoke("DisableCombat", 0.5f);
    }

    public void DisableCombat()
    { 
        lerpMusic = false;
    }
}
