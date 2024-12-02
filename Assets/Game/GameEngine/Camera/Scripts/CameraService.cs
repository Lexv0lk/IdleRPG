using UnityEngine;

namespace Game.GameEngine.LocationServices
{
    public class CameraService : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera _mainCamera;
        
        public UnityEngine.Camera MainCamera => _mainCamera;
    }
}