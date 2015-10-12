using UnityEngine;
using System.Collections;

public class gameObjectNamer {
		
	public string name;
	public GameObject thisOject;
		
	public gameObjectNamer(string name, GameObject thisOject) {
		this.name = name;
		this.thisOject = thisOject;
	}
}
