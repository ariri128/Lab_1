using UnityEngine;

public class RookMovementStrategy : SlidingMovementStrategy
{
    protected override Vector2Int[] Directions => new[]
    {
        Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right
    };
}
