using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class MeshData {

	//Rendering - this allows us to render object at the specified locations
	public List<Vector3> vertices = new List<Vector3>();
	public List<int> triangles = new List<int>();

	//List of the texture coordinates
	public List<Vector2> uv = new List<Vector2>();

	//Collisions - this allows us to render collision mesh at the specified locations
	public List<Vector3> colVertices = new List<Vector3>();
	public List<int> colTriangles = new List<int>();
	public bool useRenderDataForCol;

	public MeshData()
	{
	}

	public void AddQuadTriangles ()
	{
		triangles.Add (vertices.Count - 4);
		triangles.Add (vertices.Count - 3);
		triangles.Add (vertices.Count - 2);
		
		triangles.Add (vertices.Count - 4);
		triangles.Add (vertices.Count - 2);
		triangles.Add (vertices.Count - 1);

		if (useRenderDataForCol) 
		{
			colTriangles.Add (colVertices.Count - 4);
			colTriangles.Add (colVertices.Count - 3);
			colTriangles.Add (colVertices.Count - 2);

			colTriangles.Add (colVertices.Count - 4);
			colTriangles.Add (colVertices.Count - 2);
			colTriangles.Add (colVertices.Count - 1);

		}
	}

	public void addVertex (Vector3 vertex)
	{
		vertices.Add (vertex);

		if (useRenderDataForCol) {
			colVertices.Add (vertex);
		}
	}

	public void addTriangle (int tri)
	{
		triangles.Add (tri);

		if (useRenderDataForCol) {
			colTriangles.Add (tri - (vertices.Count - colVertices.Count));
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
