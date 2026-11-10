using UnityEngine;
using UnityEngine.EventSystems;

public class BookController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject LeftPanel;
    [SerializeField] private GameObject RightPanel;

    private int currentPageSet = 0;
    private int leftPageCount;
    private int rightPageCount;

    private void Start()
    {
        
        RefreshPages();
    }

    private void Update()
    { 
        if (GetPageCount(LeftPanel) != leftPageCount || GetPageCount(RightPanel) != rightPageCount)
        {
            RefreshPages();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (IsOnPanel(eventData.pointerCurrentRaycast.gameObject, RightPanel))
        {
            SetPageSet(currentPageSet + 1);
        }
        else if (IsOnPanel(eventData.pointerCurrentRaycast.gameObject, LeftPanel))
        {
            SetPageSet(currentPageSet - 1);
        }
    }

    private void SetPageSet(int pageSet)
    {
        int pageCount = Mathf.Max(leftPageCount, rightPageCount);
        currentPageSet = Mathf.Clamp(pageSet, 0, Mathf.Max(0, pageCount - 1));
        RefreshPages();
    }

    private void RefreshPages()
    {
        int previousLeftPageCount = leftPageCount;
        int previousRightPageCount = rightPageCount;

        leftPageCount = GetPageCount(LeftPanel);
        rightPageCount = GetPageCount(RightPanel);

        int previousPageSetCount = Mathf.Min(previousLeftPageCount, previousRightPageCount);
        int pageSetCount = Mathf.Min(leftPageCount, rightPageCount);

        if (pageSetCount > previousPageSetCount)
        {
            currentPageSet = pageSetCount - 1;
        }

        int pageCount = Mathf.Max(leftPageCount, rightPageCount);
        currentPageSet = Mathf.Clamp(currentPageSet, 0, Mathf.Max(0, pageCount - 1));

        SetPageActive(LeftPanel, leftPageCount);
        SetPageActive(RightPanel, rightPageCount);
    }

    private void SetPageActive(GameObject panel, int pageCount)
    {
        if (panel == null)
        {
            return;
        }

        for (int i = 0; i < pageCount; i++)
        {
            panel.transform.GetChild(i).gameObject.SetActive(i == currentPageSet);
        }
    }

    private static int GetPageCount(GameObject panel)
    {
        return panel == null ? 0 : panel.transform.childCount;
    }

    private static bool IsOnPanel(GameObject clickedObject, GameObject panel)
    {
        if (clickedObject == null || panel == null)
        {
            return false;
        }

        GameObject[] dontClick = panel.GetComponentInChildren<PuzzlePageController>().GetObjectsNotToClick();

        for(int i = 0; i < dontClick.Length; i++)
        {
            if (clickedObject == dontClick[i])
            {
                return false;
            }
        }
      
        Debug.Log(clickedObject.gameObject);

        Transform clickedTransform = clickedObject.transform;
        return clickedTransform == panel.transform || clickedTransform.IsChildOf(panel.transform);
    }
}
