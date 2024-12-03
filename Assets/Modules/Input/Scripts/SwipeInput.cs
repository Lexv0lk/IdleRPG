using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;

namespace Modules.Input
{
    public class SwipeInput : IInitializable, ITickable, IDisposable
    {
        private DefaultControls _controls;
        private Vector2 _startPos;
        private Vector2 _currentPos;

        private bool _started;
        private bool _isPointerOverUI;
        
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
            _controls.CharacterMap.MoveAction.canceled += OnMoveActionCanceled;
        }
        
        public void Tick()
        {
            _isPointerOverUI = EventSystem.current.IsPointerOverGameObject();
        }

        private void OnMoveActionStarted(InputAction.CallbackContext context)
        {
            _startPos = context.ReadValue<Vector2>();
            _started = _isPointerOverUI == false;
        }

        private void OnMoveActionPerformed(InputAction.CallbackContext context)
        {
            if (_started == false)
                return;
            
            _currentPos = context.ReadValue<Vector2>();
            DirectionMoved?.Invoke((_currentPos - _startPos).normalized);
        }

        private void OnMoveActionCanceled(InputAction.CallbackContext context)
        {
            if (_started == false)
                return;

            _started = false;
            DirectionMoved?.Invoke(Vector2.zero);
        }

        public void Dispose()
        {
            _controls.CharacterMap.MoveAction.started -= OnMoveActionStarted;
            _controls.CharacterMap.MoveAction.performed -= OnMoveActionPerformed;
            _controls.CharacterMap.MoveAction.canceled -= OnMoveActionCanceled;
        }
    } 
}