using UnityEngine;

public class IAGenerator : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject iaPrefab;

	[Header("Spawn Settings")]
	[SerializeField] private Transform [] spawnPoints;
	[SerializeField] private int spawnCount;
	
	//Cache
	Transform spawnPoint;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		GenerateIA();
    }

	public void GenerateIA() 
	{
        
        for (int i = 0; i < spawnCount; i++)
        {
			spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

			Instantiate(iaPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
