using UnityEngine;
using System.Collections.Generic;

// Calculates the one or two square forward advance available to a pawn
public class PawnMovementStrategy : IMovementStrategy
{
    private readonly int forwardDirection;

    public PawnMovementStrategy(int forwardDirection)
    {
        this.forwardDirection = forwardDirection;
    }

    public List<Vector2Int> GetReachableSquares(Vector2Int currentSquare, int boardSize)
    {
        List<Vector2Int> reachableSquares = new List<Vector2Int>();

        Vector2Int oneSquareAhead = currentSquare + new Vector2Int(0, forwardDirection);
        if (BoardBounds.IsWithinBoard(oneSquareAhead, boardSize))
        {
            reachableSquares.Add(oneSquareAhead);
        }

        Vector2Int twoSquaresAhead = currentSquare + new Vector2Int(0, forwardDirection * 2);
        if (BoardBounds.IsWithinBoard(twoSquaresAhead, boardSize))
        {
            reachableSquares.Add(twoSquaresAhead);
        }

        return reachableSquares;
    }
}
