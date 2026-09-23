using UnityEngine;
using System;
using UnityEngine.Events;

[Serializable]
public class UnityIntEvent : UnityEvent<int> { }
public class IntEventListener : MonoBehaviour, IGameEventListener<int>
{
    [SerializeField] private IntEventSO gameEvent;
    [SerializeField] private UnityIntEvent response;

    private void OnEnable()
    {
        if(gameEvent != null)
        {
            gameEvent.Subscribe(this);
        }
    }
    private void OnDisable()
    {
        if(gameEvent != null)
        {
            gameEvent.UnSubscribe(this);
        }
    }

    public void OnEventRaised(int value)
    {
        response?.Invoke(value);
    }
}
