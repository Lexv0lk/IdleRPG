using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Meta.Quests
{
    [Serializable]
    public class QuestMetadata
    {
        [SerializeField] private string _title;
        [SerializeField, TextArea] private string _description;
        [SerializeField, PreviewField] private Sprite _icon;

        public string Title => _title;
        public string Description => _description;
        public Sprite Icon => _icon;
    }
}