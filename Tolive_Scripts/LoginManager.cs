using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    [Header("LoginPanel")]
    public InputField IDInputField;
    public InputField PassWordInputField;
    public GameObject SucDesPanel; //로그인 성공했을때 띄워줄 패널
    public GameObject FailDesPanel; //로그인 실패했을때 설명창 패널

    [Header("CreateAccountPanel")]
    public InputField New_IDInputField;
    public InputField New_PassWordInputField;
    public InputField New_NameInputField;
    public GameObject CreateAccountPanel; //계정생성하는 패널 켜주는거임

    public GameObject CreateSucPanel; //계정 생성 성공패널
    public GameObject CreateFailPanel; //계정 생성 실패패널



    public void LoginBtn() {
        StartCoroutine(LoginCo());
    }

    IEnumerator LoginCo() {
        Debug.Log(IDInputField.text);
        Debug.Log(PassWordInputField.text);
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>(); //유니티 네트워킹의 클래스
        formData.Add(new MultipartFormDataSection("Input_user", IDInputField.text));
        formData.Add(new MultipartFormDataSection("Input_pass", PassWordInputField.text));

        UnityWebRequest www = UnityWebRequest.Post("lth0314.dothome.co.kr/Login.php", formData);
        //localhost라고 쓰면 안되고 위처럼 아이피를 직접 써줘야함
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) { //에러가 가는 곳
            Debug.Log(www.error);
 
        } else {
            byte[] results = www.downloadHandler.data;
            string decodedString = Encoding.UTF8.GetString(results);
            //여기로 결과는 전부다 들어옴 , 맞든 안맞든
            print("decodedString"+decodedString);
            if (decodedString.Equals("Match")) {
                SucDesPanel.SetActive(true);
                StartCoroutine(nextScene());
                //성공하면 다음 씬으로 넘기거나 조건넣으면됨
            } else {
                FailDesPanel.SetActive(true); //실패안내창 띄워주고
                StartCoroutine(loginFail());
            }
        }
    }

    IEnumerator loginFail() { //로그인실패 패널 다시 꺼주는거
        yield return new WaitForSeconds(3f); //3초후에 다시 꺼준다
        FailDesPanel.SetActive(false);
    }

    IEnumerator nextScene() {
        yield return new WaitForSeconds(2f); //2초후에 씬 넘김
        SceneManager.LoadScene("Start");
    }


    public void OpenCreateAccountBtn() { //계정생성 버튼 누르면 패널 켜주는곳
        CreateAccountPanel.SetActive(true);
    }

    public void createAccountBtn() { //계정을 생성합니다 버튼 누르면 실행됨
        StartCoroutine(CreateCo()); // 코루틴이 실행되고
    }

    IEnumerator CreateCo() {
        Debug.Log(IDInputField.text);
        Debug.Log(PassWordInputField.text);
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>(); //유니티 네트워킹의 클래스
        formData.Add(new MultipartFormDataSection("Input_user", New_IDInputField.text));
        formData.Add(new MultipartFormDataSection("Input_pass", New_PassWordInputField.text));
        formData.Add(new MultipartFormDataSection("name", New_NameInputField.text));

        UnityWebRequest www = UnityWebRequest.Post("lth0314.dothome.co.kr/AccountCreate.php", formData);
        //localhost라고 쓰면 안되고 위처럼 아이피를 직접 써줘야함
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) { //에러가 가는 곳
            Debug.Log(www.error);

        } else {
            byte[] results = www.downloadHandler.data;
            string decodedString = Encoding.UTF8.GetString(results);

            //여기로 결과는 전부다 들어옴 , 맞든 안맞든
            print(decodedString);
            if (decodedString.Contains("Success")  ) {
                //계정생성 성공하면 다음 씬으로 넘기거나 조건넣으면됨
                CreateSucPanel.SetActive(true);
                StartCoroutine(sucPanelOff());
                print("계정생성 성공");
            } else {
                CreateFailPanel.SetActive(true);
                StartCoroutine(failPanelOff());
                print("계정생성 실패");
            }
        }
    }
    IEnumerator sucPanelOff() { //계정생성 성공 패널 다시 꺼주는거
        yield return new WaitForSeconds(3f); //3초후에 다시 꺼준다
        FailDesPanel.SetActive(false);
    }
    IEnumerator failPanelOff() { //로그인실패 패널 다시 꺼주는거
        yield return new WaitForSeconds(3f); //3초후에 다시 꺼준다
        FailDesPanel.SetActive(false);
    }


    public void BackLoginBtn() {  // 로그인화면으로 돌아가는 버튼
        CreateAccountPanel.SetActive(false);
    }
}
