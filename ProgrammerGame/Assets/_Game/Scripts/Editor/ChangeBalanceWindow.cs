using System;
using System.Linq;
using _Game.Configs;
using UnityEditor;
using UnityEngine;

namespace _Game.Scripts.Editor
{
    public class ChangeBalanceWindow : EditorWindow
    {
        private string _newPrices;
        private string _newIncomes;
        private string _newProgrammersPrices;

        private int _projectsCount => Resources.Load<Settings>("Settings").ProjectsSettings.Length;

        [MenuItem("🎮 Game/💹 Change balance window")]
        private static void Init()
        {
            ChangeBalanceWindow window = GetWindow<ChangeBalanceWindow>();
            window.Show();
        }

        private void OnGUI()
        {
            _newPrices = EditorGUILayout.TextField("Prices", _newPrices);

            if (GUILayout.Button("Set new prices")) 
                SetNewPrices();

            _newIncomes = EditorGUILayout.TextField("Incomes", _newIncomes);

            if (GUILayout.Button("Set new incomes")) 
                SetNewIncomes();

            _newProgrammersPrices = EditorGUILayout.TextField("Programmers prices", _newProgrammersPrices);

            if (GUILayout.Button("Set new programmers prices")) 
                SetNewProgrammersPrices();
        }

        private void SetNewProgrammersPrices()
        {
            float[] coeffs = ParseFromSheet(_newProgrammersPrices);
            ProgrammerSettings[] programmers = Resources.LoadAll<ProgrammerSettings>("Programmers");
            PriceSettings[] prices = ParseToPricesSettings(coeffs);

            for (int i = 0; i < programmers.Length; i++) 
                programmers[i].SetPrice(prices[i]);

            SetProgrammersDirty(programmers);
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

        private void SetProgrammersDirty(ProgrammerSettings[] programmers)
        {
            foreach (ProgrammerSettings programmer in programmers) 
                EditorUtility.SetDirty(programmer);

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }
        
        private void SetProjectsDirty(ProjectSettings[] projects)
        {
            foreach (ProjectSettings project in projects) 
                EditorUtility.SetDirty(project);

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }
    }
}
