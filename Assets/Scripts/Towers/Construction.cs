using System;
using UnityEngine;
using Utils;

namespace Towers
{
    public class Construction:MonoBehaviour,ITower
    {
        [SerializeField]private Animator animator;
        public bool active;

        public void SetAnimator(int level)
        {
            animator.SetInteger(AnimationUtils.Level,level);
        }

        public void TowerSetActive()
        {
            gameObject.SetActive(true);
            active = true;
        }

        public void TowerSetDeActive()
        {
            gameObject.SetActive(false);
            active = false;
        }

    }
}