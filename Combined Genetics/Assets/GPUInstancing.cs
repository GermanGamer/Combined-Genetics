using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUInstancing : MonoBehaviour
{
    public Vector3 Position, Rotation, Scale;
    public void Start()
    {
        Matrix4x4 Matrix = Matrix4x4.TRS(pos: Position, q: Quaternion.Euler(Rotation), s: Scale);
    }
}
