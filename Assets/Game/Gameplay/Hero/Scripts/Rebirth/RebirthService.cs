using UnityEngine;

namespace Game.Gameplay.Hero
{
    public class RebirthService : MonoBehaviour
    {
        [SerializeField] private RebirthView _rebirthView;
        [SerializeField] private Transform _rebirthLocation;

        public RebirthView RebirthView => _rebirthView;
        public Transform RebirthLocation => _rebirthLocation;
    }
}