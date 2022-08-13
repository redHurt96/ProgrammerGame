using System.Collections;
using _Game.Configs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class MoneyRigidbodyRemover : MonoBehaviour
    {
        private static WaitForSeconds _waitForSeconds;
        private Settings _settings;

        private IEnumerator Start()
        {
            _settings = Services.Get<Settings>();
            
            InitYieldInstruction();

            yield return _waitForSeconds;

            Destroy(GetComponent<Rigidbody>());
            Destroy(this);
        }

        private void InitYieldInstruction() => 
            _waitForSeconds ??= new WaitForSeconds(_settings.MoneyRigidbodyRemoveTime);
    }
}