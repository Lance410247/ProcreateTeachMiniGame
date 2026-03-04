using UnityEditor;
using UnityEngine;

public class UIObjectPanel : UIObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
    {
        textName = this.name;
        if (UIManager.Instance.HighLightEffectPanel.TryGetComponent<UIHighlightFollower>(out var hightLightEffecet))
        {
            highlight = hightLightEffecet;
        }
    }

    // Update is called once per frame
    
}
