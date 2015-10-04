using UnityEngine;
using System.Collections;
using System;
using System.Threading;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]


[Serializable]
public class Chunk : MonoBehaviour {

	MeshFilter filter;
	MeshCollider coll;

	public Block[ , , ] blocks = new Block[chunkSize, chunkSize, chunkSize];
	public static int chunkSize = 16;
	public bool update = false;

	public World world;
	public WorldPos pos;

	public bool rendered;

	// Use this for initialization
	void Start () {
	
		filter = gameObject.GetComponent<MeshFilter> ();
		coll = gameObject.GetComponent<MeshCollider> ();
	}

	void Update()
	{
		if (update) {
			update = false;
			updateChunk ();
		}
	}

	public void setBlocksUnmodified()
	{
		foreach (Block block in blocks) 
		{
			block.changed = false;
		}
	}

	//Return block at specified 3 dimensional position
	public Block getBlock (int x, int y, int z)
	{
		if (inRange(x) && inRange(y) && inRange(z))
		{
			return blocks[x, y, z];
		}

		return world.getBlock (pos.x + x, pos.y + y, pos.z + z);
	}

	public void setBlock (int x, int y, int z, Block block)
	{
		if (inRange(x) && inRange(y) && inRange(z))
		{
			blocks[x, y, z] = block;
		}
		else
		{
			world.setBlock (pos.x + x, pos.y + y, pos.z + z, block);
		}
	}

	public static bool inRange (int index)
	{
		if (index < 0 || index >= chunkSize) 
		{
			return false;
		}

		return true;
	}

	//Update the chunk based on its contents
	void updateChunk()
	{
		rendered = true;
		MeshData meshData = new MeshData ();

		for (int x = 0; x < chunkSize; x++) 
		{
			for (int y = 0; y < chunkSize; y++) 
			{
				for (int z = 0; z < chunkSize; z++) 
				{
					meshData = blocks[x, y, z].blockData(this, x, y, z, meshData);
				}
			}
		}

		renderMesh (meshData);
	}

	//Sends the calculated mesh information to the mesh and collision components
	void renderMesh(MeshData meshData) 
	{
		filter.mesh.Clear ();
		filter.mesh.vertices = meshData.vertices.ToArray ();
		filter.mesh.triangles = meshData.triangles.ToArray ();

		filter.mesh.uv = meshData.uv.ToArray ();
		filter.mesh.RecalculateNormals ();

		coll.sharedMesh = null;
		Mesh mesh = new Mesh ();
		mesh.vertices = meshData.colVertices.ToArray ();
		mesh.triangles = meshData.colTriangles.ToArray ();
		mesh.RecalculateNormals ();

		coll.sharedMesh = mesh;
	}
}
