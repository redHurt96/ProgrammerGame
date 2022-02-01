using System.Collections;
using System.Collections.Generic;
using AP.ProgrammerGame_v2;
using AP.ProgrammerGame_v2.Logic;
using UnityEngine;

public class AddingMoneyHack : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Wallet.Instance.ChangeMoneyCount(10);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Wallet.Instance.ChangeMoneyCount(100);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Wallet.Instance.ChangeMoneyCount(1000);
    }
}
