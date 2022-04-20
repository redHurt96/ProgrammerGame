using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using _Game.Configs;
using UnityEditor;
using UnityEngine;

namespace _Game.Scripts.Editor
{
    public class ChangeBalanceWindow : EditorWindow
    {
        private string _newPrices;
        private string _newIncomes;
        private string _newTimers;

        private int _projectsCount => Resources.Load<Settings>("Settings").ProjectsSettings.Length;

        [MenuItem("🎮 Game/💹 Change balance window")]
        static void Init()
        {
            ChangeBalanceWindow window = GetWindow<ChangeBalanceWindow>();
            window.Show();
        }

        void OnGUI()
        {
            _newPrices = EditorGUILayout.TextField("Prices", _newPrices);

            if (GUILayout.Button("Set new prices")) 
                SetNewPrices();

            _newIncomes = EditorGUILayout.TextField("Incomes", _newIncomes);

            if (GUILayout.Button("Set new incomes")) 
                SetNewIncomes();

            _newTimers = EditorGUILayout.TextField("Timers", _newTimers);

            if (GUILayout.Button("Set new timers")) 
                SetNewTimers();
        }

        private void SetNewTimers()
        {
            float[] coeffs = ParseFromSheet(_newTimers);
            ProjectSettings[] projects = Resources.LoadAll<ProjectSettings>("Projects");
            TimeSettings[] timers = ParseToTimersSettings(coeffs);

            for (int i = 0; i < projects.Length; i++)
                projects[i].SetTime(timers[i]);

            SetProjectsDirty(projects);
        }

        private void SetNewPrices()
        {
            float[] coeffs = ParseFromSheet(_newPrices);
            ProjectSettings[] projects = Resources.LoadAll<ProjectSettings>("Projects");
            PriceSettings[] prices = ParseToPricesSettings(coeffs);

            for (int i = 0; i < projects.Length; i++)
                projects[i].SetPrice(prices[i]);

            SetProjectsDirty(projects);
        }

        private void SetNewIncomes()
        {
            float[] coeffs = ParseFromSheet(_newIncomes);
            ProjectSettings[] projects = Resources.LoadAll<ProjectSettings>("Projects");
            PriceSettings[] prices = ParseToPricesSettings(coeffs);

            for (int i = 0; i < projects.Length; i++)
                projects[i].SetIncome(prices[i]);

            SetProjectsDirty(projects);
        }

        private float[] ParseFromSheet(string input) =>
            input
                .Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(float.Parse)
                .ToArray();

        private PriceSettings[] ParseToPricesSettings(float[] coeffs)
        {
            PriceSettings[] prices = new PriceSettings[_projectsCount];

            for (int i = 0; i < _projectsCount; i++)
            {
                int startPosition = i * 4;

                prices[i] = new PriceSettings
                {
                    _offset = coeffs[startPosition],
                    _linear = coeffs[startPosition + 1],
                    _exponential = coeffs[startPosition + 2],
                    _additional = coeffs[startPosition + 3],
                };
            }

            return prices;
        }

        private TimeSettings[] ParseToTimersSettings(float[] coeffs)
        {
            TimeSettings[] timers = new TimeSettings[_projectsCount];

            for (int i = 0; i < _projectsCount; i++)
            {
                int startPosition = i * 3;

                timers[i] = new TimeSettings
                {
                    _startTime = (long) coeffs[startPosition],
                    _endTime = (long) coeffs[startPosition + 1],
                    _endDecreasingLevel = (long) coeffs[startPosition + 2],
                };
            }

            return timers;
        }

        private void SetProjectsDirty(ProjectSettings[] projects)
        {
            foreach (ProjectSettings project in projects) 
                EditorUtility.SetDirty(project);
        }
    }
}
