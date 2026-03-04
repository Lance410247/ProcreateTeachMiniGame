using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public enum NarratorVariant
{
    normal,
    talk,
    smile,
}
public class Narrator : MonoBehaviour
{

    public Sprite[] variant;
    [SerializeField] private GameObject _gameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeVariant();
    }


    // Update is called once per frame
    void Update()
    {
      
    }
    public void ChangeVariant()
    {
        if (_gameObject.TryGetComponent<Image>(out var image))
        {
            image.sprite = variant[0];

        }
    }
    public void ChangeVariant(NarratorVariant _variant)
    {
        if (_gameObject.TryGetComponent<Image>(out var image))
        { }
        try
        {
            image.sprite = variant[(int)_variant];

        }
        catch
        {
            Debug.Log("無法變換圖片");
        }

        
      
    }




}
