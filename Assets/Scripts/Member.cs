using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Member : MonoBehaviour
{
	public Vector3 position;
	public Vector3 velocity;
	public Vector3 acceleration;

	public Level level;
	public MemberConfig conf;

	private Vector3 wanderTarget;

	void Start()
	{
		level = FindObjectOfType<Level>();
		conf = FindObjectOfType<MemberConfig>();

		position = transform.position;
		velocity = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
	}

	void WrapAround(ref Vector3 vector, float min, float max)
	{
		vector.x = WrapAroundFloat(vector.x, min, max);
		vector.y = WrapAroundFloat(vector.y, min, max);
		vector.z = WrapAroundFloat(vector.z, min, max);
	}

	float WrapAroundFloat(float value, float min, float max)
	{
		if (value > max) {value = min;}
		else if (value < min) {value = max;}

		return value;
	}

	float RandomBinomail()
	{
		return Random.Range(0f, 1f) - Random.Range(0f, 1f);
	}

	void Update()
	{
		//
	}

	protected Vector3 Wander()
	{
		
		float jitter = conf.wanderJitter * Time.deltaTime;
		wanderTarget += new Vector3(RandomBinomail() * jitter, RandomBinomail() * jitter, 0);
		wanderTarget = wanderTarget.normalized;
		wanderTarget *= conf.wanderRadius;

		Vector3 targetInLocalSpace = wanderTarget + new Vector3(0, conf.wanderDistance, 0);
		Vector3 targetInWorldSpace = transform.TransformPoint(targetInLocalSpace);
		targetInWorldSpace -= this.position;

		return targetInWorldSpace.normalized;
	}
}
