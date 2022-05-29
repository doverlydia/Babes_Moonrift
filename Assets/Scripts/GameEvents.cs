using UnityEngine.Events;
using UnityEngine;
public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    public UnityEvent EnemyDeath;
    public UnityEvent GameLost;

    private void Awake()
    {
        instance = this;
    }
}
