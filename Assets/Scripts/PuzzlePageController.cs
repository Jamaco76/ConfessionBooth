using System;
using TMPro;
using UnityEngine;

public class PuzzlePageController : MonoBehaviour
{
    [SerializeField] private TMP_Text puzzleIntroText;
    [SerializeField] private TMP_Text VotingResultText;
    [SerializeField] private TMP_Text VotingResultMessage;
    [SerializeField] private TMP_Text PageNumber;
    [SerializeField] bool isBlank;
    
    [SerializeField] GameObject[] dontClick;
    
    private string puzzleCode;

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

    public void SetVotingResultMessage(string text)
    {
        VotingResultMessage.text = text;
    }

    public bool IsBlank()
    {
        return isBlank;
    }

    public GameObject[] GetObjectsNotToClick()
    {
        return dontClick;
    }

    public void SetPuzzleCode(string code)
    {
        puzzleCode = code;
    }

    public string GetPuzzleCode()
    {
        return puzzleCode;
    }
}
