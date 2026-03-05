using UnityEngine;
using Flower;
using System.Collections.Generic;
 
public class GestureController : MonoBehaviour
{
    FlowerSystem fs;
    //public static BaseFunctionsSceneController Instance;
    public GameObject _pluralFingerLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Instance = this;
        // UIManager.Instance._dialogController = this.gameObject;
        fs = UIManager.Instance.fs;
        fs.SetupDialog("NarratorDialogPrefab");
        fs.ReadTextFromResource("gestureintro");
        fs.RegisterToSceneObject("PluralFingersLayer", _pluralFingerLayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ек┴ф
        {
            fs.Next();



        }
    }



}
