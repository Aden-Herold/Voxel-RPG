using UnityEngine;
using System.Collections;

public class fleshgolem_Spawner : MonoBehaviour {

	private bool spawnReady = true;
	private ArrayList golems = new ArrayList();
	public GameObject golemPrefab;
	public int maxGolemsAllowed = 3;

	private int counter = 1;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (spawnReady) {
			if (golems.Count < maxGolemsAllowed) {
				spawnReady = false;
				gameObjectNamer newGolem = new gameObjectNamer(("golem"+counter), (Instantiate (golemPrefab, this.transform.position, golemPrefab.transform.rotation) as GameObject));
				golems.Add (newGolem);

				newGolem.thisOject.GetComponent<fleshgolem_AI>().golemSpawner = this.GetComponent<fleshgolem_Spawner>();
				newGolem.thisOject.GetComponent<fleshgolem_AI>().setGolemSpawnerRef(newGolem);

				StartCoroutine(spawnCooldown());
			}
		}
	}

	public void removeFromList(gameObjectNamer golem) {

		golems.Remove (golem);
	}

	IEnumerator spawnCooldown() {
		yield return new WaitForSeconds (10);
		spawnReady = true;
	}
}
