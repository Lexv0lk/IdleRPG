using System.Collections.Generic;
using Game.Gameplay.Enemy;
using Game.Meta.Quests;
using UnityEngine;

namespace Game.Gameplay.Quests
{
    [CreateAssetMenu(fileName = "Kill Enemy Quest Config", menuName = "Quests/Kill Enemy", order = 0)]
    public class KillEnemyQuestConfig : QuestConfig
    {
        [SerializeField] private int _targetKills;
        [SerializeField] private EnemyData _targetData;

        public int TargetKills => _targetKills;
        public EnemyData TargetData => _targetData;
        
        public override Quest InstantiateQuest()
        {
            return new KillEnemyQuest(this);
        }
    }
}