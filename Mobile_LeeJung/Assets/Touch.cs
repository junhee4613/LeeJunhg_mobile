using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;
public class Touch : MonoBehaviour
{
    public GameObject login_sign;
    public GameObject sign;
    public GameObject splash;
    public Image splash_background_balck;
    public GameObject main;
    public Button close;
    public Button duplicate_check;
    public InputField password1;
    public InputField password2;
    public Text text;
    public GameObject check_main;
    public GameObject check_Image;
    public Text duplicate_check_text;
    public InputField[] login_text = new InputField[2];
    public bool[] sign_bool = new bool[2];
    public InputField[] sign_id_password = new InputField[2];
    public Text login_text_dlfwl;


    public string[] account = new string[2];


    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Splash_Start());
    }

    // Update is called once per frame
    void Update()
    {
        if (password1.text.Length > 0 && sign.activeSelf)
        {
            if (password1.text == password2.text)
            {
                text.text = "비밀번호가 일치합니다.";
                sign_bool[1] = true; ;
            }
            else
            {
                text.text = "비밀번호가 일치 하지 않습니다.";
                sign_bool[1] = false;
            }
        }
        else
        {
            text.text = "";
            sign_bool[1] = false;
        }
    }
    public void Sign_button()
    {
        sign.SetActive(true);
        login_sign.SetActive(false);
    }
    public void Account_button()
    {
        if(sign_bool[0] && sign_bool[1])
        {
            for (int i = 0; i < account.Length; i++)
            {
                account[i] = sign_id_password[i].text;
            }
            sign.SetActive(false);
            login_sign.SetActive(true);
        }
        else if(!sign_bool[0])
        {
            duplicate_check_text.text = "중복체크를 완료 해주십시오";
        }
    }
    public void Login()
    {
        if(account[0] == login_text[0].text && account[1] == login_text[1].text && login_text[0].text.Length != 0 && login_text[1].text.Length != 0)
        {
            main.SetActive(true);
            login_sign.SetActive(false);
            check_Image.transform.DOScale(Vector3.one, 1);
        }
        else if(account[0] != login_text[0].text)
        {
            login_text_dlfwl.text = "존재하지 않는 계정입니다.";
        }
        else if(account[1] == login_text[1].text)
        {
            login_text_dlfwl.text = "비밀번호가 일치하지 않습니다.";

        }
    }
    public void Close()
    {
        check_main.gameObject.SetActive(false);
    }
    IEnumerator Splash_Start()
    {
        splash_background_balck.DOFade(0, 1);
        yield return new WaitForSeconds(1.5f);
        splash_background_balck.DOFade(1, 1);
        yield return new WaitForSeconds(1.5f);
        splash.SetActive(false);
        splash_background_balck.gameObject.SetActive(false);
        login_sign.SetActive(true);
    }
    public void Duplicate_check()
    {
        if(sign_id_password[0].text.Length > 0)
        {
            duplicate_check_text.text = "사용 가능한 아이디입니다.";
            sign_bool[0] = true; 
        }
    }
}
