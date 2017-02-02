using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public Vector3 launchVeclocity;
	public bool inPlay = false; // this is in order to forbid influencing the ball after its launch

	private Vector3 ballStartPos;
	private Rigidbody rigidBody;
	private AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>(); // Do this a lot in Unity 5
		rigidBody.useGravity = false;
		ballStartPos = transform.position;
	}
	
	public void Launch (Vector3 velocity) // this function is called in BallDragLaunch script and
        //velocity is determined by the direction and strength of a tap or mouse click
	{
		inPlay = true;

		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;

		audioSource = GetComponent<AudioSource> ();
		audioSource.Play ();
	}

	public void Reset () {
		inPlay = false;
		transform.position = ballStartPos;
		transform.rotation = Quaternion.identity;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;
	}
}
