using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public struct PieceSpriteEntry
{
    public PieceType pieceType;
    public Sprite sprite;
}

// Maps each piece type to the sprite that represents it, editable as a shared asset
[CreateAssetMenu(fileName = "ChessPieceSpriteSet", menuName = "Chess/Piece Sprite Set")]
public class ChessPieceSpriteSet : ScriptableObject
{
    [SerializeField] private List<PieceSpriteEntry> spriteEntries = new List<PieceSpriteEntry>();

    // Returns the sprite mapped to the given piece type, or null if none is assigned
    public Sprite GetSprite(PieceType pieceType)
    {
        foreach (PieceSpriteEntry entry in spriteEntries)
        {
            if (entry.pieceType == pieceType)
            {
                return entry.sprite;
            }
        }
        return null;
    }
}
