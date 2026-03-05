using Flower;
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
    public FlowerSystem fs;
    // public GameObject _dialogController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("default", true);
        Instance = this;
        try
        {
            SettingButtonImageChange(settingButtons[0]);
            // 一開始全部關掉
            foreach (var panel in toolPanels)
                panel.SetActive(false);
        }
        catch {
            Debug.Log("cant find  this object");
        }
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
    /// <summary>
    /// 改變物件狀態
    /// </summary>
    /// <param name="_object"></param>
    public void ChangeObjectActive(GameObject _object) 
    {
        _object.SetActive(!_object.activeSelf);

    }
    /// <summary>
    /// 讀取文本
    /// </summary>
    /// <param name="text"></param>
    public void ReadDialog(string text)
    {
        fs.Stop();
        fs.Resume();
        fs.ReadTextFromResource(text);
    }

}
