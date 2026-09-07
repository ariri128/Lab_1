using UnityEngine;
using System.Collections.Generic;

// Represents a single chess piece: its visuals and the squares it can move to
[RequireComponent(typeof(SpriteRenderer))]
public class ChessPiece : MonoBehaviour
{
    [SerializeField] private PieceType pieceType = PieceType.Pawn;
    [SerializeField] private Color colorTint = Color.white;
    [SerializeField] private ChessPieceSpriteSet spriteSet;
    [SerializeField] private ChessBoard board;

    private SpriteRenderer spriteRenderer;

    public PieceType PieceType => pieceType;

    // Assigns this piece's type and tint, then refreshes its visuals
    public void Configure(PieceType newPieceType, Color newColorTint)
    {
        pieceType = newPieceType;
        colorTint = newColorTint;
        ApplyVisuals();
    }

    private void Awake()
    {
        EnsureBoardReference();
        ApplyVisuals();
    }

    private void OnValidate()
    {
        EnsureBoardReference();
        ApplyVisuals();
    }

    // Finds the parent ChessBoard if one hasn't been assigned yet
    private void EnsureBoardReference()
    {
        if (board == null)
        {
            board = GetComponentInParent<ChessBoard>();
        }
    }

    // Updates the sprite and color tint to match the currently selected piece type
    private void ApplyVisuals()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        if (spriteSet != null)
        {
            spriteRenderer.sprite = spriteSet.GetSprite(pieceType);
        }
        spriteRenderer.color = colorTint;
    }

    // Draws the squares this piece could move to, based on its movement strategy
    private void OnDrawGizmosSelected()
    {
        EnsureBoardReference();
        if (board == null)
        {
            return;
        }

        Vector2Int currentSquare = board.GetBoardPosition(transform.position);
        IMovementStrategy movementStrategy = MovementStrategyFactory.GetStrategy(pieceType);
        List<Vector2Int> reachableSquares = movementStrategy.GetReachableSquares(currentSquare, board.BoardSize);

        Gizmos.color = Color.green;
        foreach (Vector2Int square in reachableSquares)
        {
            Vector3 worldPosition = board.GetSquareCenter(square);
            Gizmos.DrawWireSphere(worldPosition, board.SquareSize * 0.3f);
        }
    }
}