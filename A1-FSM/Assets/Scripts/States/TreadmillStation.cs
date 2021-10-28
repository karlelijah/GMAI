using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillStation : States
{
    public static int runCount = 0;
    private float timeRemaining = 4;
    //private bool startExercising = false;

    public TreadmillStation(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered TreadmillStation State");
    }

    public override void Execute()
    {        
        takePetForRun();
    }

    public override void Exit()
    {
        Debug.Log("Exiting TreadmillStation State");
        if(runCount == 2)
        {
            runCount -= 2;
        }
    }

    private void takePetForRun()
    {
        //let the pet run on the treadmill for 20 minutes
        //startExercising = true;
        Debug.Log("The pet has just started running on the treadmill.");
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
            runCount += 1;
            //startExercising == false;
            fsm.ChangeState(fsm.DrinkingStationState);
        }
    }
}
