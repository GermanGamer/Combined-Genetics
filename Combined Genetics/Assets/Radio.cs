using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Radio : MonoBehaviour
{
    private int rndInt;
    [SerializeField] private GameObject[] AudioSources;
    [SerializeField] private AudioSource click;
    public bool IsOn;
    public Animator anim;

    public void ToggleRadio()
    {
        click.PlayOneShot(click.clip);
        anim.SetTrigger("IsPointingPointing");
        if (!IsOn)
        {
            rndInt = Random.Range(0, 3);
            AudioSources[rndInt].SetActive(true);
            IsOn = true;
        }
        else
        {
            AudioSources[0].SetActive(false);
            AudioSources[1].SetActive(false);
            AudioSources[2].SetActive(false);
            IsOn = false;
        }
    }
}
