using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BookState {


    public BookState() { }

    public virtual BookState Enter()
    {
        Debug.Log(string.Format("Entered State: {0}", this));
        return this;
    }

    public abstract void HandleInput(object o);

    public abstract void TransitionTo(BookState transitionTo);
}
