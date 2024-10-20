using System;
using GamePlay.Player.SO;
using UnityEngine;

public class PlayerIdentity : MonoBehaviour
{
    [SerializeField]
    private PlayerIdentityVariable playerIdentityVariable = null;
    
    private void Awake()
    {
        playerIdentityVariable.Value = this;
    }
}
