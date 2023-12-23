using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camPos : MonoBehaviour
{
    public Transform camTrans;

    void Update()
    {
        transform.position = camTrans.position;
    }
}
