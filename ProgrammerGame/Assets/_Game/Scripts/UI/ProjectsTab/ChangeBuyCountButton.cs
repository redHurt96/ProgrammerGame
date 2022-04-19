using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ProjectsTab
{
    public class ChangeBuyCountButton : BaseActionButton
    {
        [SerializeField] private Text _text;

        private readonly int[] _counts = {1, 10, 100};

        private int _current = 0;

        private int _currentCount => _counts[_current];

        private void Awake() => 
            SetTitle();

        protected override void PerformOnClick()
        {
            _current++;
            _current %= _counts.Length;

            GameData.Instance.BuyCount = _currentCount;
            GlobalEvents.Instance.InvokeChangeBuyCountsEvent();

            SetTitle();
        }

        private void SetTitle() => 
            _text.text = "x" + _currentCount;
    }
}