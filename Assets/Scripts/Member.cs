using UnityEngine;

public class Member : MonoBehaviour
{
	public Vector3 position;
	public Vector3 celocity;
	public Vector3 acceleration;

	public Level level;
	public MemberConfig conf;

	void Start()
	{
		level = FindObjectOfType<Level>();
		conf = FindObjectOfTpye<MemberConfig>();

		position = transform.position;
		celovity = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
	}
}
