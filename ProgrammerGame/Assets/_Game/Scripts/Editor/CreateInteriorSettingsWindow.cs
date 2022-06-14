using System.Linq;
using _Game.Configs;
using UnityEditor;
using UnityEngine;

namespace _Game.Editor
{
    public class CreateInteriorSettingsWindow : EditorWindow
    {
        private PcSettings _pcSettings;
        private RoomSettings[] _roomsSettings = new RoomSettings[6];
        private InteriorSettings _targetInteriorSettings;

        [MenuItem("🎮 Game/🏠 Create interior settings")]
        private static void Init() => 
            GetWindow<CreateInteriorSettingsWindow>()
                .Show();

        private void OnGUI()
        {
            _pcSettings = (PcSettings) EditorGUILayout.ObjectField("PC settings", _pcSettings,
                typeof(PcSettings));
            
            for (int i = 0; i < 6; i++)
                _roomsSettings[i] =
                    (RoomSettings) EditorGUILayout.ObjectField($"Room {i + 1}", _roomsSettings[i], typeof(RoomSettings));

            _targetInteriorSettings = (InteriorSettings) EditorGUILayout.ObjectField("Target interior settings", _targetInteriorSettings,
                typeof(InteriorSettings));

            if (GUILayout.Button("Create from rooms"))
                CreateSettings();
        }

        private void CreateSettings()
        {
            _targetInteriorSettings.DefaultFurniture =
                _roomsSettings[0].DefaultFurniture
                    .Select(x => x.Furniture)
                    .Concat(_pcSettings.DefaultFurniture
                        .Select(x => x.Furniture))
                    .ToArray();

            for (int i = 0; i < _roomsSettings.Length; i++)
            {
                if (i != 0) 
                    AddDefaultAsToPurchase(i);

                AddInterior(i);
                AddPc(i);
            }
            
            AddPc(6);
            
            EditorUtility.SetDirty(_targetInteriorSettings);
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        private void AddDefaultAsToPurchase(int i)
        {
            _targetInteriorSettings.FurnitureForPurchase.Add(new FurnitureSlot2
            {
                FurnitureToStand = _roomsSettings[i]
                    .DefaultFurniture
                    .Select(x => x.Furniture)
                    .Concat(_roomsSettings[i]
                        .ProgrammerSpots
                        .Select(x => x.Spot))
                    .ToArray(),
                FurnitureToRemove = _roomsSettings[i]
                    .DefaultFurniture
                    .SelectMany(x => x.ReplacingTypes)
                    .ToArray(),
            });
        }

        private void AddInterior(int i)
        {
            foreach (FurnitureSlot furnitureSlot in _roomsSettings[i].FurnitureForPurchase)
                _targetInteriorSettings
                    .FurnitureForPurchase
                    .Add(FurnitureSlot2.CreateFrom(furnitureSlot));
        }

        private void AddPc(int i)
        {
            foreach (FurnitureSlot pcSettings in _pcSettings.FurnitureForPurchase.Where(x => x.Name.StartsWith($"{i}")))
                _targetInteriorSettings
                    .FurnitureForPurchase
                    .Add(FurnitureSlot2.CreateFrom(pcSettings));
        }
    }
}