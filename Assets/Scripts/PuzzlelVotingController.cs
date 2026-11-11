using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PuzzlelVotingController : MonoBehaviour
{
    [SerializeField] private GameObject[] VotingImages;
    [SerializeField] private GameObject[] VotingHighlightNames;
    [SerializeField] private GameObject[] VotingIdicators;
    [SerializeField] private bool[] VotingResults;
    [SerializeField] private TMP_Text VotingMessage;
    private PuzzleManager puzzleManager;
    private PuzzlePageController currentPuzzlePage;

    private void Start()
    {
        puzzleManager = FindAnyObjectByType<PuzzleManager>();
        currentPuzzlePage = GetComponentInParent<PuzzlePageController>();

        AddPointerHandlers();
        SetAllObjectsActive(VotingHighlightNames, false);
        SetAllObjectsActive(VotingIdicators, false);

        int indicatorCount = VotingIdicators == null ? 0 : VotingIdicators.Length;
        if (VotingResults == null || VotingResults.Length != indicatorCount)
        {
            VotingResults = new bool[indicatorCount];
        }
    }

    public void SetVotingResults()
    {
        int resultCount = Mathf.Min(VotingResults.Length, VotingIdicators.Length);

        for (int i = 0; i < resultCount; i++)
        {
            VotingResults[i] = VotingIdicators[i] != null && VotingIdicators[i].activeSelf;
        }
       
    }

    private void AddPointerHandlers()
    {
        for (int i = 0; i < VotingImages.Length; i++)
        {
            if (VotingImages[i] == null)
            {
                continue;
            }

            VotingImagePointerHandler handler = VotingImages[i].GetComponent<VotingImagePointerHandler>();
            if (handler == null)
            {
                handler = VotingImages[i].AddComponent<VotingImagePointerHandler>();
            }

            handler.Initialize(this, i);
        }
    }

    private void OnVotingImagePointerEnter(int index)
    {
        SetActive(VotingHighlightNames, index, true);
    }

    private void OnVotingImagePointerExit(int index)
    {
        SetActive(VotingHighlightNames, index, false);
    }

    private void OnVotingImageClicked(int index)
    {
        
        SetActive(VotingIdicators, index, !VotingIdicators[index].activeSelf);
    }

    private static void SetAllObjectsActive(GameObject[] objects, bool isActive)
    { 
        foreach (GameObject currentObject in objects)
        {
            if (currentObject != null)
            {
                currentObject.SetActive(isActive);
            }
        }
    }

    private static void SetActive(GameObject[] objects, int index, bool isActive)
    {
        if (objects != null && index >= 0 && index < objects.Length && objects[index] != null)
        {
            objects[index].SetActive(isActive);
        }
    }

    private sealed class VotingImagePointerHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private PuzzlelVotingController controller;
        private int index;

        public void Initialize(PuzzlelVotingController votingController, int imageIndex)
        {
            controller = votingController;
            index = imageIndex;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            controller.OnVotingImagePointerEnter(index);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            controller.OnVotingImagePointerExit(index);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            controller.OnVotingImageClicked(index);
        }
    }
}
