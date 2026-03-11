using UnityEngine;

public class QCCaseChange : MonoBehaviour
{

    public int _case=1;
    public string[] caseDialog;
    public int[] commandNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }



    public void ChangeCaseNumber(int _caseNumber)
    {
        _case = _caseNumber;
    }

    public void CorrectCaseStep()
    {
        this.TryGetComponent<UIOBjectQC>(out var uIOBject);
        switch (_case) {
            case 1:
                uIOBject.SetDialog(caseDialog[0]);
                uIOBject.CorrectStep(commandNumber[0]);
                break;

            case 2:

                uIOBject.SetDialog(caseDialog[1]);
                uIOBject.CorrectStep(commandNumber[1]);
                break;
        
        
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
