using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject[] toolPanels;
    public GameObject[] settingPanels;
    public GameObject[] settingButtons;
    public GameObject HighLightEffect;
    public GameObject HighLightEffectPanel;
    public GameObject narrator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        SettingButtonImageChange(settingButtons[0]);
        // 一開始全部關掉
        foreach (var panel in toolPanels)
            panel.SetActive(false);
    }

    public void SettingButtonImageChange(GameObject button)
    {
        foreach (var _object in settingButtons)
        {
            if (_object.TryGetComponent<SettingButton>(out var settingBtn))
            {
                settingBtn.ChangeImageUnselecting();
            }
        }
        if (button.TryGetComponent<SettingButton>(out var btn))
        {
            btn.ChangeImageSelecting();
        }
    }

    public void ShowImage(GameObject imageObject )

    {
        //關閉全部的Panels
        DisableAllImage();
        //開啟指定的Panel
        imageObject.SetActive(true);
    }
    public void ShowExtraImage(GameObject imageObject)
    {
        imageObject.SetActive(true);
    }
    public void DisableImage(GameObject imageObject )
        {
            imageObject.SetActive(false);
        }

    public void DisableAllImage()
    {
        foreach (GameObject panel in toolPanels)
        {
            DisableImage(panel);
        }
    }

}
