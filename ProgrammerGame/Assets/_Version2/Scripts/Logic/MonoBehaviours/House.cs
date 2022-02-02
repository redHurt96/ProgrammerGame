using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class House : MonoBehaviour
    {
        [SerializeField] private FurnitureSlot[] _defaultFurniture;
        [SerializeField] private FurnitureSlot[] _slots;
    }
}