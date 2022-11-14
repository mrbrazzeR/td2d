using System;
using UnityEngine;
using Utils;

namespace Enemies
{
    public class Enemy:MonoBehaviour
    {
        public Animator animator;
        public int health;
        public EnemyType enemyType;

        protected virtual void Awake()
        {
            animator = gameObject.GetComponent<Animator>();
        }
        
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                animator.SetTrigger(AnimationUtils.Die);
            }
        }
        
        public void DieAnimation()
        {
            gameObject.SetActive(false);
        }
    }
}