using TMPro;
using UnityEngine;

public class PlayerVotingTotalTracker : MonoBehaviour
{
    [SerializeField] GameObject PlayerPanel;
    [SerializeField] TMP_Text[] voteTotalTexts;
    private PuzzleVotingController[] puzzleVotingControllers;
    private bool[][] puzzleVotes;
    private int[] voteTotals = new int[6];
    private string[] Numerials = new string[30]
    { "I", "II", "III", "IV", "V",
        "VI", "VII", "VIII", "IX", "X",
            "XI", "XII", "XIII", "XIV", "XV",
                "XVI", "XVII", "XVIII", "XIX", "XX",
                    "XXI", "XXII", "XXIII", "XXIV", "XXV",
                        "XXVI", "XXVII", "XXVIII", "XXIX", "XXX" };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puzzleVotingControllers = PlayerPanel.GetComponentsInChildren<PuzzleVotingController>();
    }

    public void UpdateTotals()
    {
        puzzleVotingControllers = PlayerPanel.GetComponentsInChildren<PuzzleVotingController>();

        for (int i = 0; i < puzzleVotingControllers.Length; i++) {

            puzzleVotes[i] = puzzleVotingControllers[i].getVotes();
        }

        for (int i = 0; i < puzzleVotes.Length; i++)
        {
            for (int j = 0; j < puzzleVotes[i].Length; j++)
            {
                if(puzzleVotes[i][j] == true)
                {
                    voteTotals[j]++;
                    voteTotalTexts[j].text = Numerials[voteTotals[j]];
                }
            }
        }

    }
    
}
