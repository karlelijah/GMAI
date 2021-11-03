using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillStation : States
{
    public static int runCount = 0;
    private float timeRemaining = 10.0f;
    //private bool startExercising = false;

    public TreadmillStation(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered TREADMILLSTATION State");
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
        while(dt < duration)
        {
            yield return new WaitForSeconds(1.0f);
            dt += 1.0f;
        }
        if(fsm.OwnerReturned)
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            runCount += 1;
            Debug.Log("runCount =" + runCount);
            Debug.Log("The pet has run for 20 minutes.");
            fsm.SetCurrentState(StateTypes.DRINKINGSTATION);
        }   
    }
}
