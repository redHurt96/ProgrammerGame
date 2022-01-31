using System;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class Furniture : MonoBehaviour
    {
        internal void Enable() => gameObject.SetActive(true);
        internal void Disable() => gameObject.SetActive(false);
    }
}