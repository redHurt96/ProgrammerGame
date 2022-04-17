using System;
using System.Collections.Generic;
using _Game.Configs;
using RH.Utilities.Saving;

namespace _Game.Data
{
    public class TutorialData : ISavableData
    {
        public string Key => "Tutorial";

        public List<TutorialStep> Steps = new List<TutorialStep>();
    }
}