using UnityEngine;

namespace Towers.ArcherTower
{
    public class ArcherTowerManager : MonoBehaviour, ITowerBase
    {
        private int _level=-1;

        [SerializeField] private ArcherTower[] towers;
        [SerializeField] private Construction construction;

        // Start is called before the first frame update
        void Start()
        {
            foreach (var tower in towers)
            {
                tower.TowerSetDeActive();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UpdateLevel();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Destructible();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Building();
            }
        }

        public void UpdateLevel()
        {
            if (_level >= 2) return;
            _level++;
            construction.TowerSetActive();
            if (construction.active)
            {
                construction.SetAnimator(_level);
                foreach (var tower in towers)
                {
                    tower.TowerSetDeActive();
                }
            }

            towers[_level].TowerSetActive();
        }

        public void Destructible()
        {
            foreach (var tower in towers)
            {
                tower.TowerSetDeActive();
            }

            _level = -1;
        }

        public void Building()
        {
            _level = -1;
            UpdateLevel();
        }
    }
}