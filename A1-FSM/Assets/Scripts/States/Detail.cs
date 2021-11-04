using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detail : States
{
    private float timeRemaining = 15.0f; //Amount of time for the bot to do the pet's detailing
    public Detail(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered DETAIL State");
        //Start duration of the Detailing
        fsm.StartCoroutine(Coroutine_GiveDetail(timeRemaining));
    }
    public override void Exit()
    {
        Debug.Log("Exiting DETAIL State");
    }
    IEnumerator Coroutine_GiveDetail(float duration)
    {
        float dt = 0.0f;
        //Start time for the Detailing
        while(dt < duration)
        {
            yield return new WaitForSeconds(1.0f);
            dt += 1.0f;
            if(dt == 2.0f) //After roughly 2 seconds
            {
                Debug.Log("The pet's nails has been cut.");
            }
            if(dt == 4.0f) //After roughly 4 seconds
            {
                Debug.Log("The pet's ears has been cleaned.");
            }
            if(dt == 6.0f) //After roughly 6 seconds
            {
                Debug.Log("The pet's teeth has been brushed.");
            }
        }
        if(fsm.OwnerReturned) //Check if the owner has Returned
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            //Once detailing is done, go to the feeding station
            Debug.Log("The Detailing is done");
            fsm.SetCurrentState(StateTypes.FEED);
        }
    }
}
