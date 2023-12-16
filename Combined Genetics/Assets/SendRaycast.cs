using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendRaycast : MonoBehaviour
{
    public Camera fpsCam;
    public float range = 2;

    void Update()
    {
        SendRaycastVoid();
    }

    void SendRaycastVoid()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            var radio = hit.collider.GetComponent<Radio>();
            if (radio && Input.GetKeyDown(KeyCode.E))
            {
                radio.GetComponent<Radio>().ToggleRadio();
            }

            var door = hit.collider.GetComponent<DoorNotAutomatic>();
            if (door && Input.GetKeyDown(KeyCode.E))
            {
                door.GetComponent<DoorNotAutomatic>().OpenAndClose();
            }
        }
    }

}