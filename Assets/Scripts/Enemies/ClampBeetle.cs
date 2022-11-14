using UnityEngine;
using Utils;

namespace Enemies
{
    public class ClampBeetle: Enemy, IEnemy
    {
        public ClampBeetle()
        {
            health = 50;
            enemyType = EnemyType.Flying;
           
        }
        
    }
}