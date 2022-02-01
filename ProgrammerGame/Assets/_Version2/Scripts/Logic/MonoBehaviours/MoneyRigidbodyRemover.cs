using System.Collections;
using UnityEngine;

namespace AP.ProgrammerGame_v2.Logic
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