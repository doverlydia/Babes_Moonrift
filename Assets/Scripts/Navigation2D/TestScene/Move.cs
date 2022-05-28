using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Transform target;
    void Start()
    {
        GetComponent<NavMeshAgent2D>().destination = target.position;
    }
}