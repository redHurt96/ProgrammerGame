using System.Linq;
using _Game.Configs;
using UnityEditor;
using UnityEngine;

namespace _Game.Scripts.Editor
{
    public class ChangeBalanceWindow : EditorWindow
    {
        private string _newPricesString;
        private string _newIncomesString;

        private int _projectsCount => Settings.Instance.ProjectsSettings.Length;

        [MenuItem("🎮 Game/💹 Change balance window")]
        static void Init()
        {
            ChangeBalanceWindow window = GetWindow<ChangeBalanceWindow>();
            window.Show();
        }

        void OnGUI()
        {
            GUILayout.Label("Prices", EditorStyles.boldLabel);

            _newPricesString = EditorGUILayout.TextField("Prices", _newPricesString);

            if (GUILayout.Button("Set new prices")) 
                SetNewPrices();
            
            GUILayout.Label("Incomes", EditorStyles.boldLabel);

            _newIncomesString = EditorGUILayout.TextField("Incomes", _newPricesString);

            if (GUILayout.Button("Set new incomes")) 
                SetNewIncomes();
        }

        private void SetNewPrices()
        {
            float[] coeffs = _newPricesString.Split(' ')
                .Select(float.Parse)
                .ToArray();
            ProjectSettings[] projects = Resources.LoadAll<ProjectSettings>("Projects");

            for (int i = 0; i < _projectsCount; i++)
            {
                projects[0].SetPrice(new PriceSettings
                {
                    _additional = coeffs[i],
                    _exponential = coeffs[i + 1],
                    _linear = coeffs[i + 2],
                    _offset = coeffs[i + 3],
                });
            }
        }

        private void SetNewIncomes()
        {
            float[] coeffs = _newIncomesString.Split(' ')
                .Select(float.Parse)
                .ToArray();
            ProjectSettings[] projects = Resources.LoadAll<ProjectSettings>("Projects");

            for (int i = 0; i < _projectsCount; i++)
            {
                projects[0].SetIncome(new PriceSettings
                {
                    _additional = coeffs[i],
                    _exponential = coeffs[i + 1],
                    _linear = coeffs[i + 2],
                    _offset = coeffs[i + 3],
                });
            }
        }
    }
}
