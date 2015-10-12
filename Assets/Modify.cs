using UnityEngine;
using System.Collections;

public class Modify : MonoBehaviour
{
	
	Vector2 rot;
	public Texture2D crosshairImage;

	public GameObject blockParticles;

	void Start () {
		Cursor.visible = false;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.forward,out hit, 5 ))
			{
				if (hit.collider.gameObject.tag == "Enemy") {
					hit.collider.gameObject.GetComponent<fleshgolem_AI>().takeDamage(20);
				}
				else{
					Instantiate(blockParticles, hit.point, blockParticles.transform.rotation);
					Terrain.setBlock(hit, new BlockAir());
				}
			}

			Debug.DrawRay(transform.position, transform.forward, Color.red);
		}
		
		rot= new Vector2(
			rot.x + Input.GetAxis("Mouse X") * 3,
			rot.y + Input.GetAxis("Mouse Y") * 3);
		
		transform.localRotation = Quaternion.AngleAxis(rot.x, Vector3.up);
		transform.localRotation *= Quaternion.AngleAxis(rot.y, Vector3.left);
	}

	void OnGUI () {
		float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
		float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
	}
}