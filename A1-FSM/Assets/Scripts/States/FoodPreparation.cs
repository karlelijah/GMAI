using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPreparation : States
{
    private List<string> MeatList = new List<string>{"Tuna", "Chicken", "Beef"};
    private List<string> GreensList = new List<string>{"Fruits", "Vegetables"};
    public static List<string> MeatSelected = new List<string>{};
    public static List<string> GreensSelected = new List<string>{};
    
    private float timeRemaining = 10.0f; //Amount of time for the bot to prepare the food
    public FoodPreparation(BOT statemachine)
    {
        fsm = statemachine;
    }

    public override void Enter()
    {
        Debug.Log("Entered FOODPREPARATION State");
        //Start Duration of the preparing Food
        fsm.StartCoroutine(Coroutine_Preparefood(timeRemaining));
    }
    public override void Exit()
    {
        Debug.Log("Exiting FOODPREPARATION State");
    }
    IEnumerator Coroutine_Preparefood(float duration)
    {
        if(fsm.OwnerReturned) //Check if the owner has returned
        {
            Debug.Log("The owner has returned.");
            fsm.SetCurrentState(StateTypes.RETURN);
        }
        else
        {
            Debug.Log("Preparing food...");
            float dt = 0.0f;
            //Start timer for preparing food
            while(dt < duration)
            {
                yield return new WaitForSeconds(1.0f);
                dt += 1.0f;
            }
            SelectFood();
            Feed.foodPrepared = true;
            Debug.Log("The pet has been prepared. BOT heading to the Feeding Station.");
            //Once food is prepared at the Food Store, head back to the feeding station to give the food to the pet
            fsm.SetCurrentState(StateTypes.FEED);
        }       
    }
    private void SelectFood()
    {
        MeatSelected.Clear(); //Clear the list so that there is only item at a time
        GreensSelected.Clear(); //Clear the list so that there is only item at a time

        int randomNumber1 = Random.Range(1,3); //Randomize a number from 1 to 3
        int randomNumber2 = Random.Range(1,2); //Randomize a number from 1 to 2
        MeatSelected.Add(MeatList[randomNumber1]); //Add the random meat into the list
        GreensSelected.Add(GreensList[randomNumber2]); //Add the random greens into the list

        foreach(var x in MeatSelected) //Print out the Meat Selected
        {
            Debug.Log("Bot has selected " + x.ToString());
        }
        foreach(var x in GreensSelected) //Print out the Greens Selected
        {
            Debug.Log("Bot has selected " + x.ToString());
        }
    }
}
