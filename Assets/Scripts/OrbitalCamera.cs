using UnityEngine;

public class OrbitalCamera : MonoBehaviour {
	[SerializeField]
	Vector3 lookAtPosition;

	[SerializeField]
	float radius = 10f;
	[SerializeField]
	float height = 10f;
	[SerializeField]
	float rotateSpeedInRps = 0.05f;

	// Update is called once per frame
	void Update() {
		float rotateSpeed = rotateSpeedInRps * 2 * Mathf.PI;
		Vector3 offset = new Vector3(radius * Mathf.Cos(rotateSpeed * Time.time), height, radius * Mathf.Sin(rotateSpeed * Time.time));

		transform.position = lookAtPosition + offset;
		transform.rotation = Quaternion.LookRotation(-offset, Vector3.up);
	}
}
