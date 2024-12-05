using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class UIOpenCloseController
    {
        private readonly HashSet<GameObject> _currentOpenElements = new();

        public event Action FirstElementOpened;
        public event Action AllElementsClosed;
        
        public void Open(GameObject uiElement)
        {
            if (_currentOpenElements.Add(uiElement))
            {
                uiElement.SetActive(true);
                
                if (_currentOpenElements.Count == 1)
                    FirstElementOpened?.Invoke();
            }
        }

        public void Close(GameObject uiElement)
        {
            if (_currentOpenElements.Remove(uiElement))
            {
                uiElement.SetActive(false);
                
                if (_currentOpenElements.Count == 0)
                    AllElementsClosed?.Invoke();
            }
        }
    }
}