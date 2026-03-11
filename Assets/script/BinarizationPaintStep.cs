using UnityEngine;

public class BinarizationPaintStep :QuickColoringStep
{
    public string resourcesPath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _paintingStep = Resources.LoadAll<Sprite>(resourcesPath);
    }

    // Update is called once per frame
    
}
