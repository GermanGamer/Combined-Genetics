using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNotAutomatic : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool IsOpen;

    public void OpenAndClose()
    {
        if (!IsOpen)
        {
            animator.SetBool("Open", true);
            IsOpen = true;
        }
        else
        {
            animator.SetBool("Open", false);
            IsOpen = false;
        }
    }
}
