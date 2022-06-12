using _Game.Common;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.MonoBehaviours
{
    public class ApplicationEventsProvider : MonoBehaviour
    {
        private EventsMediator _eventsMediator;

        private void OnApplicationPause(bool pauseStatus)
        {
            _eventsMediator ??= Services.Get<EventsMediator>();

            _eventsMediator.InvokeOnApplicationPause(pauseStatus);

            if (pauseStatus)
                _eventsMediator.InvokeOnApplicationPause();
        }

        private void OnApplicationQuit() => 
            _eventsMediator.InvokeOnApplicationPause(true);
    }
}