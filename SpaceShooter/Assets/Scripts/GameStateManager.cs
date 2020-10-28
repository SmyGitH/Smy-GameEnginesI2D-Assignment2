using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
   
   public StateGamePlaying stateGamePlaying {get; set;}
   public StateGameWon stateGameWon {get; set;}
   public StateGameLost stateGameLost {get; set;}

   private GameState currentState;

   private void Awake() {
       stateGamePlaying = new StateGamePlaying(this);
       stateGameWon = new StateGameWon(this);
       stateGameLost = new StateGameLost(this);
   }

   public void NewGameState(GameState newState){
       if (currentState != null){
           currentState.StateExit();
       }

       currentState = newState;
       currentState.StateEnter();
   }

   private void Update() {
       if(Input.GetKeyDown(KeyCode.J)){
           NewGameState(stateGamePlaying);
       }

       if(Input.GetKeyDown(KeyCode.K)){
           NewGameState(stateGameWon);
       }

       if(Input.GetKeyDown(KeyCode.L)){
           NewGameState(stateGameLost);
       }


       if(currentState != null){
           currentState.StateUpdate();
       }

       
   }
}
