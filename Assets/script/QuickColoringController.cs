using UnityEngine;
using Flower;
using System.Collections.Generic;
 
public class QuickColoringController : MonoBehaviour
{
    FlowerSystem fs;
    //public static BaseFunctionsSceneController Instance;
    public GameObject _pluralFingerLayer;

    public GameObject _paintingStep;
    public GameObject hand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Instance = this;
        // UIManager.Instance._dialogController = this.gameObject;
        fs = UIManager.Instance.fs;
        fs.SetupDialog("NarratorDialogPrefab");
        fs.ReadTextFromResource("QuickColoringintro");
        fs.RegisterToSceneObject("PluralFingersLayer", _pluralFingerLayer);
       // fs.RegisterToSceneObject("PaintingStep", _paintingStep);
        
        fs.RegisterCommand("DrawExample", (List<string> _params) =>
        {
            //1是打開操作
            //0是關閉操作
            if (_params[0] == "1")
            {
                if (_paintingStep.TryGetComponent<DrawingExample>(out var drawExample))
                {
                    drawExample.DrawExample();
                    
                }
            }
            else
            {
               
            }
        });
        //fs.SetTextList(new List<string> { "[changeObjectActive,PluralFingersLayer]" });

        //   fs.R
    }

    // Update is called once per frame
    void Update()
    {
        isPluralFingersLayerActive();
        if (Input.GetMouseButtonDown(0)) // 左鍵
        {
            fs.Next();



        }
    }

    public void isPluralFingersLayerActive()
    {
        if(hand.TryGetComponent<Fingers>(out var finger))
        {

           // Debug.Log("Don't Find script");
        }

        if ((int)finger.GetCurrentFinger()>1)
        {
           // Debug.Log((int)finger.GetCurrentFinger());
            _pluralFingerLayer.SetActive(true);
            //UIManager.Instance.DisableAllImage();
        }
        else
        {
            //Debug.Log((int)finger.GetCurrentFinger());
            _pluralFingerLayer.SetActive(false);
        }

    }

}
