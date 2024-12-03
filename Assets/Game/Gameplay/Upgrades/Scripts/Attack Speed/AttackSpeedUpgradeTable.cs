using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Upgrades
{
    [Serializable]
    public class AttackSpeedUpgradeTable
    {
        [SerializeField] private float _startSpeed;
        [SerializeField] private float _endSpeed;
        [ShowInInspector, ReadOnly] private float _speedStep;
        
        [ReadOnly]
        [ListDrawerSettings(
            IsReadOnly = true,
            OnBeginListElementGUI = "DrawLevel"
        )]
        [SerializeField]
        private float[] _table;
        
        public float SpeedStep => _speedStep;

        public float GetSpeed(int level)
        {
            return _table[level - 1];
        }

        public void OnValidate(int maxLevel)
        {
            EvaluateTable(maxLevel);
        }

        private void EvaluateTable(int maxLevel)
        {
            var table = new float[maxLevel];
            var speedStep = _speedStep;

            if (maxLevel > 0)
            {
                table[0] = _startSpeed;
                table[maxLevel - 1] = _endSpeed;

                speedStep = (_endSpeed - _startSpeed) / (maxLevel - 1);
                speedStep = (float)Math.Round(speedStep, 2);

                for (var i = 1; i < maxLevel - 1; i++)
                {
                    float speed = _startSpeed + speedStep * i;
                    table[i] = (float)Math.Round(speed, 2);
                }
            }

            _table = table;
            _speedStep = speedStep;
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