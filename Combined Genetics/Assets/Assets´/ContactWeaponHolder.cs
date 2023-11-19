using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactWeaponHolder : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            anim.SetBool("IsInContact", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            anim.SetBool("IsInContact", false);
        }
    }
}
