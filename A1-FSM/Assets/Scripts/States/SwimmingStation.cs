using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingStation : States
{
    public static int swimCount = 0;
    private float timeRemaining = 10.0f; //Amount of time for the pet to swim

    public SwimmingStation(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered SWIMMINGSTATION State");
        //Start a duration of the pet swimming in the pool.
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
        //Start time for the pet swimming
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
            swimCount += 1; //Add to the count of how many times the pet has swum
            Debug.Log("swimCount = " + swimCount);
            Debug.Log("The pet has swum for 20 minutes.");
            fsm.SetCurrentState(StateTypes.DRINKINGSTATION);
        }      
    }
}
