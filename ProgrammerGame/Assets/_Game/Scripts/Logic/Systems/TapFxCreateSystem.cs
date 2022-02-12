using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AP.ProgrammerGame.Logic
{
    public class TapFxCreateSystem : IDisposable
    {
        private readonly Camera _camera;

        public TapFxCreateSystem()
        {
            _camera = Camera.main;
            GlobalEvents.OnCodingAccelerated += CreateFx;
        }

        public void Dispose() => GlobalEvents.OnCodingAccelerated -= CreateFx;

        private void CreateFx()
        {
            Vector3 position = Input.mousePosition - new Vector3(Screen.width / 2f, Screen.height / 2f, 0f); 
            GameObject fx = Object.Instantiate(Settings.Instance.TapFxPrefab, SceneObjects.Instance.FxCanvas);
            fx.transform.localPosition = position;
            Object.Destroy(fx, 1f);
        }
    }
}