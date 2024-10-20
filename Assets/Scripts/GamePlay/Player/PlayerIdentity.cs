using System;
using GamePlay.Player.SO;
using GamePlay.Teams;
using UnityEngine;

public class PlayerIdentity : MonoBehaviour, ITeam
{
    [field: SerializeField]
    public ScriptableEnumTeam Team { get; private set; }
    [SerializeField]
    private PlayerIdentityVariable playerIdentityVariable = null;
    
    private void Awake()
    {
        playerIdentityVariable.Value = this;
    }
}
