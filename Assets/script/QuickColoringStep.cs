using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class QuickColoringStep :PaintingStep
{


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // _paintingStep = Resources.LoadAll<Sprite>("QuickColoring/Case1");
        ChangeCase(1);
        this.TryGetComponent<Image>(out var image);
    }


    public void ChangeCase(int number) {
        string casePath ;
        casePath = "QuickColoring/Case"+number;
        Debug.Log(casePath);
        step = 0;
        _paintingStep = Resources.LoadAll<Sprite>(casePath);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
