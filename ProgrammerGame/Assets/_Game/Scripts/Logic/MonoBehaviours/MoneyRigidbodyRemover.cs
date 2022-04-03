using System.Collections;
using _Game.Configs;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class MoneyRigidbodyRemover : MonoBehaviour
    {
        private static WaitForSeconds _waitForSeconds;

        private IEnumerator Start()
        {
            InitYieldInstruction();

            yield return _waitForSeconds;

            Destroy(GetComponent<Rigidbody>());
            Destroy(this);
        }

        private static void InitYieldInstruction() => 
            _waitForSeconds ??= new WaitForSeconds(Settings.Instance.MoneyRigidbodyRemoveTime);
    }
}