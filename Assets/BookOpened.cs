using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpened : BookState
{
    private readonly readable stateManager;
    public BookOpened(readable stateManager)
    {
        this.stateManager = stateManager;
    }

    public override void HandleInput(object o)
    {
        if (o is string)
        {
            string input = (string)o;
            if (input == "Interact") TransitionTo(stateManager.BookClosed);
            if (input == "Close") TransitionTo(stateManager.BookClosed);
        }
    }

    public override BookState Enter()
    {
        base.Enter();
        stateManager.OpenBook();

        return this;
    }

    public override void TransitionTo(BookState transitionTo)
    {
        stateManager.CurrentState = transitionTo.Enter();
    }
}
