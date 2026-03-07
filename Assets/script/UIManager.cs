using Flower;
using System.Collections.Generic;
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

    public bool playOption = false;
    // public GameObject _dialogController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("default", true);
        fs.RegisterCommand("changeVariant", (List<string> _params) =>
        {
            var _object = UIManager.Instance.narrator;
            if (_object.TryGetComponent<Narrator>(out var _nar))
            {

            }
            if (_params[0] == "0")
            {
                _nar.ChangeVariant(NarratorVariant.normal);


            }
            else if (_params[0] == "1")
            {
                _nar.ChangeVariant(NarratorVariant.talk);
            }
            else if (_params[0] == "2")
            {
                _nar.ChangeVariant(NarratorVariant.smile);
            }
            else
            {
                Debug.Log("錯誤的參數:" + _params);
            }
        });
        fs.RegisterCommand("changeObjectActive", (List<string> _params) =>
        {
            fs.GetSceneObject(_params[0]).SetActive(!fs.GetSceneObject(_params[0]).activeSelf);
        });
        fs.RegisterCommand("SetPlayerOption", (List<string> _params) =>
        {
            //1是打開操作
            //0是關閉操作
            if (_params[0]=="1")
            {
                playOption = true;
            }
            else
            {
                playOption = false;
            }
        });
        Instance = this;
        try
        {
            SettingButtonImageChange(settingButtons[0]);
            // 一開始全部關掉
            foreach (var panel in toolPanels)
                panel.SetActive(false);
        }
        catch {
            Debug.Log("cant find these objects");
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
