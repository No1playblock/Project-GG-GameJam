using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickScript : MonoBehaviour
{

    private GameObject target;
    int i = 0;
    int cnt = 0;
    
    public Text percent;
    public Text money;
    private Vector2 MousePosition;
    private Camera cam;
    private GameObject ingredient;
    private GameObject[] ingres;

    public AudioSource Click;


    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        SingleTonScript.Instance.saveTarget = new string[100];
        ingres = new GameObject[100];
        SingleTonScript.Instance.percentage = 0;
        money.text = "40000";
    }

    void FixedUpdate()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            CastRay();

            Debug.Log(SingleTonScript.Instance.percentage);
          
        }
        
    }
    public void OnclickBtn()
    {
        for (int i = 0; i < ingres.Length; i++)
        {
            Destroy(ingres[i]);
        }
        ingres = new GameObject[100];
    }
    void CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 
    {
        target = null;
        int r=0;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        if (hit.collider != null)
        { //히트되었다면 여기서 실행
            //Debug.Log (hit.collider.name);  //이 부분을 활성화 하면, 선택된 오브젝트의 이름이 찍혀 나옵니다. 
            target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
            Click.Play();

            ingredient = Resources.Load<GameObject>(""+target.name) as GameObject;
            ingres[i] = Instantiate(ingredient, new Vector3(0, -3.37f, 2.5f - 0.1f * i), Quaternion.identity);
            //SingleTonScript.Instance.ingres[i] = ingredient;


            i++;
            if (target.tag.Equals("Basic"))
            {
                r = Random.Range(5, 9);
                SingleTonScript.Instance.money -= 500;

            }
            else if (target.tag.Equals("Ham"))
            {
                r = Random.Range(20, 31);
                SingleTonScript.Instance.money -= 2000;
            }
        
            else if (target.tag.Equals("Tuna"))
            {
                r = Random.Range(40, 46);
                SingleTonScript.Instance.money -= 3500;
            }
            else if (target.tag.Equals("Pork"))
            {
                r = 50;
                SingleTonScript.Instance.money -= 6000;
            }
            Debug.Log("r : " + r);
            SingleTonScript.Instance.percentage += r;
            if(SingleTonScript.Instance.percentage>=100)
            {
                SingleTonScript.Instance.percentage = 100;

            }
            money.text = "" + SingleTonScript.Instance.money;

            percent.text = "" + SingleTonScript.Instance.percentage;
        }
    }
}
