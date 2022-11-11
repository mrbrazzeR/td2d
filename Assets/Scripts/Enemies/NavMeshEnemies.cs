using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class NavMeshEnemies : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField]private NavMeshAgent navMeshAgent;
        // Start is called before the first frame update
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.updateRotation = false;
            navMeshAgent.updateUpAxis = false;
        }

        // Update is called once per frame
        void Update()
        {
            navMeshAgent.SetDestination(target.position);
        }
    }
}
