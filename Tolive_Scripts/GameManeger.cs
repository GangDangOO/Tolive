using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    [Header("LoginPanel")]
    public InputField IDInputField;
    public InputField PassInputField;

    [Header("CreatAccountPanel")]
    public InputField New_IDInputField;
    public InputField New_PassInputField;

    public string LoginUrl;

    void Start() {
        LoginUrl = "lth0314.dothome.co.kr/mysqli_seq_insert.php"; //html안에 있는 mysqli_seq_insert.php파일을 가져옴 (실질적으론 로그인파일이 필요함)
    }

    public void LoginBtn() {

        StartCoroutine(LoginCo());
    }
    IEnumerator LoginCo() {

        Debug.Log(IDInputField.text);
        Debug.Log(PassInputField.text);

        WWWForm form = new WWWForm();
        form.AddField("input_user", IDInputField.text); // php파일로 변환해서 보내주는 
        form.AddField("input_pass", PassInputField.text);

        WWW webRequest = new WWW(LoginUrl, form); //파일을 불러오기
        
        yield return null;

        Debug.Log(webRequest.text);


    }
    public void CreateAccountBtn() {

        //StartCoroutine(LoginCo());
    }

}
