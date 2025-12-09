using UnityEngine;

public class DollyCamera : MonoBehaviour {
	[SerializeField]
	Vector3 startPosition;
	[SerializeField]
	Vector3 endPosition;
	[SerializeField]
	Quaternion startRotation;
	[SerializeField]
	Quaternion endRotation;

	[SerializeField]
	float dollyDuration = 7f;

	// Update is called once per frame
	void Update() {
		float timeRate = Time.time / dollyDuration;
		float t = 1 - (timeRate - 1) * (timeRate - 1);
		if (timeRate > 1) {
			t = 1;
		}

		transform.position = Vector3.Lerp(startPosition, endPosition, t);
		transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
	}
}
