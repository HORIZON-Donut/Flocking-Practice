using UnityEngine;

public class Enemy : Member
{
	override protected Vector3 Combine()
	{
		return conf.wanderPriority * Wander();
	}
}
