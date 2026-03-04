using UnityEngine;
using Flower;
public class DiaLogController : MonoBehaviour
{
    FlowerSystem fs;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fs=  FlowerManager.Instance.CreateFlowerSystem("default",true);
        fs.SetupDialog("NarratorDialogPrefab");
       // fs.ReadTextFromResource("intro");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
