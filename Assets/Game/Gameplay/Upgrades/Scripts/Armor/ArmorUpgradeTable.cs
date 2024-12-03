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
        
        [ReadOnly]
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
            var table = new int[maxLevel];

            if (maxLevel > 0)
            {
                table[0] = _baseArmor;

                for (var i = 1; i < maxLevel - 1; i++)
                    table[i] = _baseArmor + _armorStep * i;
            }

            _table = table;
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