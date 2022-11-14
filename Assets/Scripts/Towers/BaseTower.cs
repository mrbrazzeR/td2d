using Towers.ArcherTower;
using UnityEngine;
using Utils;

namespace Towers
{
    public class BaseTower:MonoBehaviour, ITower
    {
        [SerializeField] protected float attackRate;
        [SerializeField] protected float attackRange;
        [SerializeField] protected Transform attackPoint;

        [SerializeField] protected Animator animator;

        [SerializeField] protected Archer archer;
        private GameObject _target;
        private GameObject[] _enemies;
        private GameObject _nearestEnemy;
        

        // Start is called before the first frame update
        protected virtual void Start()
        {
            _target = null;
        }

        protected virtual void OnEnable()
        {
            InvokeRepeating($"Attack", 0f, attackRate);
        }

        protected virtual void OnDisable()
        {
            CancelInvoke();
        }
        public virtual void Attack()
        {
            _enemies = GameObject.FindGameObjectsWithTag(TagUtils.EnemyTag);
            var shortestDistance = Mathf.Infinity;

            _nearestEnemy = null;
            foreach (var enemy in _enemies)
            {
                var distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance && distanceToEnemy <= attackRange)
                {
                    shortestDistance = distanceToEnemy;
                    if (_nearestEnemy == null)
                    {
                        _nearestEnemy = enemy;
                    }
                }
            }

            if (_nearestEnemy != null)
            {
                archer.FollowEnemy(_nearestEnemy);
                animator.SetTrigger(AnimationUtils.Attack);
            }

        }

        private void OnDrawGizmosSelected()
        {
            if (attackPoint == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
            if (_target == null) return;
            Gizmos.DrawLine(transform.position, _target.transform.position);
        }


        public void TowerSetActive()
        {
            gameObject.SetActive(true);
        }

        public void TowerSetDeActive()
        {
            gameObject.SetActive(false);
        }
    }
}