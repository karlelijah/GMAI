using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : States
{
    private float timeRemaining = 4f;
    public static bool foodPrepared = false;
    public Feed(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered FEED State");
        checkForFood();
    }
    public override void Exit()
    {
        Debug.Log("Exiting FEED State");
    }
    public void checkForFood()
    {
        Debug.Log("The pet has just started been brought to the Feeding Station.");
        Debug.Log("Checking if there is food prepared for the pet");
        
        if(foodPrepared = false)
        {
            Debug.Log("There is no food prepared. BOT will head to the Food Store and prepare food.");
            fsm.SetCurrentState(StateTypes.FOODPREPARATION);
        }
        if(foodPrepared = true)
        {
            fsm.StartCoroutine(Coroutine_FeedPet(timeRemaining));
        }
    }
    IEnumerator Coroutine_FeedPet(float duration)
    {
        if(fsm.OwnerReturned)
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            Debug.Log("The food has been given to the pet.");
            float dt = 0.0f;
            while(dt < duration)
            {
                yield return new WaitForSeconds(1.0f);
                dt += 1.0f;
            }
            Debug.Log("The pet has finished eating.");
            fsm.SetCurrentState(StateTypes.HOLDINGAREA);
        }
    }
}
