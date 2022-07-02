using System;
using UnityEditor;
using UnityEngine;

namespace _Game.Debug.GameServices
{
    public static class AdsMocSettings
    {
        private const string IS_INTERSTITIAL_READY_KEY = "debug_is_interstitial_ready";
        private const string IS_REWARDED_READY_KEY = "debug_is_rewarded_ready";
        private const string IS_BANNER_SHOWN_KEY = "debug_is_rewarded_ready";

        public static bool IsInterstitialReady => PlayerPrefs.HasKey(IS_INTERSTITIAL_READY_KEY) && PlayerPrefs.GetInt(IS_INTERSTITIAL_READY_KEY) == 1;
        public static bool IsRewardedReady => PlayerPrefs.HasKey(IS_REWARDED_READY_KEY) && PlayerPrefs.GetInt(IS_REWARDED_READY_KEY) == 1;
        public static bool IsBannerShown => PlayerPrefs.HasKey(IS_BANNER_SHOWN_KEY) && PlayerPrefs.GetInt(IS_BANNER_SHOWN_KEY) == 1;

#if UNITY_EDITOR
        [MenuItem("🎮 Game/🎞 Adv/ Toggle interstitial")]
        private static void ToggleInterstitial() => 
            ToggleSettingsValue(IS_INTERSTITIAL_READY_KEY, () => IsInterstitialReady);

        [MenuItem("🎮 Game/🎞 Adv/ Toggle rewarded")]
        private static void ToggleRewarded() => 
            ToggleSettingsValue(IS_REWARDED_READY_KEY, () => IsRewardedReady);
        
        [MenuItem("🎮 Game/🎞 Adv/ Toggle banner")]
        private static void ToggleBanner() => 
            ToggleSettingsValue(IS_BANNER_SHOWN_KEY, () => IsBannerShown);

        private static void ToggleSettingsValue(string key, Func<bool> valueFunc)
        {
            int value = valueFunc.Invoke() ? 0 : 1;

            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();

            UnityEngine.Debug.Log($"[ADS_MOC] Set {key} to {value}");
        }
#endif
    }
}