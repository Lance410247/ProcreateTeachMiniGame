using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class SketchColorArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject colorButton;
    public GameObject _paintingStep;
    public int step;
    public bool isHovering=false;
    public bool isColorStarted=false;
    public GameObject hand;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colorButton = GameObject.Find("ColorButton_QC");
        _paintingStep = GameObject.Find("PaintingStep");
        hand = GameObject.Find("Hand");
    }

  
    public void OnPointerEnter(PointerEventData eventData)
    {
       
        if (isHovering) return;
      //  Debug.Log("滑鼠進入");
        colorButton.TryGetComponent<QuickColoring>(out var quickColoring);
            if (quickColoring.isColorStarted)
            {
                isColorStarted = true;
              //  Debug.Log("成功上色");
            }
            
        
        isHovering = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isColorStarted = false;
        isHovering = false;
       //   Debug.Log("滑鼠離開");
        
    }
    // Update is called once per frame
    void Update()
    {
        this.TryGetComponent<UIOBjectQC>(out var uIOBjectQC);
        if (!uIOBjectQC.correctFlag)
        {
            return;
        }
        if (Input.GetMouseButtonUp(0)&&isHovering) {

           // Debug.Log("成功拖行");
            if (isColorStarted)
            {
                _paintingStep.TryGetComponent<QuickColoringStep>(out var quickColoringStep);
                quickColoringStep.SpecificStep(step);

                  Debug.Log("成功上色");
                uIOBjectQC.CorrectStep(6);
                isColorStarted = false;
                return;
            }
            
        }
        hand.TryGetComponent<Fingers>(out var fingers);
        if (fingers.IsDragging)
        {
            Debug.Log("不成功上色");

            UIManager.Instance.ReadDialog("QuickColoringStep5fail");
        }
        
    }
}
