using TMPro;
using UnityEngine;

public class CountFinalVotes : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPanel;
    [SerializeField] private TMP_Text[] voteTotalTexts;

    private readonly string[] Numerials =
    {
        "n", "I", "II", "III", "IV", "V",
        "VI", "VII", "VIII", "IX", "X",
        "XI", "XII", "XIII", "XIV", "XV",
        "XVI", "XVII", "XVIII", "XIX", "XX",
        "XXI", "XXII", "XXIII", "XXIV", "XXV",
        "XXVI", "XXVII", "XXVIII", "XXIX", "XXX",
        "XXXI", "XXXII", "XXXIII", "XXXIV", "XXXV",
        "XXXVI", "XXXVII", "XXXVIII", "XXXIX", "XL",
        "XLI", "XLII", "XLIII", "XLIV", "XLV",
        "XLVI", "XLVII", "XLVIII", "XLIX", "L"
    };

    private void Start()
    {
        UpdateTotals();
    }

    public void UpdateTotals()
    {

        int[] finalTotals = new int[voteTotalTexts.Length];
        PlayerVotingTotalTracker[] trackers = PlayerPanel.GetComponentsInChildren<PlayerVotingTotalTracker>(true);

        foreach (PlayerVotingTotalTracker tracker in trackers)
        {

            tracker.UpdateTotals();
            int[] trackerTotals = tracker.GetVoteTotals();
            int totalCount = Mathf.Min(trackerTotals.Length, finalTotals.Length);

            for (int i = 0; i < totalCount; i++)
            {
                finalTotals[i] += trackerTotals[i];
            }
        }

        for (int i = 0; i < finalTotals.Length; i++)
        {

            voteTotalTexts[i].text = Numerials[finalTotals[i]];

        }
    }
}
