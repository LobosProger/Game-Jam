using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GeneralFunctions
{

}

public class GameAction
{
    public Action action;

    public GameAction() { }

    public GameAction(Action action)
    {
        this.action = action;
    }

    public void Invoke()
    {
        if(action != null)
            action.Invoke();
    }

    public static GameAction operator +(GameAction left, GameAction right)
    {
        return new GameAction(left.action + right.action);
    }

    public static GameAction operator +(GameAction left, Action right)
    {
        return new GameAction(left.action + right);
    }
}