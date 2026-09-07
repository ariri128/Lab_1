using UnityEngine;
using System.Collections.Generic;

// Calculates the eight adjacent squares a king can step to
public class KingMovementStrategy : IMovementStrategy
{
    private static readonly Vector2Int[] offsets =
    {
        new Vector2Int(0, 1), new Vector2Int(0, -1), new Vector2Int(1, 0), new Vector2Int(-1, 0),
        new Vector2Int(1, 1), new Vector2Int(1, -1), new Vector2Int(-1, 1), new Vector2Int(-1, -1)
    };

    public List<Vector2Int> GetReachableSquares(Vector2Int currentSquare, int boardSize)
    {
        List<Vector2Int> reachableSquares = new List<Vector2Int>();
        foreach (Vector2Int offset in offsets)
        {
            Vector2Int square = currentSquare + offset;
            if (BoardBounds.IsWithinBoard(square, boardSize))
            {
                reachableSquares.Add(square);
            }
        }
        return reachableSquares;
    }
}