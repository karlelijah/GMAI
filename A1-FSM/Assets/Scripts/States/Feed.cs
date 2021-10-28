using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : States
{
    public Feed(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered Idle State");
    }

    public override void Execute()
    {
        Debug.Log("Waiting for a customer...");
        fsm.ChangeState(fsm.TransactionState);
    }

    public override void Exit()
    {
        Debug.Log("Exiting Idle State");
    }
}
