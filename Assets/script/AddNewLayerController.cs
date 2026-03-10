using System;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class AddNewLayerController : MonoBehaviour
{
    public GameObject fatherObject;
    public GameObject sonObject;
    public GameObject sonObjectAddBut;
    public GameObject[] grandsonObject;
    public int AddLayerNumber=0;
    public void Start()
    {
       // Debug.Log(sonObject.transform.childCount);
        grandsonObject = new GameObject[sonObject.transform.childCount];
        for (int i=0; i< sonObject.transform.childCount; i++) 
        {
            var child = sonObject.transform.GetChild(i).gameObject;
            //Debug.Log(child.name);
            grandsonObject[i]=child;


        }
        
        

    }
    public void Update()
    {
        // sonObject.SetActive(fatherObject.activeSelf);

        LayersState();

    }
    public void AddNewLayer() 
    {
        if (AddLayerNumber >= sonObject.transform.childCount) { return; }
        Debug.Log(AddLayerNumber);
        AddLayerNumber++;
    }
    public void LayersState()
    {
        if (!fatherObject.activeSelf)
        {
            sonObjectAddBut.SetActive(false);
            sonObject.SetActive(false);
            return;
        }
        else
        {
            sonObject.SetActive(true);
            sonObjectAddBut.SetActive(true);
        }
            for (int i = 0; i < sonObject.transform.childCount; i++)
            {

                grandsonObject[i].SetActive(false);


            }
        switch (AddLayerNumber)//switch (比對的運算式)
        {
            case 0://狀況一走這個
                grandsonObject[0].SetActive(true);
                break;
            case 1:
                grandsonObject[1].SetActive(true);
                break;
            case 2://狀況二、三走這個
                grandsonObject[2].SetActive(true);
                break;
            default://以上都不符合走這個
                
                break;
        }
    }



}
