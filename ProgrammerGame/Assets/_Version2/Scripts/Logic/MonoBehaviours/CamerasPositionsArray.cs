using Cinemachine;
using UnityEngine;

namespace AP.ProgrammerGame_v2.Logic
{
    public class CamerasPositionsArray : MonoBehaviour
    {
        public CinemachineVirtualCamera[] CamerasPerDeveloper;

        private void Start() => GlobalEvents.BuyDeveloperCompleted += UpdateCameraPosition;
        private void OnDestroy() => GlobalEvents.BuyDeveloperCompleted -= UpdateCameraPosition;

        private void UpdateCameraPosition()
        {
            for (int i = 0; i < CamerasPerDeveloper.Length; i++)
                CamerasPerDeveloper[i].Priority = i == GameData.Instance.PurchasedDevelopersCount ? 1 : 0;
        }
    }
}