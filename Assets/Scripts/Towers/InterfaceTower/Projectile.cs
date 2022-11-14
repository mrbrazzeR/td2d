using Enemies;
using UnityEngine;

namespace Towers.BaseTower
{
    public class Projectile:MonoBehaviour
    {
        protected GameObject Target;
        protected float Speed;
        [SerializeField]protected Rigidbody2D rb;
        protected int Damage;

        
        public virtual void Update()
        {
            MovingBullet();
        }
        protected virtual void MovingBullet()
        {
            if (Target == null)
            {
                Destroy(gameObject);
                return;
            }

            var direction = Target.transform.position - transform.position;
            var distance = Speed * Time.deltaTime;
            if (direction.magnitude <= distance)
            {
                HitTarget();
                return;
            }

            transform.Translate(direction.normalized * distance, Space.World);
            FollowEnemy();
        }
        protected virtual void HitTarget()
        {
            Destroy(gameObject);
            Target.gameObject.GetComponent<IEnemy>().TakeDamage(Damage);
        }
        public virtual void Seek(GameObject target)
        {
            Target = target;
        }
        private void FollowEnemy()
        {
            var lookDir = (Vector2) Target.transform.position - rb.position;
            var angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
            rb.rotation = angle - 180f;
            lookDir.Normalize();
        }
    }
}