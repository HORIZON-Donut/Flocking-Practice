using UnityEngine;

public class Level: MonoBehaviour
{
	public Transform memberPrefab;
	public Transform enemyPrefab;
	public int numberOfMembers;
	public int numberOfEnemies;
	public List<Member> members;
	public List<Enemy> enemy;
	public float bounds;
	public float spawnRadius;

	private void Start()
	{
		members = new List<Member>();
		enemy = new List<Enemy>();

		Spawn(memberPrefab, numberOfMembers);
		Spawn(enemyPrefab, numberOfEnemies);
	}

	void Spawn(Transform prefab, int count)
	{
		for(int i = 0; i < count; i++)
		{
			Instantiate(prefab, new Vector3(Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius)), Quaternion.indentity);
		}
	}
}
