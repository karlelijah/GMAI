using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPreparation : States
{
    private List<string> MeatList = new List<string>{"Tuna", "Chicken", "Beef"};
    private List<string> GreensList = new List<string>{"Fruits", "Vegetables"};
    public static List<string> MeatSelected = new List<string>{};
    public static List<string> GreensSelected = new List<string>{};
    
    private float timeRemaining = 10.0f;
    public FoodPreparation(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered FOODPREPARATION State");
        fsm.StartCoroutine(Coroutine_Preparefood(timeRemaining));
    }
    public override void Exit()
    {
        Debug.Log("Exiting FOODPREPARATION State");
    }
    IEnumerator Coroutine_Preparefood(float duration)
    {
        if(fsm.OwnerReturned)
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            Debug.Log("Preparing food...");
            float dt = 0.0f;
            while(dt < duration)
            {
                yield return new WaitForSeconds(1.0f);
                dt += 1.0f;
            }
            SelectFood();
            Feed.foodPrepared = true;
            Debug.Log("The pet has been prepared. BOT heading to the Feeding Station.");
            fsm.SetCurrentState(StateTypes.FEED);
        }       
    }
    private void SelectFood()
    {
        MeatSelected.Clear();
        GreensSelected.Clear();

        int randomNumber1 = Random.Range(1,3);
        int randomNumber2 = Random.Range(1,2);
        MeatSelected.Add(MeatList[randomNumber1]);
        GreensSelected.Add(GreensList[randomNumber2]);

        foreach(var x in MeatSelected)
        {
            Debug.Log("Bot has selected " + x.ToString());
        }
        foreach(var x in GreensSelected)
        {
            Debug.Log("Bot has selected " + x.ToString());
        }
    }
}
