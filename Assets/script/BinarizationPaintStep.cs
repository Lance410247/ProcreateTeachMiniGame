using UnityEngine;

public class BinarizationPaintStep :QuickColoringStep
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _paintingStep = Resources.LoadAll<Sprite>("BinarizationStep");
    }

    // Update is called once per frame
    
}
