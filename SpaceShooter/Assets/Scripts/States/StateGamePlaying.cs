
using UnityEngine;

public class StateGamePlaying : GameState
{
    EnemyPool enemyPool;
    public StateGamePlaying(GameManager2 gm) : base(gm) {
        enemyPool = GameObject.Find("EnemyPool").GetComponent<EnemyPool>();
    }

    public override void StateEnter(){
      
    }

     public override void StateExit(){
        
    }

     public override void StateUpdate(){
         if(Input.GetKeyDown(KeyCode.H)){
             GameObject temp = enemyPool.GetEnemy();
             temp.transform.position = new Vector2(Random.Range(-2,2), Random.Range(-2,2));
             temp.SetActive(true);
         }
        
    }
}
