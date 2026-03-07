using UnityEngine;
using UnityEngine.UI;

public class PaintingStep : MonoBehaviour
{
    public GameObject Hand;
    public Sprite[] _paintingStep;
    int step = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _paintingStep =Resources.LoadAll<Sprite>("PaintingStep");
        this.TryGetComponent<Image>(out var image);
        
        // Debug.Log(_paintingStep.Length);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Hand.TryGetComponent<Fingers>(out var finger);
        if (Input.GetMouseButtonDown(0)) { 
        
        
        
        
        
        };
        */
    }

    public void FrontStep(FingersNumber number)
    {
        if (step<=0) {

            step = 0;
            return; }
        if (number==FingersNumber.TwoFinger) 
        {
            this.TryGetComponent<Image>(out var image);
            image.sprite = _paintingStep[--step];
        }
        else { return; }
    }
    public void NextStep(FingersNumber number) 
    {
        if (step >= _paintingStep.Length-1) {

            step = _paintingStep.Length - 1;
            return; }
        if (number == FingersNumber.ThirdFinger) 
        {

            this.TryGetComponent<Image>(out var image);
            image.sprite = _paintingStep[++step];

        }
        else { return; }

    }
}
