using UnityEngine.Events;
using UnityEngine;
public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    public static UnityEvent EnemyDeath;
    public static UnityEvent GameLost;

    private void Awake()
    {
        instance = this;
    }
}
