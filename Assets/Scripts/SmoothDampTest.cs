using UnityEngine;
using System.Collections;

public class SmoothDampTest : MonoBehaviour
{
	public Transform ToFollow;

	public float SmoothTime = 1.0f;

	Vector3 velocity;

	void FixedUpdate ()
	{
		Vector3 DestinationPosition = ToFollow.position + Vector3.back * 10.0f;

		transform.position = Vector3.SmoothDamp (
			transform.position, DestinationPosition, ref velocity, SmoothTime);
	}
}
