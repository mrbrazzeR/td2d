using System;
using UnityEngine;
using Utils;

namespace Enemies
{
    public class EnemyMoving : MonoBehaviour
    {
        [SerializeField] private MovingType movingType;
        [SerializeField] private Animator _animator;
        private void OnCollisionEnter2D(Collision2D other)
        {
            _animator = other.gameObject.GetComponent<Animator>();
            switch (movingType)
            {
                case MovingType.Down:
                    _animator.SetBool(AnimationUtils.Down, true);
                    _animator.SetBool(AnimationUtils.Up, false);
                    _animator.SetBool(AnimationUtils.Left, false);
                    break;
                case MovingType.Left:
                    _animator.SetBool(AnimationUtils.Down, false);
                    _animator.SetBool(AnimationUtils.Up, false);
                    _animator.SetBool(AnimationUtils.Left, true);
                    break;
                case MovingType.Up:
                    _animator.SetBool(AnimationUtils.Down, false);
                    _animator.SetBool(AnimationUtils.Up, true);
                    _animator.SetBool(AnimationUtils.Left, false);
                    break;
                case MovingType.Right:
                    _animator.SetBool(AnimationUtils.Down, false);
                    _animator.SetBool(AnimationUtils.Up, false);
                    _animator.SetBool(AnimationUtils.Left, true);
                    gameObject.transform.Rotate(new Vector3(0, 0, 180));
                    break;
            }
            Debug.Log("test");
        }
    }
}