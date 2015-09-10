using UnityEngine;
using System.Collections;

public class Modify : MonoBehaviour {

	Vector2 rot;

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit, 100)) {
				Terrain.SetBlock (hit, new BlockAir ());
			}
		}

		rot = new Vector2 (
			rot.x + Input.GetAxis ("Mouse X") * 3,
			rot.y + Input.GetAxis ("Mouse Y") * 3);

		transform.localRotation = Quaternion.AngleAxis (rot.x, Vector3.up);
		transform.localRotation *= Quaternion.AngleAxis (rot.y, Vector3.left);

		transform.position += transform.forward * 3 * Input.GetAxis ("Vertical");
		transform.position += transform.right * 3 * Input.GetAxis ("Horizontal");

	}

}
