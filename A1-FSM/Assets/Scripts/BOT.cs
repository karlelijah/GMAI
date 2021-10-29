using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateTypes
{
    IDLE,
    TRANSACTION,
    SWIMMINGSTATION,
    TREADMILLSTATION,
    DRINKINGSTATION,
    HAIRCUT,
    SHOWER,
    DETAIL,
    FEED,
    FOODPREPARATION,
    HOLDINGAREA,
    RETURN,
}

public class BOT : MonoBehaviour
{
    States m_currentState;

    [SerializeField]

    List<States> mStates = new List<States>();

    public bool OwnerReturned {get;private set;} = false;
    public bool petWaiting {get;private set;} = false;
    
    private void Start()
    {
        mStates.Add(new IDLE(this));
        mStates.Add(new Transaction(this));
        mStates.Add(new SwimmingStation(this));
        mStates.Add(new TreadmillStation(this));
        mStates.Add(new DrinkingStation(this));
        mStates.Add(new Haircut(this));
        mStates.Add(new Shower(this));
        mStates.Add(new Detail(this));
        mStates.Add(new Feed(this));
        mStates.Add(new FoodPreparation(this));
        mStates.Add(new HoldingArea(this));
        mStates.Add(new Return(this));
        SetCurrentState(StateTypes.IDLE);
    }

    private void Update() 
    {
        if(m_currentState != null)
        {
            m_currentState.Update();
        }
        
        // check for owner return
        // for this sample application
        // owner return can be achieved by clicing the R button.
        if(Input.GetKeyDown(KeyCode.R))
        {
            //SetCurrentState(StateTypes.RETURN);
            OwnerReturned = true;
        }
    }

    private void SetCurrentState(States nextState)
    {
        if(m_currentState != null)
        {
            m_currentState.Exit();
        }
        m_currentState = nextState;

        if(m_currentState != null)
        {
            m_currentState.Enter();
        }
    }

    public void SetCurrentState(StateTypes nextState)
    {
        SetCurrentState(mStates[(int)nextState]);
    }
}
