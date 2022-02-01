using AP.ProgrammerGame.Logic;
using UnityEngine;

namespace AP.ProgrammerGame.Hacks
{
    public class AddingMoneyHack : MonoBehaviour
    {
        private void Update()
        {
#if UNITY_EDITOR

            if (Input.GetKeyDown(KeyCode.Alpha1))
                Wallet.Instance.ChangeMoneyCount(10);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                Wallet.Instance.ChangeMoneyCount(100);
            if (Input.GetKeyDown(KeyCode.Alpha3))
                Wallet.Instance.ChangeMoneyCount(1000);

#endif
        }
    }
}