using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerVotingTotalTracker : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPanel;
    [SerializeField] private TMP_Text[] voteTotalTexts;
    [SerializeField] private List<PuzzleVotingController> puzzleVotingControllers = new List<PuzzleVotingController>();
    private int[] voteTotals;

    private string[] Numerials = new string[16]
    { "n","I", "II", "III", "IV", "V",
        "VI", "VII", "VIII", "IX", "X",
            "XI", "XII", "XIII", "XIV", "XV"};

    private void Start()
    {
        UpdateTotals();
    }

    public void UpdateTotals()
    {
        

        puzzleVotingControllers = new List<PuzzleVotingController>(PlayerPanel.GetComponentsInChildren<PuzzleVotingController>(true));
        voteTotals = new int[voteTotalTexts == null ? 0 : voteTotalTexts.Length];

        foreach (PuzzleVotingController votingController in puzzleVotingControllers)
        {
   
            bool[] votes = votingController.getVotes();
           
            int voteCount = Mathf.Min(votes.Length, voteTotals.Length);
            for (int i = 0; i < voteCount; i++)
            {
                if (votes[i])
                {
                    voteTotals[i]++;
                }
            }
        }

        for (int i = 0; i < voteTotals.Length; i++)
        {
            if (voteTotalTexts[i] != null)
            {
                voteTotalTexts[i].text = voteTotals[i] < Numerials.Length
                    ? Numerials[voteTotals[i]]
                    : voteTotals[i].ToString();
            }
        }

    }

    public int[] GetVoteTotals()
    {
        return voteTotals == null ? new int[0] : (int[])voteTotals.Clone();
    }
    
}
