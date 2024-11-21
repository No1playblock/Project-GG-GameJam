using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PressAnyKeyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnclickBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
    
}
