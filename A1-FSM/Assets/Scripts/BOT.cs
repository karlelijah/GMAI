using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOT : MonoBehavior
{
    States m_currentState;

    public States IdleState;
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
        IdleState = new Idle(this);
        TransactionState = new Transaction(this);
        SwimmingStationState = new Swimming(this);
        TreadmillStationState = new Treadmill(this);
        DrinkingStationState = new Drink(this);
        HaircutState = new Haircut(this);
        ShowerState = new Shower(this);
        DetailState = new Detail(this);
        FeedState = new Feed(this);
        FoodPreparationState = new FoodPreparation(this);
        HoldingAreaState = new HoldingArea(this);
        ReturnState = new Return(this);
    }

    publid void ChangeState(States nextState)
    {
        m_currentState.Exit();
        m_currentState = nextState;
        m_currentState.State();
    }
}