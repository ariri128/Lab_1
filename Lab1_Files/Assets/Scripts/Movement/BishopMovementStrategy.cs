using UnityEngine;

public class BishopMovementStrategy : SlidingMovementStrategy
{
    protected override Vector2Int[] Directions => new[]
    {
        new Vector2Int(1, 1), new Vector2Int(1, -1), new Vector2Int(-1, 1), new Vector2Int(-1, -1)
    };
}
