using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDLE : States
{
    public IDLE(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        if (fsm.OwnerReturned) //Check whether the owner has returned
        {
            Debug.Log("The owner has returned.");
            //Go to Return State
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            Debug.Log("Entered IDLE State");
            Debug.Log("Waiting for a customer...");
            //Trigger a customer to be present at the counter
            Debug.Log("There is a customer. Press Space to enter TRANSACTION state.");
            //If there is a customer, go to Transaction State
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting IDLE State");
    }

    public override void Update()
    {
        //Get the input of the Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fsm.SetCurrentState(StateTypes.TRANSACTION);
        }
    }
}
