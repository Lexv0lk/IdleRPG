/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;

namespace Atomic.Entities
{
    public static class TagAPI
    {
        ///Keys
        public const int Hero = 1;
        public const int Enemy = 2;


        ///Extensions
        public static bool HasHeroTag(this IEntity obj) => obj.HasTag(Hero);
        public static bool NotHeroTag(this IEntity obj) => !obj.HasTag(Hero);
        public static bool AddHeroTag(this IEntity obj) => obj.AddTag(Hero);
        public static bool DelHeroTag(this IEntity obj) => obj.DelTag(Hero);

        public static bool HasEnemyTag(this IEntity obj) => obj.HasTag(Enemy);
        public static bool NotEnemyTag(this IEntity obj) => !obj.HasTag(Enemy);
        public static bool AddEnemyTag(this IEntity obj) => obj.AddTag(Enemy);
        public static bool DelEnemyTag(this IEntity obj) => obj.DelTag(Enemy);
    }
}
