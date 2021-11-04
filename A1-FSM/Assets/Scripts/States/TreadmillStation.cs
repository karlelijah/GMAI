using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillStation : States
{
    public static int runCount = 0;
    private float timeRemaining = 10.0f; //Amount of time for the pet to run on the treadmill

    public TreadmillStation(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered TREADMILLSTATION State");
        //Start a duration of the pet running on the treadmil.
        fsm.StartCoroutine(Coroutine_TakePetForRun(timeRemaining));
    }

    public override void Exit()
    {
        Debug.Log("Exiting TREADMILLSTATION State");
    }

    IEnumerator Coroutine_TakePetForRun(float duration)
    {
        Debug.Log("The pet has just started running.");
        float dt = 0.0f;
        //Start Timer for the pet running
        while(dt < duration)
        {
            yield return new WaitForSeconds(1.0f);
            dt += 1.0f;
        }
        if(fsm.OwnerReturned) //Check if the owner has Returned
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            //Once the pet has run, go to the drinking station
            runCount += 1; //Add to the count of how many times the pet has run
            Debug.Log("runCount =" + runCount);
            Debug.Log("The pet has run for 20 minutes.");
            fsm.SetCurrentState(StateTypes.DRINKINGSTATION);
        }   
    }
}
