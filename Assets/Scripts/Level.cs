using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
	public Transform memberPrefab;
	public Transform enemyPrefab;
	public Transform scaventurePrefab;

	public int numberOfMembers;
	public int numberOfEnemies;
	public int numberOfScaventures;

	public List<Member> members;
	public List<Enemy> enemies;
	public List<Scaventure> scaventures;

	public float bounds;
	public float spawnRadius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		members = new List<Member>();
		enemies = new List<Enemy>();
		scaventures = new List<Scaventure>();

		Spawn(memberPrefab, numberOfMembers);
		Spawn(enemyPrefab, numberOfEnemies);
		Spawn(scaventurePrefab, numberOfScaventures);

		members.AddRange(FindObjectsOfType<Member>());
		enemies.AddRange(FindObjectsOfType<Enemy>());
		scaventures.AddRange(FindObjectsOfType<Scaventure>());
    }

	void Spawn(Transform prefab, int count)
	{
		for(int i = 0; i < count; i++)
		{
			Instantiate(prefab, new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius), 0), Quaternion.identity);
		}
	}

	public List<Member> GetNeighbors(Member member, float radius)
	{
		List<Member> neighborFound = new List<Member>();

		foreach (var othermember in members)
		{
			if (othermember == member) {continue;}
			if (Vector3.Distance(member.position, othermember.position) <= radius)
			{
				neighborFound.Add(othermember);
			}
		}

		return neighborFound;
	}

	public List<Enemy> GetEnemies(Member member, float radius)
	{
		List<Enemy> returnEnemies = new List<Enemy>();
		foreach(var enemy in enemies)
		{
			if(Vector3.Distance(member.position, enemy.position) <= radius)
			{
				returnEnemies.Add(enemy);
			}
		}

		return returnEnemies;
	}
}
