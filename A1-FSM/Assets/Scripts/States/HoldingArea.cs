using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingArea : States
{
    public static bool ownerReturned = false;
    public HoldingArea(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered HOLDINGAREA State");
        // wait and check for may be a few second to see if the owener has return.
        petInHoldingArea();
        checkForOwner();
    }

    public override void Exit()
    {
        Debug.Log("Exiting HOLDINGAREA State");
    }
    
    public void petInHoldingArea()
    {
        Debug.Log("The pet is now in the Holding Area waiting for its owner...");
        //fsm.petWaiting = true;
    }
    public void checkForOwner()
    {
        if(fsm.OwnerReturned)
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            Debug.Log("The owner has not returned");
            fsm.SetCurrentState(StateTypes.IDLE);
        }
    }
}
