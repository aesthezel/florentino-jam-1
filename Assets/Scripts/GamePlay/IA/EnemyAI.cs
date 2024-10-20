using GamePlay.Player.SO;
using GamePlay.Teams;
using GamePlay.Weapons;
using UnityEngine;
using VG.IA;

namespace Gameplay.IA
{
    public class EnemyAI : AstarIA, ITeam
    {
        [field: SerializeField]
        public ScriptableEnumTeam Team { get; private set; }
        public PlayerIdentityVariable player;
        public IAVision attackVision;
        public Weapon enemyWeapon;
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
            return attackVision.Objetive;
        }

        public override void Update()
        {
            base.Update();
            attackVision.UpdateVision();
        }

        public void TryShoot()
        {
            enemyWeapon.Shoot();
        }

        public void RotateToTarget(Transform target)
        {
            transform.LookAt(target.position);
        }
    }
}