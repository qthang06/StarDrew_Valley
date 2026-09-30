using System;
using System.Collections.Generic;

public class GameEventBus
{
    private readonly Dictionary<Type, Delegate> subcribers = new();
    public void Subcribe<T>(Action<T> callback)
    {
        Type eventType = typeof(T);
        if (subcribers.ContainsKey(eventType))
        {
            subcribers[eventType] = Delegate.Combine(subcribers[eventType], callback);
        }
        else
        {
            subcribers[eventType] = callback;
        }
    }
    public void UnSubcribe<T>(Action<T> callback)
    {
        Type eventType = typeof(T);
        if (subcribers.ContainsKey(eventType))
        {
            subcribers[eventType] = Delegate.Remove(subcribers[eventType], callback);
        }
    }
    public void Publish<T>(T eventData)
    {
        Type eventType = typeof(T);
        if(subcribers.TryGetValue(eventType, out Delegate handler))
        {
            (handler as Action<T>)?.Invoke(eventData);
        }
    }
}
