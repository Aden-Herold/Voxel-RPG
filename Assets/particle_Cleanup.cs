using UnityEngine;
using System.Collections;

public class particle_Cleanup : MonoBehaviour {

	ParticleSystem particles;

	// Use this for initialization
	void Start () {
		particles = this.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (particles.isStopped) {
			Destroy(this.gameObject);
		}
	}
}
