﻿using System;
using Atomic.Entities;
using Game.GameEngine.Atomic.Behaviours;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public class HeroVisualInstaller : IEntityInstaller
    {
        [SerializeField] private GameObject _weaponObject;
        
        public void Install(IEntity entity)
        {
            entity.AddBehaviour(new WeaponToggleBehaviour(_weaponObject));
        }
    }
}