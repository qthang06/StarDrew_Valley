using UnityEngine;
using System.Collections.Generic;

public abstract class GameEventSO<T> : ScriptableObject
{
    private readonly List<IGameEventListener<T>> listeners = new();
    public void Raise(T value)
    {
        for(int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(value);
        }
    }

    public void Subscribe(IGameEventListener<T> listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }
    public void UnSubscribe(IGameEventListener<T> listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
}