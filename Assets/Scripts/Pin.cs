using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingThreshold = 3f; // remember if it is changed in inspector - it will
    //be overrided. Set value for all pins - select them all and type a new value in an Inspector
	public float distToRaise = 40f;

	private Rigidbody rigidBody;
	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

	}
	
	public bool IsStanding () {
		Vector3 rotationInEuler = transform.rotation.eulerAngles; // Nice method to determine the
        //rotation values of an object

		float tiltInX = Mathf.Abs(270 - rotationInEuler.x); // cause we need abs value regardless of the
        // sign like 8 degrees or -352 makes no difference
		float tiltInZ = Mathf.Abs(rotationInEuler.z);
        // x and z are enough
        // 270 we need after we changed the pins rotation parameters

		if (tiltInX < standingThreshold && tiltInZ < standingThreshold) {
			return true;
		} else {
			return false;
		}
	}

	public void RaiseIfStanding () {
		if (IsStanding ()) {
			rigidBody.useGravity = false;
			transform.Translate (new Vector3 (0, distToRaise, 0), Space.World);
			transform.rotation = Quaternion.Euler (270f, 0, 0);
		}
	}

	public void Lower () {
		transform.Translate (new Vector3 (0, -distToRaise, 0), Space.World);
		rigidBody.useGravity = true;
	}

}