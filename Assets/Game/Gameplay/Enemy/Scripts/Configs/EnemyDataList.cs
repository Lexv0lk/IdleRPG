using System.Collections.Generic;
using Game.Configs;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    [CreateAssetMenu(fileName = "Enemy Data List", menuName = "Enemies/Enemies List", order = 1)]
    public class EnemyDataList : ScriptableObject, IConfig
    {
        [SerializeField] private EnemyData[] _enemies;

        public IReadOnlyCollection<EnemyData> Enemies => _enemies;
    }
}