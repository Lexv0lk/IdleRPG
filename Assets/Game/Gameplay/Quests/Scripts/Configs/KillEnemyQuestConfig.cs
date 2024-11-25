using Game.Meta.Quests;
using UnityEngine;

namespace Game.Gameplay.Quests
{
    [CreateAssetMenu(fileName = "Kill Enemy Quest Config", menuName = "Quests/Kill Enemy", order = 0)]
    public class KillEnemyQuestConfig : QuestConfig
    {
        [SerializeField] private int _targetKills;

        public int TargetKills => _targetKills;
        
        public override Quest InstantiateQuest()
        {
            return new KillEnemyQuest(this);
        }
    }
}