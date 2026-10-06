using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelPieceBasedSetup", menuName = "Scriptable Objects/LevelPieceBasedSetup")]
public class LevelPieceBasedSetup : ScriptableObject
{
    [Header("Pieces")]
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesEnd;

    public int piecesStartNumber = 3;
    public int piecesNumber = 5;
    public int piecesEndNumber = 1;
}
