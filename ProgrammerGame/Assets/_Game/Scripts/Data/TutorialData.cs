using System;
using System.Collections.Generic;
using _Game.Configs;

namespace _Game.Data
{
    [Serializable]
    public class TutorialData
    {
        public List<TutorialStep> Steps = new List<TutorialStep>();
    }
}