using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkingStation : States
{
    private float timeRemaining = 10.0f; //Amount of time for the pet to drink water
    public DrinkingStation(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered DRINKINGSTATION State");
        //Start Duration for the pet to drink water
        fsm.StartCoroutine(Coroutine_TakePetForDrink(timeRemaining));
    }
    public override void Exit()
    {
        Debug.Log("Exiting DRINKINGSTATION State");
    }
    IEnumerator Coroutine_TakePetForDrink(float duration)
    {
        Debug.Log("Bot gave the pet a bowl of water to drink.");
        float dt = 0.0f;
        //Start timer for the pet to drink water
        while(dt < duration)
        {
            yield return new WaitForSeconds(1.0f);
            dt += 1.0f;
        }
        
        if(fsm.OwnerReturned) //Check if the owner has returned
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            if(Transaction.bundleSelected.Contains("D")) //Check whether the bundle chosen is Set D
            {
                if(SwimmingStation.swimCount == 2) //Check if the pet has swum twice
                {
                    Debug.Log("The pet has finished 2 rounds of swimming and will head for their grooming now.");
                    SwimmingStation.swimCount -= 2; //Reset the swimCount to 0
                    fsm.SetCurrentState(StateTypes.HAIRCUT);
                }
                else
                {
                    //Return to the treadmill station if the pet has swum < 2
                    Debug.Log("Bot will bring the pet back to the swimming pool for the second round.");
                    fsm.SetCurrentState(StateTypes.SWIMMINGSTATION);
                }
            }
            if(Transaction.bundleSelected.Contains("C")) //Check whether the bundle chosen is Set C
            {
                if(TreadmillStation.runCount == 2) //Check if the pet has run twice
                {
                    Debug.Log("The pet has finished 2 rounds of running and will head for their grooming now.");
                    TreadmillStation.runCount -= 2; //Reset the runCount to 0
                    fsm.SetCurrentState(StateTypes.HAIRCUT);
                }
                else
                {
                    //Return to the treadmill station if the pet has run < 2
                    Debug.Log("Bot will bring the pet back to the treadmill for the second round.");
                    fsm.SetCurrentState(StateTypes.TREADMILLSTATION);
                }
            }
        }
    }
}
