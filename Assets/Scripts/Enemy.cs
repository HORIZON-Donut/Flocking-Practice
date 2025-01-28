using UnityEngine;

public class Enemy : Member
{
	override protected Vector3 Combine()
	{
		return conf.wadnerPriority * Wander();
	}
}
