using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RH.HyperCasualUtilities.GlobalEventsSystem
{
    public static class GlobalEvents
    {
        private static Dictionary<string, UnityEvent> _listeners = new Dictionary<string, UnityEvent>();

        public static void Subscribe(string toEvent, UnityAction listener)
        {
            if (_listeners.ContainsKey(toEvent))
            {
                _listeners[toEvent].AddListener(listener);
            }
            else
            {
                var newEvent = new UnityEvent();
                _listeners.Add(toEvent, newEvent);
            }
        }

        public static void Unsubscribe(string fromEvent, UnityAction listener)
        {
            if (_listeners.ContainsKey(fromEvent))
            {
                _listeners[fromEvent].RemoveListener(listener);
                TryRemoveEvent(fromEvent);
            }
            else
            {
                ThrowNoEventError(fromEvent);
            }
        }

        public static void UnsubscribeAll(string fromEvent)
        {
            if (_listeners.ContainsKey(fromEvent))
                _listeners.Remove(fromEvent);
            else
                ThrowNoEventError(fromEvent);
        }

        public static void Invoke(string eventName)
        {
            if (_listeners.ContainsKey(eventName))
                _listeners[eventName].Invoke();
            else
                ThrowNoEventError(eventName);
        }

        private static void TryRemoveEvent(string fromEvent)
        {
            if (_listeners[fromEvent].GetPersistentEventCount() == 0)
                _listeners.Remove(fromEvent);
        }

        private static void ThrowNoEventError(string eventName) => 
            Debug.LogError($"There is no listeners attached to {eventName}");
    }
}