using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Modules.Input
{
    public class SwipeInput : IInitializable, IDisposable
    {
        private DefaultControls _controls;
        
        public event Action<Vector2> DirectionMoved;

        public SwipeInput(DefaultControls controls)
        {
            _controls = controls;
        }

        public void Initialize()
        {
            //TODO: Relocate enabling
            _controls.CharacterMap.Enable();
            
            _controls.CharacterMap.MoveAction.performed += OnMoveActionPerformed;
        }

        private void OnMoveActionPerformed(InputAction.CallbackContext context)
        {
            var dir = context.ReadValue<Vector2>();
            DirectionMoved?.Invoke(dir.normalized);
        }

        public void Dispose()
        {
            _controls.CharacterMap.MoveAction.performed -= OnMoveActionPerformed;
        }
    } 
}