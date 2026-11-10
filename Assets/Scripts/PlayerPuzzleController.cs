using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPuzzleController : MonoBehaviour
{

    [SerializeField] private TMP_InputField codeInput;
    [SerializeField] private Button submitButton;
    [SerializeField] private GameObject panelPrefab;
    [SerializeField] private GameObject blankpanelPrefab;
    [SerializeField] private PuzzleManager puzzleManager;
    [SerializeField] private Transform LeftParent;
    [SerializeField] private Transform RightParent;


    //when true left parent will be used, when false right parent will be used
    private bool LastPanelCreated = true;
    private int pageCreated = 0;
    private string[] Numerials = new string[15] 
    { "I", "II", "III", "IV", "V", 
        "VI", "VII", "VIII", "IX", "X", 
            "XI", "XII", "XIII", "XIV", "XV" };
    private List<string> puzzlesEntered = new List<string>();

    public void CreateNewPuzzlePanel(PuzzleData puzzle)
    {
        if (LastPanelCreated)
        {
            GameObject leftpanel = Instantiate(panelPrefab, LeftParent);
            PuzzlePageController lpPage = leftpanel.GetComponent<PuzzlePageController>();

            lpPage.SetPuzzleIntroText(puzzle.introPrompt);
            lpPage.SetPageNumber("-=- " + Numerials[pageCreated] + " -=-");
            pageCreated++;

            if (pageCreated % 2 == 1)
            {
                GameObject rightpanel = Instantiate(blankpanelPrefab, RightParent);
                PuzzlePageController rpPage = rightpanel.GetComponent<PuzzlePageController>();
                rpPage.SetPageNumber("-=- " + Numerials[pageCreated] + " -=-");

            }

            if(pageCreated == 1)
            {
                Destroy(LeftParent.GetChild(0).gameObject);
                Destroy(RightParent.GetChild(0).gameObject);
            }

            LastPanelCreated = false;
        }
        else
        {
            Destroy(RightParent.GetChild(RightParent.childCount-1).gameObject);

            GameObject rightpanel = Instantiate(panelPrefab, RightParent);
            PuzzlePageController rpPage = rightpanel.GetComponent<PuzzlePageController>();
            
            rpPage.SetPuzzleIntroText(puzzle.introPrompt);
            rpPage.SetPageNumber("-=- " + Numerials[pageCreated] + " -=-");
            pageCreated++;

            
            LastPanelCreated = true;
        }
    }

    public void CheckCode()
    {
        string code = codeInput.text.Trim().ToUpperInvariant();

        for(int i = 0; i < puzzlesEntered.Count; i++)
        {
            if (code.Equals(puzzlesEntered[i]))
            {
                Debug.Log("Puzzle already entered");
                return;
            }
        }

        for (int i = 0; i < puzzleManager.GetAllPuzzles().Count; i++)
        {
            if (code.Equals(puzzleManager.GetAllPuzzles()[i].code.ToUpperInvariant()))
            {
                CreateNewPuzzlePanel(puzzleManager.GetAllPuzzles()[i]);
                puzzlesEntered.Add(puzzleManager.GetAllPuzzles()[i].code);
                return;
            }
            
            
            Debug.Log("Puzzle not found");
            
        }

    }
}
