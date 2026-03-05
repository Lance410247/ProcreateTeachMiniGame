using UnityEngine;
using Flower;
using System.Collections.Generic;
 
public class BaseFunctionsSceneController : MonoBehaviour
{
    FlowerSystem fs;
    //public static BaseFunctionsSceneController Instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Instance = this;
        // UIManager.Instance._dialogController = this.gameObject;
        fs = UIManager.Instance.fs;
        fs.SetupDialog("NarratorDialogPrefab");
        fs.ReadTextFromResource("BaseFuntionintro");
        /*  fs.RegisterCommand("changeVariant", (List<string> _params) =>
          {
              var _object = UIManager.Instance.narrator;
              if (_object.TryGetComponent<Narrator>(out var _nar))
              {

              }
              if (_params[0] =="0") {
                  _nar.ChangeVariant(NarratorVariant.normal); 


              }else if (_params[0] == "1")
              {
                  _nar.ChangeVariant(NarratorVariant.talk);
              }
              else if (_params[0] == "2")
              {
                  _nar.ChangeVariant(NarratorVariant.smile);
              }
              else
              {
                  Debug.Log("¿ù»~ªº°Ñ¼Æ:"+_params);
              }
          }

          );*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ¥ªÁä
        {
            fs.Next();



        }
    }



}
