using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTonScript : MonoBehaviour
{
    private static SingleTonScript _instance = null;
    private static GameObject container;

    
    public string[] saveTarget;         //플레이어가 넣는 재료

    public int percentage=0;

    public int money=40000;
//    public  GameObject[] ingres= new GameObject[20];



    public static SingleTonScript Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(SingleTonScript)) as SingleTonScript;

                if (_instance == null)
                {
                    Debug.LogError("There's no active SingleTonScript object");
                }
            }
            return _instance;
        }
    }


}
