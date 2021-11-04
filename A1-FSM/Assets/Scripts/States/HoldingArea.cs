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
        //Wait and check for may be a few second to see if the owner has returned.
        petInHoldingArea(); //Set the pet to be in the Holding Area
        checkForOwner(); //Check if the owner has Returned
    }

    public override void Exit()
    {
        Debug.Log("Exiting HOLDINGAREA State");
    }
    
    public void petInHoldingArea()
    {
        //Put the pet in the Holding Area
        Debug.Log("The pet is now in the Holding Area waiting for its owner...");
    }
    public void checkForOwner()
    {
        if(fsm.OwnerReturned) //Check if the owner has returned
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else //Return to the counter if the owner has not returned
        {
            Debug.Log("The owner has not returned");
            fsm.SetCurrentState(StateTypes.IDLE);
        }
    }
}
