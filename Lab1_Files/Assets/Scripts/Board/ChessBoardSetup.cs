using UnityEngine;

// Spawns a full set of white chess pieces onto the board in their standard starting squares
[RequireComponent(typeof(ChessBoard))]
public class ChessBoardSetup : MonoBehaviour
{
    [SerializeField] private ChessPiece piecePrefab;

    private static readonly PieceType[] backRowOrder =
    {
        PieceType.Rook, PieceType.Knight, PieceType.Bishop, PieceType.Queen,
        PieceType.King, PieceType.Bishop, PieceType.Knight, PieceType.Rook
    };

    [ContextMenu("Spawn White Pieces")]
    public void SpawnWhitePieces()
    {
        ChessBoard board = GetComponent<ChessBoard>();
        for (int column = 0; column < backRowOrder.Length; column++)
        {
            SpawnPiece(board, backRowOrder[column], new Vector2Int(column, 0));
            SpawnPiece(board, PieceType.Pawn, new Vector2Int(column, 1));
        }
    }

    private void SpawnPiece(ChessBoard board, PieceType pieceType, Vector2Int boardPosition)
    {
        Vector3 worldPosition = board.GetSquareCenter(boardPosition);
        ChessPiece piece = Instantiate(piecePrefab, worldPosition, Quaternion.identity, transform);
        piece.name = $"{pieceType}_{boardPosition.x}_{boardPosition.y}";
        piece.Configure(pieceType, Color.white);
    }
}
