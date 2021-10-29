using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : States
{
    public Return(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered RETURN State");
        handOverPetToOwner();
    }
    public override void Exit()
    {
        Debug.Log("Exiting RETURN State");
    }
    public void handOverPetToOwner()
    {
        //fsm.OwnerReturned = false;
        //fsm.petWaiting = false;
        Debug.Log("Pet has been returned to owner");
        fsm.SetCurrentState(StateTypes.IDLE);
    }
}
