using UnityEngine.Events;
using UnityEngine;
public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    public UnityEvent EnemyDeath;
    public UnityEvent GameLost;
    public UnityEvent EnemyArrivedToDestination;

    private void Awake()
    {
        instance = this;
    }

    public void InvokeOnGameLost()
    {
        GameLost.Invoke();
    }
}
