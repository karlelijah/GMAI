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
        handOverPetToOwner(); //Return the pet to its rightful owner
    }
    public override void Exit()
    {
        Debug.Log("Exiting RETURN State");
    }
    public void handOverPetToOwner()
    {
        //Return the pet to its owner
        Debug.Log("Pet has been returned to owner");
        fsm.SetCurrentState(StateTypes.IDLE);
    }
}
