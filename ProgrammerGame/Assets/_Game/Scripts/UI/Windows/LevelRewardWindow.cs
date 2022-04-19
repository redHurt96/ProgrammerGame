using _Game.Common;
using _Game.Scripts.Exception;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Windows
{
    public class LevelRewardWindow : BaseWindow
    {
        [SerializeField] private Text _reward;
        
        protected override void PerformBeforeOpen() => 
            _reward.text = GameDataPresenter.Instance.GetRewardForLevel().ToPriceString();
    }
}