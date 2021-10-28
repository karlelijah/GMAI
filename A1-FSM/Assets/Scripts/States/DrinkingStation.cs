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
        Debug.Log("Entered DrinkingStation State");
    }

    public override void Execute()
    {
        letPetDrink();
    }

    public override void Exit()
    {
        Debug.Log("Exiting DrinkingStation State");
    }

    private void letPetDrink()
    {
        Debug.Log("Bot gave the pet a bowl of water to drink.");
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining == 0)
        {
            if(SwimmingStation.swimCount < 2)
            {
                Debug.Log("Bot will bring the pet back to the swimming pool for the second round.");
                fsm.ChangeState(fsm.SwimmingStationState);
            }
            if(TreadmillStation.runCount < 2)
            {
                Debug.Log("Bot will bring the pet back to the treadmill for the second round.");
                fsm.ChangeState(fsm.TreadmillStationState);
            }
            if(SwimmingStation.swimCount == 2 || TreadmillStation.runCount == 2)
            {
                Debug.Log("The pet has finished 2 rounds of exercise and will head for their grooming now.");
                fsm.ChangeState(fsm.HaircutState);
            }
        }
    }
}
