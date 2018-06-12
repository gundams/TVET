using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    public UnityEvent onGoal;
    void OnTriggerEnter(Collider other)
    {
        // Check if onGoal event exist
        if(onGoal !=null)
        {
            //Invoke event
            onGoal.Invoke();
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
