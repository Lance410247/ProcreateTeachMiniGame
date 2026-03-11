using UnityEngine;
using UnityEngine.UI;
public enum QCCommend { 
ShowImage,
ShowExtraImage,
ChangeImage,
AddNewLayer,
DisableAllImage,
isColorStarted,
ReadDialog



}

public class UIOBjectQC : UIObject
{
   public bool correctFlag = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string stepText;
    public GameObject _gameObject;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetObject(GameObject _object)
    {

        _gameObject = _object;

    }
    public void SetDialog(string text)
    {

        stepText = text;

    }
    public void CorrectStep(int commend)
    {
        if (!UIManager.Instance.playOption) { return; }
        if (!correctFlag)
        {
            return;
        }
        else
        {
            correctFlag = false;
            switch (commend) {
                case (int)QCCommend.ShowImage:

                    UIManager.Instance.ShowImage(_gameObject);
                    break;
                case (int)QCCommend.ShowExtraImage:

                    UIManager.Instance.ShowExtraImage(_gameObject);
                    break;
                case (int)QCCommend.ChangeImage:
                     _gameObject.TryGetComponent<SettingButton>(out var settingButton);
                    _gameObject.TryGetComponent<Image>(out var _image);
                    _image.sprite = settingButton.SelectingImage;

                    break;
                case (int)QCCommend.AddNewLayer:

                    _gameObject.TryGetComponent<AddNewLayerController>(out var controller);
                    controller.AddNewLayer();

                    break;
                case (int)QCCommend.DisableAllImage:
                    UIManager.Instance.DisableAllImage();


                    break;
                case (int)QCCommend.isColorStarted:

                    this.TryGetComponent<QuickColoring>(out var qc);

                    qc.IsColorStarted();


                    break;
                case (int) QCCommend.ReadDialog:

                    break;

            }


            UIManager.Instance.ReadDialog(stepText);
        }


    }


    public void SetCorrectFlag(bool i)
    {
        correctFlag = i;
    }
   public  override  void OnSelected()
    {
        if (!isCanBeSelect) return;
        if (textName == " ")
        {
            return;
        }
        // Debug.Log("預留解說接口");
        UIManager.Instance.ReadDialog(textName);
    }
}
