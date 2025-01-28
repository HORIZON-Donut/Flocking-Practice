using UnityEngine;

public class Scaventure: Member
{
	override protected Vector3 Combine()
	{
		return conf.wanderPriority * Wander();
	}
}
