using UnityEngine;

// Shared boundary check reused by every movement strategy
public static class BoardBounds
{
    public static bool IsWithinBoard(Vector2Int square, int boardSize)
    {
        return square.x >= 0 && square.x < boardSize && square.y >= 0 && square.y < boardSize;
    }
}
