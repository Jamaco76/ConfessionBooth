using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PuzzleData", menuName = "Scriptable Objects/PuzzleData")]
public class PuzzleData : ScriptableObject
{
    [Header("Identification")]
    public string puzzleName;
    public string code;

    [Header ("Text Prompts")]
    public string introPrompt;
    public string[] votingPrompts;
    
        

    [Header ("Voting Options (0 or 1 to indicate guilt based on player order)")]
    public string[] votingOptions = new string[6] { "Joseph Louis-Renou Pampadour", "Narcisse Leopold Deschamps", "Melodie Octavia Cantrelle", "Pierre Dauck Bonfils", "Felicte Renee Chance", "Priscille Daphnee Gisele Brillante" };
    public int[] correctOptions = new int[6];
    public int[] votingResults = new int[6];

}
