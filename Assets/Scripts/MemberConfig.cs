using UnityEngine;

public class MemberConfig : MonoBehaviour
{
	public float maxFOV = 180;
	public float maxAcceleration;
	public float maxVelocity;

	//Wander variable
	public float wanderJitter;
	public float wanderRadius;
	public float wanderDistance;
	public float wanderPriority;

	//Cohesuin variable
	public float cohesionRadius;
	public float cohesionPriority;

	//Alignment variable
	public float alignmentRadius;
	public float alignmentPriority;

	//Separate variable
	public float separationRadius;
	public float separationPriority;

	//Avoid variable
	public float avoidanceRadius;
	public float avoidancePriority;

}
