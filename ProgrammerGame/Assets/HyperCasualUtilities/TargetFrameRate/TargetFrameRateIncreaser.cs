using UnityEngine;

namespace AP.Utilities.TargetFrameRate
{
    public class TargetFrameRateIncreaser : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
            Destroy(gameObject);
        }
    }
}