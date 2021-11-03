using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detail : States
{
    private float timeRemaining = 15.0f;
    public Detail(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered DETAIL State");
        fsm.StartCoroutine(Coroutine_GiveDetail(timeRemaining));
    }
    public override void Exit()
    {
        Debug.Log("Exiting DETAIL State");
    }
    IEnumerator Coroutine_GiveDetail(float duration)
    {
        float dt = 0.0f;
        while(dt < duration)
        {
            yield return new WaitForSeconds(1.0f);
            dt += 1.0f;
            if(dt == 2.0f)
            {
                Debug.Log("The pet's nails has been cut.");
            }
            if(dt == 4.0f)
            {
                Debug.Log("The pet's ears has been cleaned.");
            }
            if(dt == 6.0f)
            {
                Debug.Log("The pet's teeth has been brushed.");
            }
        }
        if(fsm.OwnerReturned)
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            Debug.Log("The Detailing is done");
            fsm.SetCurrentState(StateTypes.FEED);
        }
    }
}
