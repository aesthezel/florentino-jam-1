using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace VG.IA
{
	public class EnemySpawner : IAGenerator
	{
		[SerializeField] private Transform[] randomSpawnPos;
		[SerializeField] private float spawnTime;

		//Cache
		private Transform randomPos;

		public override void Start()
		{
			GameController.OnStartedGame += StartSpawn;
			GameController.OnIncrementEnemy += IncrementEnemy;
		}

		private void IncrementEnemy()
		{
			spawnCount++;
		}

		public void StartSpawn() 
		{
			StartCoroutine(SpawnerCooldown());
		}

		public override void GenerateIA()
		{
			randomPos = randomSpawnPos[Random.Range(0, randomSpawnPos.Length)];

			SpawnIA(randomPos.position);
		}

		IEnumerator SpawnerCooldown()
		{
			yield return new WaitForSeconds(spawnTime);

            for (int i = 0; i < spawnCount; i++)
            {
				GenerateIA();
			}

			StartCoroutine(SpawnerCooldown());
		}
	}
}