using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookClosed : BookState
{
    private readonly readable stateManager;
    public BookClosed(readable stateManager)
    {
        this.stateManager = stateManager;
    }

    public override void HandleInput(object o)
    {
        if(o is string)
        {
            string input = (string)o;
            if (input == "Interact") TransitionTo(stateManager.BookOpened);
        }
    }

    public override BookState Enter()
    {
        base.Enter();
        stateManager.CloseBook();

        return this;
    }

    public override void TransitionTo(BookState transitionTo)
    {
        stateManager.CurrentState = transitionTo.Enter();
    }
}
