using UnityEngine;
using Flower;
using System.Collections.Generic;
using UnityEngine.UI;

public class ExtraToolController : MonoBehaviour
{
    FlowerSystem fs;
    //public static BaseFunctionsSceneController Instance;
    public GameObject pureRef;
    public GameObject hand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hand.TryGetComponent<Fingers>(out var fingers);
        fingers.LockFingersChange(true);
        // Instance = this;
        // UIManager.Instance._dialogController = this.gameObject;
        fs = UIManager.Instance.fs;
        fs.SetupDialog("NarratorDialogPrefabBig");
        fs.ReadTextFromResource("ExtraToolintro");
        fs.RegisterToSceneObject("pureRef", pureRef);
        //fs.SetTextList(new List<string> { "[changeObjectActive,PluralFingersLayer]" });

        //   fs.R
    }

    // Update is called once per frame
    void Update()
    {
        //isPluralFingersLayerActive();
        if (Input.GetMouseButtonDown(0)) // ек┴ф
        {
            fs.Next();



        }
    }

   

}
