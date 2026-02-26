using UnityEngine;



public class UIHighlightFollower : MonoBehaviour
{
    private RectTransform rectTransform;
    private RectTransform target;
    [SerializeField] private Vector2 padding = new Vector2(0.5f, 0.5f);
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    public void Follow(RectTransform newTarget)
    {
        target = newTarget;

        if (target == null)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);

        UpdatePositionAndSize();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void UpdatePositionAndSize()
    {
        rectTransform.position = target.position;
        rectTransform.sizeDelta = target.sizeDelta+padding;
        rectTransform.rotation = target.rotation;
    }
}