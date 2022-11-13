using RH.Utilities.Extensions;
using UnityEngine;

namespace _Game.UI.UpgradesTab
{
    public class MaxUpgradesButtonsHider : MaxUpgradesInteractor
    {
        [SerializeField] private GameObject[] _buttons;

        protected override void UpdateTipVisibility() =>
            _buttons.ForEach(x => x.SetActive(!IsMaxLevelReached()));
    }
}