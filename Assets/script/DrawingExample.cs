using UnityEngine;
using Timers;
public class DrawingExample : MonoBehaviour
{
    // public GameObject _object;

    private bool isNowDrawing=false;
    private float drawingTime;
    public float DrawingTime => drawingTime;
    public bool IsNowDrawing => isNowDrawing;


    void Timer1()
    {
       
        if (this.TryGetComponent<PaintingStep>(out var paintingStep))
        {
            if (paintingStep.CurrentStep()>=paintingStep.MaxStep()) {

                Debug.Log("Drawing the last");
                TimersManager.SetTimer(this, 0.1f, CleanTimer1);
                isNowDrawing = false;
                return ;
            
            }

            Debug.Log("drawing"+paintingStep.CurrentStep()+" Step");
            paintingStep.NextStep(FingersNumber.ThirdFinger);
            //Debug.Log("Catch the PaintingStep");


        }
        //Debug.Log("Test");
    }
    void CleanTimer1()
    {
        TimersManager.ClearTimer(Timer1);
    }
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //drawExample();
       // TimersManager.SetLoopableTimer(this,1f,Timer1);
       // TimersManager.SetTimer(this,5f,CleanTimer1);
    }
    public void DrawExample()
    {
        if (this.TryGetComponent<PaintingStep>(out var paintingStep))
        {
            isNowDrawing = true;

            TimersManager.SetLoopableTimer(this, 0.3f, Timer1);
            drawingTime = 0.3f * paintingStep.MaxStep()*1000f;
            Debug.Log(drawingTime);
        }
            
       // float endingSecond=0.5f* paintingStep.MaxStep();
        //Debug.Log("endingSecond:" + endingSecond);
        //TimersManager.SetTimer(this, endingSecond, CleanTimer1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
