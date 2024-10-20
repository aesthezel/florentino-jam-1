using System;
using GamePlay.Player.SO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using VG.IA;

namespace Gameplay.IA
{
    public class EnemyAI : AstarIA
    {
        public PlayerIdentityVariable player;
        public IAVision attackVision;
        public float attackSpeed = 3;

        private void OnEnable()
        {
            player.OnValueChanged += AddPlayer;
        }

        private void OnDisable()
        {
            player.OnValueChanged -= AddPlayer;
        }

        private void AddPlayer(PlayerIdentity playerIdentity)
        {
            destinationSetter.target = playerIdentity.transform;
        }

        public override void Start()
        {
            base.Start();
            destinationSetter.target = player.Value.transform;

        }

        public override bool HaveAttackTarget()
        {
            Debug.Log("Preguntando aqui");
            return attackVision.Objetive;
        }

        public override void Update()
        {
            base.Update();
            attackVision.UpdateVision();
        }
    }
}