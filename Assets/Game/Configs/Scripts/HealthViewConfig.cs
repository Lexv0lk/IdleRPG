using Game.Configs;
using UnityEngine;

namespace Game.Configs
{
    [CreateAssetMenu(fileName = "Health View Config", menuName = "Configs/Health View", order = 0)]
    public class HealthViewConfig : ScriptableObject, IConfig
    {
        [SerializeField] private float _maximalIdleItem = 2;
        
        public float MaximalIdleItem => _maximalIdleItem;
    }
}