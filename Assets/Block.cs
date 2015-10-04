using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Block {

	const float tileSize = 0.25f;
	public bool changed = true;
	public struct Tile {public int x; public int y;}

	//Constructor
	public Block()
	{
	}

	//Denotes the type of texture used depending on the direction of the face
	public virtual Tile texturePosition (Direction direction)
	{
		Tile tile = new Tile ();
		tile.x = 2;
		tile.y = 0;
		
		return tile;
	}

	//Returns the mesh data for the block, ie. which sides are solid and should be built
	public virtual MeshData blockData (Chunk chunk, int x, int y, int z, MeshData meshData)
	{
		meshData.useRenderDataForCol = true;

		if (!chunk.getBlock (x, y + 1, z).isSolid (Direction.up)) {
			meshData = FaceDataUp (chunk, x, y, z, meshData);
		}

		if (!chunk.getBlock (x, y - 1, z).isSolid (Direction.down)) {
			meshData = FaceDataDown (chunk, x, y, z, meshData);
		}

		if (!chunk.getBlock (x, y, z + 1).isSolid (Direction.north)) {
			meshData = FaceDataNorth (chunk, x, y, z, meshData);
		}

		if (!chunk.getBlock (x, y, z - 1).isSolid (Direction.south)) {
			meshData = FaceDataSouth (chunk, x, y, z, meshData);
		}

		if (!chunk.getBlock (x + 1, y, z).isSolid (Direction.east)) {
			meshData = FaceDataEast (chunk, x, y, z, meshData);
		}

		if (!chunk.getBlock (x - 1, y, z).isSolid (Direction.west)) {
			meshData = FaceDataWest (chunk, x, y, z, meshData);
		}

		return meshData;
	}

	//                                                                         FaceDataUp        FaceDataDown
	//Vertices must be plotted in a clockwise direction.                          - z                + z
	//When plotting the vertices, the view direction must be considered        +x _|_ -x          +x _|_ -x 
	//as the axis will rotate with the view.                                       |                  |
	//                                                                            + z                - z

	protected virtual MeshData FaceDataUp (Chunk chunk, int x, int y, int z, MeshData meshData)
	{
		meshData.addVertex (new Vector3 (x - 0.5f, y + 0.5f, z + 0.5f));
		meshData.addVertex(new Vector3 (x + 0.5f, y + 0.5f, z + 0.5f));
		meshData.addVertex (new Vector3 (x + 0.5f, y + 0.5f, z - 0.5f));
		meshData.addVertex (new Vector3 (x - 0.5f, y + 0.5f, z - 0.5f));

		meshData.AddQuadTriangles ();

		meshData.uv.AddRange (FaceUVs (Direction.up));

		return meshData;
	}
	
	protected virtual MeshData FaceDataDown (Chunk chunk, int x, int y, int z, MeshData meshData)
	{
		meshData.addVertex (new Vector3 (x - 0.5f, y - 0.5f, z - 0.5f));
		meshData.addVertex (new Vector3 (x + 0.5f, y - 0.5f, z - 0.5f));
		meshData.addVertex (new Vector3 (x + 0.5f, y - 0.5f, z + 0.5f));
		meshData.addVertex (new Vector3 (x - 0.5f, y - 0.5f, z + 0.5f));

		meshData.AddQuadTriangles ();
		meshData.uv.AddRange (FaceUVs (Direction.down));

		return meshData;
	}

	protected virtual MeshData FaceDataNorth (Chunk chunk, int x, int y, int z, MeshData meshData)
	{
		meshData.addVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
		meshData.addVertex(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
		meshData.addVertex(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
		meshData.addVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));

		meshData.AddQuadTriangles ();
		meshData.uv.AddRange (FaceUVs (Direction.north));

		return meshData;
	}

	protected virtual MeshData FaceDataSouth (Chunk chunk, int x, int y, int z, MeshData meshData)
	{
		meshData.addVertex (new Vector3 (x - 0.5f, y - 0.5f, z - 0.5f));
		meshData.addVertex (new Vector3 (x - 0.5f, y + 0.5f, z - 0.5f));
		meshData.addVertex (new Vector3 (x + 0.5f, y + 0.5f, z - 0.5f));
		meshData.addVertex (new Vector3 (x + 0.5f, y - 0.5f, z - 0.5f));

		meshData.AddQuadTriangles ();
		meshData.uv.AddRange (FaceUVs (Direction.south));

		return meshData;
	}

	protected virtual MeshData FaceDataEast (Chunk chunk, int x, int y, int z, MeshData meshData)
	{
		meshData.addVertex (new Vector3 (x + 0.5f, y - 0.5f, z - 0.5f));
		meshData.addVertex (new Vector3 (x + 0.5f, y + 0.5f, z - 0.5f));
		meshData.addVertex (new Vector3 (x + 0.5f, y + 0.5f, z + 0.5f));
		meshData.addVertex (new Vector3 (x + 0.5f, y - 0.5f, z + 0.5f));

		meshData.AddQuadTriangles ();
		meshData.uv.AddRange (FaceUVs (Direction.east));

		return meshData;
	}

	protected virtual MeshData FaceDataWest (Chunk chunk, int x, int y, int z, MeshData meshData)
	{
		meshData.addVertex (new Vector3 (x - 0.5f, y - 0.5f, z + 0.5f));
		meshData.addVertex (new Vector3 (x - 0.5f, y + 0.5f, z + 0.5f));
		meshData.addVertex (new Vector3 (x - 0.5f, y + 0.5f, z - 0.5f));
		meshData.addVertex (new Vector3 (x - 0.5f, y - 0.5f, z - 0.5f));

		meshData.AddQuadTriangles ();
		meshData.uv.AddRange (FaceUVs (Direction.west));

		return meshData;
	}

	public virtual Vector2[] FaceUVs (Direction direction)
	{
		Vector2[] UVs = new Vector2[4];
		Tile tilePos = texturePosition (direction);

		UVs [0] = new Vector2 (tileSize * tilePos.x + tileSize, tileSize * tilePos.y);
		UVs [1] = new Vector2 (tileSize * tilePos.x + tileSize, tileSize * tilePos.y + tileSize);
		UVs [2] = new Vector2 (tileSize * tilePos.x, tileSize * tilePos.y + tileSize);
		UVs [3] = new Vector2 (tileSize * tilePos.x, tileSize * tilePos.y);

		return UVs;
	}

	public enum Direction { north, east, south, west, up, down };

	public virtual bool isSolid (Direction direction)
	{
		switch (direction) {
		case Direction.north:
			return true;
		case Direction.east:
			return true;
		case Direction.south:
			return true;
		case Direction.west:
			return true;
		case Direction.up:
			return true;
		case Direction.down:
			return true;
		}

		return false;
	}
}
