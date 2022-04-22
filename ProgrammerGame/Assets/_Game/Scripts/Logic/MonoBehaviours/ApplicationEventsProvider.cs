using _Game.Common;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.MonoBehaviours
{
    public class ApplicationEventsProvider : MonoBehaviour
    {
        private GlobalEventsService _globalEvents;

        private void Start() => 
            _globalEvents = Services.Instance.Single<GlobalEventsService>();

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
                _globalEvents.InvokeOnApplicationPause();
        }

        private void OnApplicationQuit() => 
            _globalEvents.InvokeOnApplicationPause();
    }
}