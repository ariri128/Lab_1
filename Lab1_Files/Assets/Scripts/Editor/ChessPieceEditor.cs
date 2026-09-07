using UnityEngine;
using UnityEditor;

// Draws a draggable border handle around the selected piece, snapping its result to the board grid
[CustomEditor(typeof(ChessPiece))]
public class ChessPieceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }

    private void OnSceneGUI()
    {
        ChessPiece piece = (ChessPiece)target;
        ChessBoard board = piece.GetComponentInParent<ChessBoard>();
        if (board == null)
        {
            return;
        }

        Handles.color = Color.yellow;
        Handles.DrawWireCube(piece.transform.position, Vector3.one * board.SquareSize);

        float handleSize = board.SquareSize * 0.5f;
        EditorGUI.BeginChangeCheck();
        Vector3 newPosition = Handles.FreeMoveHandle(piece.transform.position, handleSize, Vector3.zero, Handles.RectangleHandleCap);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(piece.transform, "Move Chess Piece");
            Vector2Int snappedSquare = board.GetBoardPosition(newPosition);
            piece.transform.position = board.GetSquareCenter(snappedSquare);
        }
    }
}