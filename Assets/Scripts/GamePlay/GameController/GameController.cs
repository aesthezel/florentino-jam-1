using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float incrementEnemyTime = 10;

    public static bool GameRunning;
    public static Action OnStartedGame;
    public static Action OnFinishedGame;

    public static Action OnIncrementEnemy;

    private float gameTime;

    void Start()
    {
        Debug.Log(gameObject.name);
    }

	private void Update()
	{
        gameTime += Time.deltaTime;

        if (gameTime>= incrementEnemyTime)
        {
            OnIncrementEnemy?.Invoke();
			gameTime = 0;
		}
    }

	public static void StartGame() 
    {
        OnStartedGame?.Invoke();
    }

    public static void EndGame() 
    {
        GameRunning = false;
		OnFinishedGame?.Invoke();
	}
}
