using UnityEngine;
using Flower;
using System.Collections.Generic;
 
public class GestureController : MonoBehaviour
{
    FlowerSystem fs;
    //public static BaseFunctionsSceneController Instance;
    public GameObject _pluralFingerLayer;
    public GameObject hand;
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
        isPluralFingersLayerActive();
        if (Input.GetMouseButtonDown(0)) // ек┴ф
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
