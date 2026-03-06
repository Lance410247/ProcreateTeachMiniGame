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
    public GameObject clickEffectPrefab;
    public GameObject clickEffectPrefab2;
    public GameObject clickEffectPrefab3;
    public Canvas canvas;

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

        if (Input.GetMouseButtonDown(0)) {
            if (currentFinger == FingersNumber.OneFinger || currentFinger == FingersNumber.NoFinger)
            {
                SpawnEffect(clickEffectPrefab);
            }
            else if (currentFinger == FingersNumber.TwoFinger)
            {

                SpawnEffect(clickEffectPrefab2);



            } else if (currentFinger == FingersNumber.ThirdFinger)
            {
                SpawnEffect(clickEffectPrefab3);
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
