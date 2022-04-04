using System;
using System.Collections;
using RH.Utilities.Coroutines;
using UnityEngine;

namespace _Game.Logic.Data
{
    public class RunProjectProcess
    {
        public event Action<RunProjectProcess> Finished;

        public ProjectData ProjectData;

        private Coroutine _coroutine;

        public RunProjectProcess(ProjectData projectData)
        {
            ProjectData = projectData;
        }

        public void Run() => 
            _coroutine = CoroutineLauncher.Start(RunProject());

        private IEnumerator RunProject()
        {
            float time = 0f;

            while (time < ProjectData.Time)
            {
                yield return null;

                time += Time.deltaTime;

                ProjectData.SetTime(time);
            }

            CompleteProcess();
        }

        private void CompleteProcess()
        {
            ProjectData.CompleteProcess();
            Finished?.Invoke(this);
        }

#if UNITY_EDITOR
        public void Test_ForceComplete()
        {
            CoroutineLauncher.Stop(_coroutine);
            CompleteProcess();
        }
#endif
    }
}