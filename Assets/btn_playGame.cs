using UnityEngine;
using System.Collections;

public class btn_playGame : MonoBehaviour {

	private bool changeScene = false;
	
	//BUTTON SPRITES
	public Sprite Default;
	public Sprite Active;

	RaycastHit hit;
	Ray ray;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButton (0)) {
			//Vector3 touchPos = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			//RaycastHit hit;
			/*
			ray.origin = touchPos;
			ray.direction = 
			Physics.Raycast(ray, out hit);
			*/

			ray = Camera.main.ScreenPointToRay(Input.mousePosition);


			Physics.Raycast (ray, out hit, 100f);

			if (hit.collider != null) {
				if (hit.collider.gameObject.name == "playBtn") {
					this.GetComponent<SpriteRenderer>().sprite = Active;
					changeScene = true;
				}	                   
				else {
					this.GetComponent<SpriteRenderer>().sprite = Default;
					changeScene = false;
				}
			}
			else {
				this.GetComponent<SpriteRenderer>().sprite = Default;
				changeScene = false;
			}

			Debug.DrawRay(ray.origin, ray.direction * 40f, Color.red);
		} 
		else if (Input.GetMouseButtonUp (0)) {
			
			if (changeScene) {
				
				Application.LoadLevel ("AzamRealms");
			}
		}
	}
}
