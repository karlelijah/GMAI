using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transaction : States
{
    private List<string> bundleList = new List<string>{"A", "B", "C", "D"};
    public static List<string> bundleSelected = new List<string>{};
    //How can I implement whether the customer has made payment?

    public Transaction(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        if(fsm.OwnerReturned) //Check if the owner has returned
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            Debug.Log("Entered TRANSACTION State");
            selectBundle();
            checkBundle();
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting TRANSACTION State");
    }

    private void selectBundle()
    {
        //Randomize the list to retrieve what the bundle will be for the current customer
        bundleSelected.Clear(); //Clear the current list so that there is only one bundle at a time
        int randomNumber = Random.Range(1,4); //Randomize a number from 1 to 4
        bundleSelected.Add(bundleList[randomNumber]); //Add that Bundle according to the random number into the bundleSelected List
    }

    private void checkBundle()
    {
        //check what bundle the customer has chosen
        //Once bundle is chosen, go to the according station
        if (bundleSelected.Contains("A"))
        {
            Debug.Log("The customer has chosen Set A and has paid $25.");
            fsm.SetCurrentState(StateTypes.HAIRCUT);
        }
        if (bundleSelected.Contains("B"))
        {
            Debug.Log("The customer has chosen Set B and has paid $35.");
            fsm.SetCurrentState(StateTypes.HAIRCUT);
        }
        if (bundleSelected.Contains("C"))
        {
            Debug.Log("The customer has chosen Set C and has paid $50.");
            fsm.SetCurrentState(StateTypes.TREADMILLSTATION);
        }
        if (bundleSelected.Contains("D"))
        {
            Debug.Log("The customer has chosen Set D and has paid $55.");
            fsm.SetCurrentState(StateTypes.SWIMMINGSTATION);
        }
        else //If the bundleSelected List is empty
        {
            Debug.Log("Waiting for the customer to choose a bundle...");
        }  
    }
}
