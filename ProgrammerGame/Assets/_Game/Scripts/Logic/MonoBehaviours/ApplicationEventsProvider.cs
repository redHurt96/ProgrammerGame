using _Game.Common;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.MonoBehaviours
{
    public class ApplicationEventsProvider : MonoBehaviour
    {
        private GlobalEvents _events;

        private void OnApplicationPause(bool pauseStatus)
        {
            _events ??= Services.Get<GlobalEvents>();

            _events.InvokeOnApplicationPause(pauseStatus);

            if (pauseStatus)
                _events.InvokeOnApplicationPause();
        }

        private void OnApplicationQuit() => 
            _events.InvokeOnApplicationPause(true);
    }
}