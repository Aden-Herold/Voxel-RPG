using UnityEngine;
using System.Collections;

public class Modify : MonoBehaviour
{
	
	Vector2 rot;
	public Texture2D crosshairImage;

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
				Terrain.setBlock(hit, new BlockAir());
			}
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