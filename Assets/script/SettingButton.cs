using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  public Sprite SelectingImage;
  public Sprite UnselectingImage;
  public Image thisobject;
    public GameObject settingPanel;

  
    public void ChangeImageSelecting()
    {
        thisobject.sprite = SelectingImage;
        settingPanel.SetActive(true);
    }
    public void ChangeImageUnselecting()
    {
        thisobject.sprite = UnselectingImage;
        settingPanel.SetActive(false);
    }
}
