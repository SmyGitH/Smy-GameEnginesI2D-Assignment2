using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    protected GameManager2 m_gameManager;

    public GameState(GameManager2 gm){
        m_gameManager = gm;
    }

    public abstract void StateEnter();
    public abstract void StateExit();
    public abstract void StateUpdate();
}
