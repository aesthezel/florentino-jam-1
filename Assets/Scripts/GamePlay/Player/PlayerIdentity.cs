using System;
using GamePlay.Player.SO;
using GamePlay.Teams;
using GamePlay.World;
using UnityEngine;

public class PlayerIdentity : MonoBehaviour, ITeam, IDamageable
{
    [field: SerializeField]
    public ScriptableEnumTeam Team { get; private set; }
    [SerializeField]
    private PlayerIdentityVariable playerIdentityVariable = null;

    [SerializeField]
	Health playerHealth;


	private void Awake()
    {
        playerIdentityVariable.Value = this;
		playerHealth.SetHealth(0, 100);

	}

	public void Damage(float value)
	{
		playerHealth.ChangeHealth(-value);

        if (playerHealth.Value <= 0)
        {
            GameController.EndGame();
            Destroy(gameObject);
        }
    }
}
