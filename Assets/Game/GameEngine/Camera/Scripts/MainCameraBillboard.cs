using Game.GameEngine.LocationServices;
using UnityEngine;
using Zenject;

namespace Game.GameEngine.Camera
{
    public class MainCameraBillboard : MonoBehaviour
    {
        private CameraService _cameraService;
        private UnityEngine.Camera _mainCamera;
        
        [Inject]
        private void Construct(CameraService cameraService)
        {
            _cameraService = cameraService;
        }

        private void Start()
        {
            _mainCamera = _cameraService.MainCamera;
        }

        private void Update()
        {
            LookAtCamera();
        }

        private void LookAtCamera()
        {
            var rootPosition = transform.position;
            
            if (ReferenceEquals(_mainCamera, null))
                return;

            var cameraRotation = _mainCamera.transform.rotation;
            var cameraVector = cameraRotation * Vector3.forward;
            var worldUp = cameraRotation * Vector3.up;
            transform.LookAt(rootPosition + cameraVector, worldUp);
        }        
    }
}