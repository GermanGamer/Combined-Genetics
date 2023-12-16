using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateRecognizer : MonoBehaviour
{
    public enum CurrentPState
    {
        INDOORS, OUTSIDE, COMINDOORS
    }
    public CurrentPState currentPositionState;


    void Start()
    {
        
    }

    void Update()
    {
        InvokeRepeating("UpCheck", 1.0f, 0.2f); 
        
        UseStates();
    }

    public void Upcheck()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.up, out hit, 10);
        {
            currentPositionState = CurrentPState.INDOORS;
        }
    }

    void UseStates()
    {

    }
}
