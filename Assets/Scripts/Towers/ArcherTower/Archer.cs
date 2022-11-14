using UnityEngine;

namespace Towers.ArcherTower
{
    public class Archer : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private GameObject bulletPrefab;
        private GameObject _nearestEnemy;
        [SerializeField] private Transform firePoint;

        private void Start()
        {
            firePoint = transform;
        }

        public void FollowEnemy(GameObject nearestEnemy)
        {
            _nearestEnemy = nearestEnemy;
            var lookDir = (Vector2) nearestEnemy.transform.position - rb.position;
            var angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
            rb.rotation = angle - 180f;
            lookDir.Normalize();
        }

        public void AddBullet()
        {
            var bullet = Instantiate(bulletPrefab, firePoint);
            var component = bullet.GetComponent<Projectile>();
            if (component != null)
            {
                component.Seek(_nearestEnemy);
            }
        }
    }
}