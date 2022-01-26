using AP.ProgrammerGame_v2.Logic;
using UnityEngine;

namespace AP.ProgrammerGame_v2
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Settings _settings;

        private void Awake()
        {
            _settings.CreateInstance();

            new GameData();
            new CodeWritingProcess();
            new Wallet();
            new CodeWritingAccelerator();
            new MoneyStorage();
        }
    }
}