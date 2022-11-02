using Assets.Scripts;
using System;
using UnityEngine;

public class Game : MonoBehaviour
{

    public MovementSnake MovementSnake;
    public enum State
    {
        Playing,
        Won,
        Loss
    }

    public State CarrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CarrentState != State.Playing) return;

        CarrentState = State.Loss;
        MovementSnake.enabled = false;
        Debug.Log("Game Over");
        {

        }
    }

    public void OnPlayerReachedFinish()
    {
        if (CarrentState != State.Playing) return;
        CarrentState = State.Won;
        MovementSnake.enabled = false;
        Debug.Log("You won!");

    }
}
