using SystemCollections;
using SystemCollecttions.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
	public Transform memberPrefab;
	public Transform enemyPrefab;

	public int numberOfMembers;
	public int numberOfEnemies;

	public List<Member> members;
	public List<Enemy> enemies;

	public float bounds;
	public float spawnRadius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		members = new List<Member>();
		enemies = new List<Enemy>();

		Spawn(memberPrefab, numberOfMembers);
		Spawn(enemyPrefab, numberOfEnemies);
    }

	void Spawn(Transform prefab, int count)
	{
		for(int i = 0; i < count; i++)
		{
			Instantiate(prefab, new Vector3(Random.Range(-spawnnRadius, spawnRadius), 0, Random.Range(-spawnnRadius, spawnRadius)), Quaterniom.identity);
		}
	}
}
