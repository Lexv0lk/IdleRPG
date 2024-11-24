using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Inventory
{
    [Serializable]
    public class InventoryItemMetadata
    {
        [SerializeField, PreviewField] private Sprite _icon;
        [SerializeField] private string _title;
        [SerializeField, TextArea] private string _description;

        public Sprite Icon => _icon;
        public string Title => _title;
        public string Description => _description;
    }
}