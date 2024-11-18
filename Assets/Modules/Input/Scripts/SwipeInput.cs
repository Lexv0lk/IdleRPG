using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Modules.Input
{
    public class SwipeInput : IInitializable, IDisposable
    {
        private DefaultControls _controls;
        private Vector2 _startPos;
        private Vector2 _currentPos;
        
        public event Action<Vector2> DirectionMoved;

        public SwipeInput(DefaultControls controls)
        {
            _controls = controls;
        }

        public void Initialize()
        {
            //TODO: Relocate enabling
            _controls.CharacterMap.Enable();
            
            _controls.CharacterMap.MoveAction.started += OnMoveActionStarted;
            _controls.CharacterMap.MoveAction.performed += OnMoveActionPerformed;
        }

        private void OnMoveActionStarted(InputAction.CallbackContext context)
        {
            _startPos = context.ReadValue<Vector2>();
        }

        private void OnMoveActionPerformed(InputAction.CallbackContext context)
        {
            _currentPos = context.ReadValue<Vector2>();
            DirectionMoved?.Invoke((_currentPos - _startPos).normalized);
        }

        public void Dispose()
        {
            _controls.CharacterMap.MoveAction.started -= OnMoveActionStarted;
            _controls.CharacterMap.MoveAction.performed -= OnMoveActionPerformed;
        }
    } 
}