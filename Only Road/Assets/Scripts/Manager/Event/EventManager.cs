using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public delegate void EventReceiver(params object[] parameters);
    static Dictionary<NameEvent, EventReceiver> _events = new Dictionary<NameEvent, EventReceiver>();

    public enum NameEvent
    {
        Gameover,
        ApplyMultipliers,
        ChangeSoundEffect
    }

    public static void Subscribe(NameEvent eventType, EventReceiver listener)
    {
        if (!_events.ContainsKey(eventType))
            _events.Add(eventType, listener);
        else
            _events[eventType] += listener;
    }

    public static void Unsubscribe(NameEvent eventType, EventReceiver listener)
    {
        if (_events.ContainsKey(eventType))
        {
            _events[eventType] -= listener;

            if (_events[eventType] == null)
                _events.Remove(eventType);
        }
    }

    public static void Trigger(NameEvent eventType, params object[] parameters)
    {
        if (_events.ContainsKey(eventType))
            _events[eventType](parameters);
    }
}
