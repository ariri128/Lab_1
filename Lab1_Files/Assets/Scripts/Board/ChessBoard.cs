using UnityEngine;

// Draws the 8x8 play area with Gizmos and converts between board and world coordinates
public class ChessBoard : MonoBehaviour
{
    [SerializeField] private int boardSize = 8;
    [SerializeField] private float squareSize = 1f;
    [SerializeField] private Color lightSquareColor = Color.white;
    [SerializeField] private Color darkSquareColor = Color.gray;

    public int BoardSize => boardSize;
    public float SquareSize => squareSize;

    // Converts a board coordinate into the world-space center of that square
    public Vector3 GetSquareCenter(Vector2Int boardPosition)
    {
        float x = transform.position.x + boardPosition.x * squareSize;
        float y = transform.position.y + boardPosition.y * squareSize;
        return new Vector3(x, y, transform.position.z);
    }

    // Converts a world-space position into the nearest board coordinate
    public Vector2Int GetBoardPosition(Vector3 worldPosition)
    {
        int column = Mathf.RoundToInt((worldPosition.x - transform.position.x) / squareSize);
        int row = Mathf.RoundToInt((worldPosition.y - transform.position.y) / squareSize);
        return new Vector2Int(column, row);
    }

    private void OnDrawGizmos()
    {
        for (int column = 0; column < boardSize; column++)
        {
            for (int row = 0; row < boardSize; row++)
            {
                bool isLightSquare = (column + row) % 2 == 0;
                Gizmos.color = isLightSquare ? lightSquareColor : darkSquareColor;
                Vector3 squareCenter = GetSquareCenter(new Vector2Int(column, row));
                Gizmos.DrawCube(squareCenter, new Vector3(squareSize, squareSize, 0.01f));
            }
        }
    }
}
