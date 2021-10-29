using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkingStation : States
{
    private float timeRemaining = 4;
    public DrinkingStation(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered DRINKINGSTATION State");
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
        while(dt < duration)
        {
            yield return new WaitForSeconds(1.0f);
            dt += 1.0f;
        }
        
        if(fsm.OwnerReturned)
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            if(SwimmingStation.swimCount < 2)
            {
                Debug.Log("Bot will bring the pet back to the swimming pool for the second round.");
                fsm.SetCurrentState(StateTypes.SWIMMINGSTATION);
            }
            if(TreadmillStation.runCount < 2)
            {
                Debug.Log("Bot will bring the pet back to the treadmill for the second round.");
                fsm.SetCurrentState(StateTypes.TREADMILLSTATION);
            }
            if(SwimmingStation.swimCount == 2 || TreadmillStation.runCount == 2)
            {
                Debug.Log("The pet has finished 2 rounds of exercise and will head for their grooming now.");
                fsm.SetCurrentState(StateTypes.HAIRCUT);
            }
        }
    }
}
