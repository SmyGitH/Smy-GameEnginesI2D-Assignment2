using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    protected GameStateManager m_gameManager;

    public GameState(GameStateManager gm){
        m_gameManager = gm;
    }

    public abstract void StateEnter();
    public abstract void StateExit();
    public abstract void StateUpdate();
}
