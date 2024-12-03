using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    [Serializable]
    public class EnemyMetadata
    {
        [SerializeField] private string _name;
        [SerializeField, PreviewField] private Sprite _icon;

        public string Name => _name;
        public Sprite Icon => _icon;
    }
}