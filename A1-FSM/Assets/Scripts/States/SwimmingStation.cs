using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingStation : States
{
    public static int swimCount = 0;
    private float timeRemaining = 10.0f;
    //private bool startExercising = false;

    public SwimmingStation(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered SWIMMINGSTATION State");
        fsm.StartCoroutine(Coroutine_TakePetForSwim(timeRemaining));
    }

    public override void Exit()
    {
        Debug.Log("Exiting SWIMMINGSTATION State");
    }

    IEnumerator Coroutine_TakePetForSwim(float duration)
    {
        Debug.Log("The pet has just started swimming.");
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
            swimCount += 1;
            Debug.Log("swimCount = " + swimCount);
            Debug.Log("The pet has swum for 20 minutes.");
            fsm.SetCurrentState(StateTypes.DRINKINGSTATION);
        }      
    }
}
