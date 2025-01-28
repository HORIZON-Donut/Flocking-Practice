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
		level = FindFirstObjectByType<Level>();
		conf = FindFirstObjectByType<MemberConfig>();

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

	bool isInFOV(Vector3 vec)
	{
		return Vector3.Angle(this.velocity, vec - this.position) <= conf.maxFOV;
	}

	void Update()
	{
		//acceleration = Combine();
		acceleration = Alignment();
		acceleration = Vector3.ClampMagnitude(acceleration, conf.maxAcceleration);

		velocity = velocity + acceleration * Time.deltaTime;
		velocity = Vector3.ClampMagnitude(velocity, conf.maxVelocity);

		position = position + velocity * Time.deltaTime;
		WrapAround(ref position, -level.bounds, level.bounds);

		transform.position = position;
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

	virtual protected Vector3 Combine()
	{
		Vector3 finalVec = conf.cohesionPriority * Cohesion() + conf.wanderPriority * Wander();
		return finalVec;
	}

	Vector3 Cohesion()
	{
		Vector3 cohesionVector = new Vector3();
		int countMembers = 0;
		var neighbors = level.GetNeighbors(this, conf.cohesionRadius);
		if(neighbors.Count == 0)
		{
			return cohesionVector;
		}

		foreach(var member in neighbors)
		{
			if(isInFOV(member.position))
			{
				cohesionVector += member.position;
				countMembers++;
			}

		}

		if(countMembers == 0)
		{
			return cohesionVector;
		}

		cohesionVector /= countMembers;
		cohesionVector = cohesionVector - this.position;
		cohesionVector = Vector3.Normalize(cohesionVector);

		return cohesionVector;
	}

	Vector3 Alignment()
	{
		Vector3 alignVector = new Vector3();
		var members = level.GetNeighbors(this, conf.alignmentRadius);
		if(members.Count == 0)
			return alignVector;

		foreach(var member in members)
		{
			if(isInFOV(member.position))
				alignVector += member.velocity;
		}

		return alignVector.normalized;
	}
}
