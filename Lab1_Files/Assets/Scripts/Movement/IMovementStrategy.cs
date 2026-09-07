using UnityEngine;
using System.Collections.Generic;

// Contract for calculating the squares a piece can reach from its current square
public interface IMovementStrategy
{
    List<Vector2Int> GetReachableSquares(Vector2Int currentSquare, int boardSize);
}
