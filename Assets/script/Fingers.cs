using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public enum FingersNumber
{
    NoFinger,
    OneFinger,
    TwoFinger,
    ThirdFinger,
  //  Pen
}
public class Fingers : MonoBehaviour
{
    public Sprite[] fingerPicture;
    [SerializeField] private GameObject _gameObject;
    private RectTransform rectTransform;
    [SerializeField]
    private FingersNumber currentFinger;


    public bool lockFingerChange=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //NextFinger();
        rectTransform = GetComponent<RectTransform>();
      //  Debug.Log(currentFinger);
        ChangeFingerImage(currentFinger);
    }
    // Update is called once per frame

    void Update()
    {
        FollowMouse();
        if (!lockFingerChange) 
        {
            if (Input.GetMouseButtonDown(1)) // 右鍵
            {
                NextFinger();
            }
        }
        
    }
    public void ChangeFingerImage(FingersNumber number)
    {
        if (_gameObject.TryGetComponent<Image>(out var image))
        {
            image.sprite = fingerPicture[(int)FingersNumber.OneFinger];
        }
        try
        {
            image.sprite = fingerPicture[(int)number];

        }
        catch
        {
            Debug.Log("無法變換手指圖片");
        }
    }
    public void NextFinger()
    {
        int next = ((int)currentFinger + 1) % System.Enum.GetValues(typeof(FingersNumber)).Length;
        currentFinger = (FingersNumber)next;

        ChangeFingerImage(currentFinger);
    }
    public void FollowMouse()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform,
            Input.mousePosition,
            null,
            out Vector2 localPos
        );

        rectTransform.anchoredPosition = localPos;
    }
   
}
