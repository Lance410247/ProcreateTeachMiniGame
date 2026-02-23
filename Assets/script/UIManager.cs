using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject[] toolPanels;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;

        // 一開始全部關掉
        foreach (var panel in toolPanels)
            panel.SetActive(false);
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
