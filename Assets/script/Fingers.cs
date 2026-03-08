using Coffee.UIExtensions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
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
    public GameObject clickEffectPrefab;
    public GameObject clickEffectPrefab2;
    public GameObject clickEffectPrefab3;
    public GameObject dragEffect;
    public Canvas canvas;

    public bool lockFingerChange=false;
    public float dragDistance = 150f; // 觸發距離

    

    private Vector2 startPos;
    private bool isDragging = false;
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

        if (UIManager.Instance.playOption)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentFinger == FingersNumber.OneFinger || currentFinger == FingersNumber.NoFinger)
                {
                    SpawnEffect(clickEffectPrefab);
                }
                else if (currentFinger == FingersNumber.TwoFinger)
                {

                    SpawnEffect(clickEffectPrefab2);



                }
                else if (currentFinger == FingersNumber.ThirdFinger)
                {
                    SpawnEffect(clickEffectPrefab3);
                }
            }
            //按下滑鼠
            if (Input.GetMouseButtonDown(0))
            {
                dragEffect.GetComponent<RectTransform>().position = rectTransform.position;
                dragEffect.SetActive(true);
                startPos = Input.mousePosition;
                isDragging = true;
            }

            // 放開滑鼠
            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                Vector2 endPos = Input.mousePosition;

                float dragY = startPos.y - endPos.y; // 往下拖才會是正值

                if (dragY > dragDistance)
                {
                    Debug.Log("成功拖行" + currentFinger);
                    if (currentFinger == FingersNumber.ThirdFinger)
                    {
                        
                        UIManager.Instance.ShowImage(UIManager.Instance.toolPanels[12]);
                    }

                }
                else
                {
                    try {
                        GameObject.Find("PaintingStep").TryGetComponent<PaintingStep>(out var paint);

                        paint.FrontStep(currentFinger);
                        paint.NextStep(currentFinger);
                    }
                    catch
                    {
                        
                    }
                    
                }
                    dragEffect.SetActive(false);
                SpawnEffect(clickEffectPrefab);
                isDragging = false;
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
        ChangeFingerDialog();
        ChangeFingerImage(currentFinger);
    }

    public void ChangeFingerDialog()
    {
        if (currentFinger==FingersNumber.TwoFinger)
        {
            UIManager.Instance.ReadDialog("TwoFinger");


        }else if (currentFinger == FingersNumber.ThirdFinger)
        {

            UIManager.Instance.ReadDialog("ThirdFinger");
        }



    }


    public FingersNumber GetCurrentFinger()
    {
        return currentFinger;
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
    void SpawnEffect(GameObject Prefab)
    {
        

        GameObject effect = Instantiate(Prefab, canvas.transform);

        effect.GetComponent<RectTransform>().position = rectTransform.position;

        Destroy(effect, 1f);
    }
}
