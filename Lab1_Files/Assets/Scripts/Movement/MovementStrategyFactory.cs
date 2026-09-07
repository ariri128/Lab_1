using System.Collections.Generic;

// Provides the correct movement strategy instance for a given piece type - Factory Method pattern
public static class MovementStrategyFactory
{
    private const int WhiteForwardDirection = 1;

    private static readonly Dictionary<PieceType, IMovementStrategy> strategies = new Dictionary<PieceType, IMovementStrategy>
    {
        { PieceType.Pawn, new PawnMovementStrategy(WhiteForwardDirection) },
        { PieceType.Knight, new KnightMovementStrategy() },
        { PieceType.Bishop, new BishopMovementStrategy() },
        { PieceType.Rook, new RookMovementStrategy() },
        { PieceType.Queen, new QueenMovementStrategy() },
        { PieceType.King, new KingMovementStrategy() }
    };

    public static IMovementStrategy GetStrategy(PieceType pieceType)
    {
        return strategies[pieceType];
    }
}