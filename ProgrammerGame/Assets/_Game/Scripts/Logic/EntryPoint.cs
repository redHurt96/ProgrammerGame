using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Settings _settings;

        private void Start()
        {
            _settings.CreateInstance();
            new Wallet();
        }
    }
}