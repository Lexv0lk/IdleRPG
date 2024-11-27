using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Upgrades
{
    [Serializable]
    public class ArmorUpgradeTable
    {
        [SerializeField] private int _baseArmor;
        [SerializeField] private int _armorStep;
        
        [ListDrawerSettings(
            IsReadOnly = true,
            OnBeginListElementGUI = "DrawLevel"
        )]
        [SerializeField]
        private int[] _table;
        
        public int ArmorStep => _armorStep;

        public int GetArmor(int level)
        {
            return _table[level - 1];
        }

        public void OnValidate(int maxLevel)
        {
            EvaluateTable(maxLevel);
        }

        private void EvaluateTable(int maxLevel)
        {
            _table = new int[maxLevel];
            _table[0] = _baseArmor;

            for (var i = 1; i < maxLevel - 1; i++)
                _table[i] = _baseArmor + _armorStep * i;
        }

#if UNITY_EDITOR
        private void DrawLevel(int index)
        {
            GUILayout.Space(8);
            GUILayout.Label($"Level {index + 1}");
        }
#endif
    }
}