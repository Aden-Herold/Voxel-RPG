using UnityEngine;
using System.Collections;
using System;

[Serializable]
public static class Terrain {

	public static WorldPos getBlockPos (Vector3 pos)
	{
		WorldPos blockPos = new WorldPos
		(
			Mathf.RoundToInt (pos.x),
			Mathf.RoundToInt (pos.y),
			Mathf.RoundToInt (pos.z)
		);

		return blockPos;
	}

	public static WorldPos getBlockPos (RaycastHit hit, bool adjacent = false)
	{
		Vector3 pos = new Vector3
			(
				moveWithinBlock(hit.point.x, hit.normal.x, adjacent),
				moveWithinBlock(hit.point.y, hit.normal.y, adjacent),
				moveWithinBlock(hit.point.z, hit.normal.z, adjacent)
			);
		
		return getBlockPos(pos);
	}

	static float moveWithinBlock (float pos, float norm, bool adjacent = false)
	{
		if (pos - (int)pos == 0.5f || pos - (int)pos == -0.5f) 
		{
			if (adjacent) 
			{
				pos += (norm / 2);
			} 
			else 
			{
				pos -= (norm / 2);
			}
		}

		return (float)pos;
	}

	public static bool setBlock (RaycastHit hit, Block block, bool adjacent = false)
	{
		Chunk chunk = hit.collider.GetComponent<Chunk> ();

		if (chunk == null) {
			return false;
		}

		WorldPos pos = getBlockPos (hit, adjacent);
		chunk.world.setBlock (pos.x, pos.y, pos.z, block);

		return true;
	}

	public static Block getBlock (RaycastHit hit, bool adjacent = false)
	{
		Chunk chunk = hit.collider.GetComponent<Chunk> ();

		if (chunk == null) {
			return null;
		}

		WorldPos pos = getBlockPos (hit, adjacent);
		Block block = chunk.world.getBlock (pos.x, pos.y, pos.z);

		return block;
	}
}
