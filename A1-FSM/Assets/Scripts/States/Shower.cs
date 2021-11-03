using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : States
{
    private float timeRemaining = 10.0f;
    public Shower(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered SHOWER State");
        fsm.StartCoroutine(Coroutine_GiveShower(timeRemaining));
    }
    public override void Exit()
    {
        Debug.Log("Exiting SHOWER State");
    }
    IEnumerator Coroutine_GiveShower(float duration)
    {
        Debug.Log("The BOT has started giving the pet a shower.");
        float dt = 0.0f;
        while(dt < duration)
        {
            yield return new WaitForSeconds(1.0f);
            dt += 1.0f;
        }
        Debug.Log("The Shower is done");
        if(fsm.OwnerReturned)
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            fsm.SetCurrentState(StateTypes.DETAIL);
        }     
    }
}
