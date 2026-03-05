
using UnityEngine;
using System.Collections;
using System.Threading;
/// <summary>
/// 實作抽象的單例模式
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class MonoSingleton<T> : MonoBehaviour  where T :MonoSingleton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError(typeof(T).ToString() + "isNull");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this as T; 
    }


}







