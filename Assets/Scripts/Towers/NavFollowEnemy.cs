using UnityEngine;

namespace Towers
{
    public class NavFollowEnemy : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private Transform player;

        [SerializeField] private Rigidbody2D rb;
        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {
            var lookDir = (Vector2) player.position - rb.position;
            var angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
            rb.rotation = angle-180f;
            lookDir.Normalize();
        }

        private void FollowEnemy()
        {
            
        }
    }
}