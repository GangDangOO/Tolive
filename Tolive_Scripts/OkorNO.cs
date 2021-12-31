using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OkorNO : MonoBehaviour
{
   /* private AudioManager theAudio;
    public key_sound;
    public enter_sound;
    public cancel_sound;*/

    public GameObject up_Panel;
    public GameObject down_Panel;
    public Text up_Text;
    public Text down_Text;

    public bool activated; //대기할때
    private bool keyinput; //필요할때만 키 입력
    private bool result = true; //선택할때 true or false

    public void Selected() { //방향키
        result = !result;

        if (result) {
            up_Panel.gameObject.SetActive(false); //Panel로 가리지 않음
            down_Panel.gameObject.SetActive(true);//Panel로 가림
        }else {
            up_Panel.gameObject.SetActive(true);
            down_Panel.gameObject.SetActive(false);
        }
    }
    public void ShowTwoChoice(string _upText, string _DownText) { //UI 띄우고 초기화
        activated = true; //활성화
        result = true;    //기본값
        up_Text.text = _upText;
        down_Text.text = _DownText;

        up_Panel.gameObject.SetActive(true);
        down_Panel.gameObject.SetActive(true);

        StartCoroutine(ShowTwoChoice());
    }
    public bool GetResult() {
        return result;
    }
    IEnumerator ShowTwoChoice() {
        yield return new WaitForSeconds(0.01f);
        keyinput = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (keyinput) { //키입력할때
            if (Input.GetKeyDown(KeyCode.DownArrow)) {

                Selected();
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow)) {
                Selected();
            }
            else if (Input.GetKeyDown(KeyCode.Z)) {
                keyinput = false; //더이상 이뤄지지않게
                activated = false; //더이상 이뤄지지않게
            }else if (Input.GetKeyDown(KeyCode.X)) {
                keyinput = false;
                activated = false;
                result = false;//취소 할경우
                    
            }

        }
    }
    public void OnClickOkNo(Button A) {

        if(A.name == "OK_Panel") {
            up_Panel.gameObject.SetActive(true);
            activated = false;
        }
        if (A.name == "NO_Panel") {
            down_Panel.gameObject.SetActive(true);
            activated = false;
            result = false;
        }
    }
}
