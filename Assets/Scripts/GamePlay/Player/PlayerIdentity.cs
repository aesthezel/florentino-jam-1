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
	PlayerHealth playerHealth;


	private void Awake()
    {
        playerIdentityVariable.Value = this;
    }

	public void Damage(float value)
	{
		playerHealth.ChangeHealth(-value);
	}
}
