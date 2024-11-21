using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CustomerScript : MonoBehaviour
{
    public Text require;
    public Text percent;
    /* 기본 75%시작     참치  60% 시작    돈까스 10%시작
    김, 밥, 계란, 단무지, 햄, 맛살, 깻잎 = 기본
                                           , 참치마요 = 참치김밥
                                           , 돈까스 = 돈까스김밥*/
                                           

    //string[] answerTarget;

    // Start is called before the first frame update
    void Start()
    {
        require = GameObject.Find("requireText").GetComponent<Text>();
        int r;
        percent = GameObject.Find("Percent").GetComponent<Text>();
        

    }

    // Update is called once per frame
    
    
}
