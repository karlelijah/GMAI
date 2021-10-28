using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingStation : States
{
    public static int swimCount = 0;
    private float timeRemaining = 4;
    //private bool startExercising = false;

    public SwimmingStation(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered SwimmingStation State");
    }

    public override void Execute()
    {        
        takePetForSwim();
    }

    public override void Exit()
    {
        Debug.Log("Exiting SwimmingStation State");
        if(swimCount == 2)
        {
            swimCount -= 2;
        }
    }

    private void takePetForSwim()
    {
        //let the pet swim for 20 minutes
        //startExercising = true;
        Debug.Log("The pet has just started swimming.");
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining == 0)
        {
            Debug.Log("20 minutes has passed. Bot will bring it to the drinking station for a drink.");
            swimCount += 1;
            //startExercising == false;
            fsm.ChangeState(fsm.DrinkingStationState);
        }
    }
}
