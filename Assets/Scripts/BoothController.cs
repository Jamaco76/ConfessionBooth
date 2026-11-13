using UnityEngine;
using TMPro;

public class BoothController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private TMP_InputField codeInput;
    [SerializeField] private GameObject inputPanel;
    [SerializeField] private GameObject endTotalsPanel;
    [SerializeField] private TMP_Text errorText;

    [Header("Player Panels")]
    [SerializeField] private GameObject[] playerPanels = new GameObject[6];

    private string[] playerPasswords = new string[6] { "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX" };

    private void Start()
    {
        CloseBook();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SubmitCode();

        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseBook();
        }
    }


    public void SubmitCode()
    {
        string code = codeInput.text.Trim().ToUpperInvariant();
        bool CodeMatches = false;
        int index = 0;

        if (code.Equals("END"))
        {
            endTotalsPanel.SetActive(true);
            return;
        }


        for(int i = 0; i < playerPasswords.Length; i++)
        {
            if (code.Equals(playerPasswords[i]))
            {
                CodeMatches = true;
                index = i;
                break;
            }
           
        }

        if(CodeMatches == false)
        {
            HidePlayerPanels();
            errorText.text = "Invalid code. Please enter P1 through P6.";
            return;
        }

        if (playerPanels[index] == null)
        {
            errorText.text = "This player panel has not been assigned.";
            return;
        }

        HidePlayerPanels();
        inputPanel.SetActive(false);
        errorText.text = string.Empty;
        playerPanels[index].SetActive(true);
    }

    public void CloseBook()
    {
        HidePlayerPanels();

        if (inputPanel != null)
        {
            inputPanel.SetActive(true);
        }

        if (codeInput != null)
        {
            codeInput.text = string.Empty;
            codeInput.ActivateInputField();
        }

        if (errorText != null)
        {
            errorText.text = string.Empty;
        }
    }

    private void HidePlayerPanels()
    {
        foreach (GameObject panel in playerPanels)
        {
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }
    }
}

