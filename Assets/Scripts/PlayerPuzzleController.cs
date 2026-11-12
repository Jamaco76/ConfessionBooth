using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPuzzleController : MonoBehaviour
{

    [SerializeField] private TMP_InputField codeInput;
    [SerializeField] private Button submitButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject PuzzlePagePrefab;
    [SerializeField] private GameObject NotesPrefab;
    [SerializeField] private GameObject blankpanelPrefab;
    [SerializeField] private PuzzleManager puzzleManager;
    [SerializeField] private Transform LeftParent;
    [SerializeField] private Transform RightParent;


    private int pageCreated = 0;
    private string[] Numerials = new string[30]
    { "I", "II", "III", "IV", "V", 
        "VI", "VII", "VIII", "IX", "X", 
            "XI", "XII", "XIII", "XIV", "XV",
                "XVI", "XVII", "XVIII", "XIX", "XX",
                    "XXI", "XXII", "XXIII", "XXIV", "XXV",
                        "XXVI", "XXVII", "XXVIII", "XXIX", "XXX" };
    private List<string> puzzlesEntered = new List<string>();

    public void CreateNewPuzzlePanel(PuzzleData puzzle)
    {
        if (pageCreated == 0)
        {
            if (LeftParent.childCount > 0)
            {
                Destroy(LeftParent.GetChild(0).gameObject);
            }

            if (RightParent.childCount > 0)
            {
                Destroy(RightParent.GetChild(0).gameObject);
            }
        }

        GameObject leftPanel = Instantiate(PuzzlePagePrefab, LeftParent);
        PuzzlePageController leftPage = leftPanel.GetComponent<PuzzlePageController>();
        leftPage.SetPuzzleIntroText(puzzle.introPrompt);
        leftPage.SetPageNumber("-=- " + Numerials[pageCreated] + " -=-");
        leftPage.SetPuzzleCode(puzzle.code);

        GameObject rightPanel = Instantiate(NotesPrefab, RightParent);
        PuzzlePageController rightPage = rightPanel.GetComponent<PuzzlePageController>();
        rightPage.SetPageNumber("-=- " + Numerials[pageCreated + 1] + " -=-");

        pageCreated += 2;
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
            
        }

        Debug.Log("Puzzle not found");

    }

    public void ClosePlayerPanel()
    {
        this.gameObject.SetActive(false);
        puzzleManager.GetComponent<RectTransform>().gameObject.SetActive(true);
    }
}
