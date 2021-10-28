using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOT : MonoBehaviour
{
    States m_currentState;

    public States IDLEState;
    public States TransactionState;
    public States SwimmingStationState;
    public States TreadmillStationState;
    public States DrinkingStationState;
    public States HaircutState;
    public States ShowerState;
    public States DetailState;
    public States FeedState;
    public States FoodPreparationState;
    public States HoldingAreaState;
    public States ReturnState;

    [SerializeField]
    
    private void Start()
    {
        IDLEState = new IDLE(this);
        TransactionState = new Transaction(this);
        SwimmingStationState = new SwimmingStation(this);
        TreadmillStationState = new TreadmillStation(this);
        DrinkingStationState = new DrinkingStation(this);
        HaircutState = new Haircut(this);
        ShowerState = new Shower(this);
        DetailState = new Detail(this);
        FeedState = new Feed(this);
        FoodPreparationState = new FoodPreparation(this);
        HoldingAreaState = new HoldingArea(this);
        ReturnState = new Return(this);
    }

    public void ChangeState(States nextState)
    {
        m_currentState.Exit();
        m_currentState = nextState;
        m_currentState.Enter();
    }
}
