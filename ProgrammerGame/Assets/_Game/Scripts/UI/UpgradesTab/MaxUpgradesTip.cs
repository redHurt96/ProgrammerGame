using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.UpgradesTab
{
    public class MaxUpgradesTip : MaxUpgradesInteractor
    {
        [SerializeField] private Text _tip;

        protected override void UpdateTipVisibility() => 
            _tip.gameObject.SetActive(IsMaxLevelReached());
    }
}