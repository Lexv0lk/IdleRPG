using Game.Configs;
using UnityEngine;

namespace Game.Gameplay.Combat
{
    [CreateAssetMenu(fileName = "Dead Body Remove Config", menuName = "Configs/Dead Body Remove", order = 0)]
    public class DeadBodyRemoveConfig : ScriptableObject, IConfig
    {
        [SerializeField] private float _startDelay = 2;

        public float StartDelay => _startDelay;
    }
}