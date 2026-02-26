using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UIHighlightFollower highlight;
    public bool isHovering;



     void Start()
    {
        if (UIManager.Instance.HighLightEffect.TryGetComponent<UIHighlightFollower>(out var hightLightEffecet))
        {
            highlight = hightLightEffecet;
        }
    }

    // 滑鼠進入
    public void OnPointerEnter(PointerEventData eventData)
    {
       
        if (isHovering) return;
        isHovering = true;
         Debug.Log("滑鼠進入");
        highlight.Follow(GetComponent<RectTransform>());
        OnSelected();
    }

    // 滑鼠離開
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
          Debug.Log("滑鼠離開");
        highlight.Hide();
    }

    protected virtual void OnSelected()
    {
       // Debug.Log("預留解說接口");
    }
}
