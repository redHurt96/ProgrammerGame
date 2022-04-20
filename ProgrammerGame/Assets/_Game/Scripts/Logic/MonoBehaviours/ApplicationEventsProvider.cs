using _Game.Common;
using UnityEngine;

namespace _Game.Logic.MonoBehaviours
{
    public class ApplicationEventsProvider : MonoBehaviour
    {
        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
                GlobalEvents.Instance.InvokeOnApplicationPause();
        }

        private void OnApplicationQuit() => 
            GlobalEvents.Instance.InvokeOnApplicationPause();
    }
}