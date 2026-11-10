using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleData> allPuzzles;
    private Dictionary<string, PuzzleData> puzzleLookup = new();

    void Awake()
    {
        foreach (var puzzle in allPuzzles)
            puzzleLookup[puzzle.code.ToUpper()] = puzzle;
    }

    public bool GetPuzzle(string inputCode, out PuzzleData puzzle)
    {
        return puzzleLookup.TryGetValue(inputCode.Trim().ToUpper(), out puzzle);
    }

    public List<PuzzleData> GetAllPuzzles()
    {
        return allPuzzles;
    }
}