using UnityEngine;

namespace VG.IA
{
	public class IAGenerator : MonoBehaviour
	{
		[Header("Prefab")]
		[SerializeField] private GameObject iaPrefab;

		[Header("Spawn Settings")]
		[SerializeField] protected Transform spawnPoint;
		[SerializeField] protected int spawnCount;

		[Header("RandomPos Settings")]
		[SerializeField][Range(0.1f, 10f)] protected float randomPosOffset = 1;

		private Vector3 randomPos;

		public virtual void Start()
		{
            for (int i = 0; i < spawnCount; i++)
				GenerateIA();
		}

		public virtual void GenerateIA()
		{
			randomPos = CalculateRandomPos();
			SpawnIA(randomPos);
		}

		private Vector3 CalculateRandomPos()
		{
			float randomX = Random.Range(-randomPosOffset, randomPosOffset);
			float randomZ = Random.Range(-randomPosOffset, randomPosOffset);

			Vector3 randomPosition = new Vector3(randomX, spawnPoint.position.y, randomZ);
			return spawnPoint.position + randomPosition;
		}

		private GameObject SpawnIA(Vector3 pos)
		{
			GameObject spawnedIa = Instantiate(iaPrefab, pos, Quaternion.identity).gameObject;

			return spawnedIa;
		}

		private GameObject SpawnIA(Vector3 pos, Quaternion rot)
		{
			GameObject spawnedIa = Instantiate(iaPrefab, pos, rot).gameObject;

			return spawnedIa;
		}
	}
}