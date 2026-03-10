using UnityEngine;
using UnityEngine.EventSystems;

public class QuickColoring : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool isColorStarted;
    public GameObject hand;
    public bool isHovering=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        if (isHovering) return;
      //  Debug.Log("·Æ¹«¶i¤J");
        


        isHovering = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       // isColorStarted = false;
        isHovering = false;
        //Debug.Log("·Æ¹«Â÷¶}");

    }
    public void IsColorStarted()
    {
        hand.TryGetComponent<Fingers>(out var fingers);
        if ( fingers.GetCurrentFinger() == FingersNumber.OneFinger)
        {
            isColorStarted = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isHovering) return;
        hand.TryGetComponent<Fingers>(out var fingers);

       // Debug.Log(fingers.IsDragging);
        if (!fingers.IsDragging) { isColorStarted = false; }
       
    }
}
