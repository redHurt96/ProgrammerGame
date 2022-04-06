using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Time settings", menuName = "Game/Time settings", order = 0)]
    public class TimeSettingsScriptable : ScriptableObject
    {
        [SerializeField] private long _startTime;
        [SerializeField] private long _endDecreasingLevel;
        [SerializeField] private long _endTime;

        private float _linear => -(_startTime - _endTime) / (float)_endDecreasingLevel;

        public long GetTime(int level) => 
            level < _endDecreasingLevel ? (long) (_startTime + _linear * level) : _endTime;

        public void SetTo(TimeSettings settings)
        {
            settings._startTime = _startTime;
            settings._endDecreasingLevel = _endDecreasingLevel;
            settings._endTime = _endTime;
        }
    }
}