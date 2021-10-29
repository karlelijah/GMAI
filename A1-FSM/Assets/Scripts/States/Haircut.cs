using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haircut : States
{
    private float timeRemaining = 4f;
    public Haircut(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered HAIRCUT State");
        fsm.StartCoroutine(Coroutine_GiveHaircut(timeRemaining));
    }
    public override void Exit()
    {
        Debug.Log("Exiting HAIRCUT State");
    }
    IEnumerator Coroutine_GiveHaircut(float duration)
    {
        Debug.Log("The BOT has started giving the pet a haircut.");
        float dt = 0.0f;
        while(dt < duration)
        {
            yield return new WaitForSeconds(1.0f);
            dt += 1.0f;
        }
        Debug.Log("The Haircut is done");
        if(fsm.OwnerReturned)
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            fsm.SetCurrentState(StateTypes.SHOWER);
        }   
    }
}
