﻿using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Upgrades
{
    [Serializable]
    public class DamageUpgradeTable
    {
        [SerializeField] private int _baseDamage;
        [SerializeField] private int _damageStep;
        
        [ListDrawerSettings(
            IsReadOnly = true,
            OnBeginListElementGUI = "DrawLevel"
        )]
        [SerializeField]
        private int[] _table;
        
        public int DamageStep => _damageStep;

        public int GetDamage(int level)
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
            _table[0] = _baseDamage;

            for (var i = 1; i < maxLevel - 1; i++)
                _table[i] = _baseDamage + _damageStep * i;
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