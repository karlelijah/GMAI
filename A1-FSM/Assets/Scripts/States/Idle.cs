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
        if (fsm.OwnerReturned) //to check whether a pet's owner has returned
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            Debug.Log("Entered IDLE State");
            Debug.Log("Waiting for a customer...");
            Debug.Log("There is a customer. Press Space to enter TRANSACTION state.");
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting IDLE State");
    }

    public override void Update()
    {
        //Debug.Log("IDLE Update");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fsm.SetCurrentState(StateTypes.TRANSACTION);
        }
    }
}
