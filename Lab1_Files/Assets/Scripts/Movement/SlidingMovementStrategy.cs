using UnityEngine;
using System.Collections.Generic;

// Base class for pieces that slide across multiple squares in fixed directions
public abstract class SlidingMovementStrategy : IMovementStrategy
{
    protected abstract Vector2Int[] Directions { get; }

    public List<Vector2Int> GetReachableSquares(Vector2Int currentSquare, int boardSize)
    {
        List<Vector2Int> reachableSquares = new List<Vector2Int>();
        foreach (Vector2Int direction in Directions)
        {
            Vector2Int square = currentSquare + direction;
            while (BoardBounds.IsWithinBoard(square, boardSize))
            {
                reachableSquares.Add(square);
                square += direction;
            }
        }
        return reachableSquares;
    }
}