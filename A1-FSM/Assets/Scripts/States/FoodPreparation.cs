using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPreparation : States
{
    private float timeRemaining = 4f;
    public FoodPreparation(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered FOODPREPARATION State");
        fsm.StartCoroutine(Coroutine_Preparefood(timeRemaining));
    }
    public override void Exit()
    {
        Debug.Log("Exiting FOODPREPARATION State");
    }
    IEnumerator Coroutine_Preparefood(float duration)
    {
        if(fsm.OwnerReturned)
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            Debug.Log("Preparing food...");
            float dt = 0.0f;
            while(dt < duration)
            {
                yield return new WaitForSeconds(1.0f);
                dt += 1.0f;
            }
            Feed.foodPrepared = true;
            Debug.Log("The pet has been prepared. BOT heading to the Feeding Station.");
            fsm.SetCurrentState(StateTypes.FEED);
        }       
    }
}
