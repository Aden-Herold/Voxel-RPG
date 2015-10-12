using UnityEngine;
using System.Collections;

public class fleshgolem_Spawner : MonoBehaviour {

	private bool spawnReady = true;
	private ArrayList golems = new ArrayList();
	public GameObject golemPrefab;
	public int maxGolemsAllowed = 3;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (spawnReady) {
			if (golems.Count < maxGolemsAllowed) {
				spawnReady = false;
				GameObject newGolem = Instantiate (golemPrefab, this.transform.position, golemPrefab.transform.rotation) as GameObject;
				golems.Add (newGolem);

				StartCoroutine(spawnCooldown());
			}
		}
	}

	IEnumerator spawnCooldown() {
		yield return new WaitForSeconds (10);
		spawnReady = true;
	}
}
