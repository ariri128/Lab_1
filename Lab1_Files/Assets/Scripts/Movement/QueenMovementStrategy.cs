using UnityEngine;

public class QueenMovementStrategy : SlidingMovementStrategy
{
    protected override Vector2Int[] Directions => new[]
    {
        Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right,
        new Vector2Int(1, 1), new Vector2Int(1, -1), new Vector2Int(-1, 1), new Vector2Int(-1, -1)
    };
}
