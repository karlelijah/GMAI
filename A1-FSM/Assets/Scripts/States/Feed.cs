using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : States
{
    private float timeRemaining = 10.0f; //Amount of time for the pet to eat the food
    public static bool foodPrepared = false; //Set that the food is not prepared if the pet has just arrived at the feeding station for the first time

    public Feed(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered FEED State");
        checkForFood(); //Check if there are any food prepared for the pet
    }
    public override void Exit()
    {
        Debug.Log("Exiting FEED State");
    }
    public void checkForFood()
    {
        Debug.Log("The pet has been brought to the Feeding Station.");
        Debug.Log("Checking if there is food prepared for the pet");
        
        if(foodPrepared == false) //If there is no food, go to the Food Store and prepare food for the pet
        {
            Debug.Log("There is no food prepared. BOT will head to the Food Store and prepare food.");
            fsm.SetCurrentState(StateTypes.FOODPREPARATION);
        }
        if(foodPrepared == true) //If there is food, give it to the pet and let them eat
        {
            Debug.Log("The food has been prepared.");
            //Start duration of the pet eating the food prepared
            fsm.StartCoroutine(Coroutine_FeedPet(timeRemaining));
        }
    }
    IEnumerator Coroutine_FeedPet(float duration)
    {
        if(fsm.OwnerReturned) //Check if the owner has Returned
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            Debug.Log("The food has been given to the pet.");
            foodPrepared = false;
            float dt = 0.0f;
            //Start timer for the pet eating the food
            while(dt < duration)
            {
                yield return new WaitForSeconds(1.0f);
                dt += 1.0f;
            }
            Debug.Log("The pet has finished eating.");
            //Once done eating, go to the Holding Area
            fsm.SetCurrentState(StateTypes.HOLDINGAREA);
        }
    }
}
