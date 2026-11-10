using System;
using TMPro;
using UnityEngine;

public class PuzzlePageController : MonoBehaviour
{
    [SerializeField] private TMP_Text puzzleIntroText;
    [SerializeField] private TMP_Text VotingResultText;
    [SerializeField] private TMP_Text PageNumber;
    [SerializeField] bool isBlank;
    
    public void SetPuzzleIntroText(string text)
    {
        puzzleIntroText.text = text;
    }
    public void SetVotingResultText(string text)
    {
        VotingResultText.text = text;
    }
    public void SetPageNumber(string pageNumber)
    {
        PageNumber.text = pageNumber.ToString();
    }
}
