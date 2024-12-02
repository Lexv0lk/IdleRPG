using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    public class HeroService : MonoBehaviour
    {
        [SerializeField] private SceneEntity _hero;

        public IEntity Hero => _hero;
    }
}