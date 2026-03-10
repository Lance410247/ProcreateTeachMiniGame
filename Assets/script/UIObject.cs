using Flower;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UIHighlightFollower highlight;
    public bool isCanBeSelect = true;
    public bool isHovering;
    //FlowerSystem fs;
    [SerializeField]public string textName=" ";

     void Start()
    {
        // fs = FlowerManager.Instance.GetFlowerSystem(default);
        textName = this.name;
       // Debug.Log(textName);
        if (UIManager.Instance.HighLightEffect.TryGetComponent<UIHighlightFollower>(out var hightLightEffecet))
        {
            highlight = hightLightEffecet;
        }
    }

    // 滑鼠進入
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!UIManager.Instance.playOption) { return; }
        if (isHovering) return;
        isHovering = true;
        if (!isCanBeSelect) return;
        //Debug.Log("滑鼠進入");
        highlight.Follow(GetComponent<RectTransform>());
        //Debug.Log(GetComponent<RectTransform>());
        OnSelected();
    }

    // 滑鼠離開
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        //  Debug.Log("滑鼠離開");
        highlight.Hide();
    }

    public virtual void OnSelected()
    {
        //if (!isCanBeSelect) return;
        if (textName == " ")
        {
            return;
        }
        // Debug.Log("預留解說接口");
        try { UIManager.Instance.ReadDialog(textName); } catch { 
        
        }
       
    }
}
