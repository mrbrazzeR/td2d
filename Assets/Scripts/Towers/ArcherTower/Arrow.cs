
using UnityEngine;

namespace Towers.ArcherTower
{
    public class Arrow : Projectile
    {
        private void Awake()
        {
            Speed = 12f;
            Damage = 2;
            Target = null;
        }
    }
}