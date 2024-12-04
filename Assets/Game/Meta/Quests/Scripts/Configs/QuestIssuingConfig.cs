using Game.Configs;
using UnityEngine;

namespace Game.Meta.Quests
{
    [CreateAssetMenu(fileName = "Quest Issuing Config", menuName = "Configs/Quest Issuing", order = 0)]
    public class QuestIssuingConfig : ScriptableObject, IConfig
    {
        [SerializeField] private int _questAmountToDisplay = 4;
        
        public int QuestAmountToDisplay => _questAmountToDisplay;
    }
}