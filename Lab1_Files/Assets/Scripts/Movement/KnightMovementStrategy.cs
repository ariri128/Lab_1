using UnityEngine;
using System.Collections.Generic;

// Calculates the fixed L-shaped squares a knight can jump to
public class KnightMovementStrategy : IMovementStrategy
{
    private static readonly Vector2Int[] offsets =
    {
        new Vector2Int(1, 2), new Vector2Int(2, 1), new Vector2Int(2, -1), new Vector2Int(1, -2),
        new Vector2Int(-1, -2), new Vector2Int(-2, -1), new Vector2Int(-2, 1), new Vector2Int(-1, 2)
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