using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Meta.Upgrades
{
    [Serializable]
    public class UpgradePriceTable
    {
        [SerializeField] 
        private int _basePrice;

        [ReadOnly]
        [ListDrawerSettings(OnBeginListElementGUI = "DrawLevels")]
        [SerializeField] 
        private int[] _prices;
        
        public int GetPrice(int level)
        {
            int index = Mathf.Clamp(level - 1, 0, _prices.Length - 1);
            return _prices[index];
        }

        private void DrawLevels(int index)
        {
            GUILayout.Space(8);
            GUILayout.Label($"Level #{index + 1}");
        }
        
        public void OnValidate(int maxLevel)
        {
            EvaluatePriceTable(maxLevel);
        }

        private void EvaluatePriceTable(int maxLevel)
        {
            int[] table = new int[maxLevel];
            table[0] = 0;
            
            for (var level = 2; level <= maxLevel; level++)
                table[level - 1] = _basePrice * level;

            _prices = table;
        }
    }
}