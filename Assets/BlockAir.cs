using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockAir : Block {

	public BlockAir () : base()
	{

	}

	public override MeshData blockData (Chunk chunk, int x, int y, int z, MeshData meshData)
	{
		return meshData;
	}

	public override bool isSolid (Block.Direction direction)
	{
		return false;
	}
}
