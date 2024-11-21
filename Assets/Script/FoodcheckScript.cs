using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FoodcheckScript : MonoBehaviour
{
    public GameObject customer;
    public int check = 0;
    public Text percent;
    public Text money;
    public int i;
    public Image[] life;
    public GameObject[] Gameover;
    public Text moneyText2;
    public GameObject GimBap;
    private GameObject t;

    public AudioSource suc;
    public AudioSource fail;
    public AudioSource gmover;

    public GameObject SucImg;
    public GameObject FailImg;
    // Start is called before the first frame update
    void Start()
    {

        //ingres = new GameObject[20];
    }

    // Update is called once per frame
    public void OnclickBtn()           //음식을 냈을때 실행
    {

        
        t = Instantiate(GimBap, new Vector3(0, -3.42f, 0), Quaternion.identity);
        StartCoroutine(term());
        if (Random.Range(1, 100) <= SingleTonScript.Instance.percentage)
        {
            Debug.Log("사기성공");
            suc.Play();
            StartCoroutine(SucCou());
            SingleTonScript.Instance.money += 10000;
        }
        else
        {
            fail.Play();
            Debug.Log("사기 실패");
            StartCoroutine(FailCou());

            Destroy(life[3 - i]);
            i++;
        }
        if(i==4)
        {
            Debug.Log("GameOVer");           //GameOver
            gmover.Play();
            for (int i = 0;  i < 27; i++)
            {
                Gameover[i].SetActive(false);
                moneyText2.text = ""+SingleTonScript.Instance.money;
                Destroy(t); 
            }

        }else
        {
            Instantiate(customer, new Vector3(0, 3.12f, 3), Quaternion.identity);
        }
        money.text = ""+SingleTonScript.Instance.money;
        Destroy(GameObject.Find("Customer(Clone)"));
        SingleTonScript.Instance.percentage = 0;
        percent.text = ""+SingleTonScript.Instance.percentage;

        
    }
    IEnumerator term()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(t);
    }
    IEnumerator SucCou()
    {
        SucImg.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        SucImg.gameObject.SetActive(false);
    }
    IEnumerator FailCou()
    {
        FailImg.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        FailImg.gameObject.SetActive(false);
    }
}
