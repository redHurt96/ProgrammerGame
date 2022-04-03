using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TapFxCreateSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.OnCodingAccelerated += CreateFx;

        public override void Dispose() => 
            GlobalEvents.OnCodingAccelerated -= CreateFx;

        private void CreateFx()
        {
            Vector3 position = Input.mousePosition - new Vector3(Screen.width / 2f, Screen.height / 2f, 0f); 
            GameObject fx = Object.Instantiate(Settings.Instance.TapFxPrefab, SceneObjects.Instance.FxCanvas);
            fx.transform.localPosition = position;
            Object.Destroy(fx, 1f);
        }
    }
}