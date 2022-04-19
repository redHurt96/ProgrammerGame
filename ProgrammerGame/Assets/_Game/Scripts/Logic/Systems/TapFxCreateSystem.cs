using _Game.Common;
using _Game.Configs;
using _Game.Fx;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TapFxCreateSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.OnTapForMoney += CreateFx;

        public override void Dispose() => 
            GlobalEvents.OnTapForMoney -= CreateFx;

        private void CreateFx(string value)
        {
            Vector3 position = Input.mousePosition - new Vector3(Screen.width / 2f, Screen.height / 2f, 0f); 
            PriceFx fx = Object.Instantiate(Settings.Instance.TapFxPrefab, SceneObjects.Instance.FxCanvas);
            fx.SetPrice(value);
            fx.transform.localPosition = position;
            Object.Destroy(fx.gameObject, 1f);
        }
    }
}