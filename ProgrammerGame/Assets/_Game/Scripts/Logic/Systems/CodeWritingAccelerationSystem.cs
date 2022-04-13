using _Game.Common;
using _Game.Configs;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class CodeWritingAccelerationSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.OnCodingAccelerated += Accelerate;

        public override void Dispose() => 
            GlobalEvents.OnCodingAccelerated -= Accelerate;

        private void Accelerate()
        {
            GameData.Instance.CodeWritingProgress = 
                Mathf.Min(GameData.Instance.CodeWritingProgress + Settings.Instance.AccelerationCodeProgressPercent, 1f);
            GlobalEvents.WriteCode();
        }
    }
}