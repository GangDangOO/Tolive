using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stat : MonoBehaviour
{
    Animator anim;
    Rigidbody m_rigidbody;
    BoxCollider AtkCol;
    public int health = 100; //체력
    public int x = 100; //굶주림
    public int y = 100; //갈증 
    public int z = 10; //독 지속시간
    public int PlayerATK = 5; //캐릭터 기본공격력
    public int PlayerDEF = 0; //캐릭터 기본 방어력
    public float time;
    public float time2; //독 지속시간 감소 시간
    public Text State1;
    public Text State2;
    public Text HealthState;
    public Text PoisonTime; //독 지속시간
    GameObject ThisObj; //캐릭터 정보창 
    GameObject DeadPoint;
    float a; // 캔버스 채도 (공격 받앗을때)
    public Text ATKState;
    public Text DEFState;
    Animals animal;

    [HideInInspector] public static GameObject MainView;
    [HideInInspector] public static GameObject DeadView;
    //public GameObject Camera;
    //int ran = Random.Range(5, 11);
    int Armorlife = 100;
    public GameObject PoisonEffect; //독 사용
    public static Stat instance;



    private void Awake()
    {
        if (instance == null)
            instance = this;
        MainView = GameObject.Find("MainCanvas");
        DeadView = GameObject.Find("GameOver");
        ThisObj = GameObject.Find("CharInfo");
        State1 = GameObject.Find("Stats01_#").GetComponent<Text>();
        State2 = GameObject.Find("Stats02_#").GetComponent<Text>();
        HealthState = GameObject.Find("Health_#").GetComponent<Text>();
        State1.text = x.ToString();
        State2.text = y.ToString();
        HealthState.text = health.ToString();
        ATKState = GameObject.Find("Melee_#").GetComponent<Text>();
        DEFState = GameObject.Find("Ranged_#").GetComponent<Text>();
        ATKState.text = PlayerATK.ToString();
        //Camera = GameObject.Find("Camera2");
        PoisonEffect = GameObject.Find("Poison");
        PoisonTime = GameObject.Find("Poison").GetComponentInChildren<Text>();
        PoisonTime.text = z.ToString();
        DeadPoint = GameObject.Find("Danger");
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Scene 1") {
            StartCoroutine(setTime(time));
            StartCoroutine(setTime2(time));
        }
        else if (SceneManager.GetActiveScene().name == "Cave")
        {
            StartCoroutine(CavesetTime(time));
            StartCoroutine(CavesetTime2(time));
        }
        anim = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        ThisObj.SetActive(false);
        DeadView.SetActive(false);
        //Camera.SetActive(false);
        PoisonEffect.SetActive(false);
        DeadPoint.SetActive(false);
    }

    IEnumerator setTime(float sec)
    {
        while (true)
        {
            yield return new WaitForSeconds(sec);
            if (x > 0)
            {
                x -= 5;
            }
        }

    }
    private void Update() {
        State1.text = x.ToString();
        State2.text = y.ToString();
        HealthState.text = health.ToString();
        if (x <= 40) {
            MainView.GetComponent<Image>().color = new Color(255, 0, 0, 0.3f);
            DeadPoint.SetActive(true);
        } else if (x > 40) {
            MainView.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            DeadPoint.SetActive(false);
        }
        if (x <= 0) {
            anim.SetInteger("Dead", 5);
            StopAllCoroutines();
            m_rigidbody.constraints = m_rigidbody.constraints | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            gameObject.AddComponent<GameOver>();
            this.enabled = false;
        }
        if (y <= 40) {
            MainView.GetComponent<Image>().color = new Color(255, 0, 0, 0.3f);
            DeadPoint.SetActive(true);
        } else if (y > 40) {
            MainView.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            DeadPoint.SetActive(false);
        }
        if (y <= 0) {
            anim.SetInteger("Dead", 5);
            StopAllCoroutines();
            m_rigidbody.constraints = m_rigidbody.constraints | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            gameObject.AddComponent<GameOver>();
            this.enabled = false;
        }
    }
    IEnumerator setTime2(float sec) {
        while (true) {
            yield return new WaitForSeconds(sec);
            if (y > 0) {
                y -= 5;
            }
        }

    }
    IEnumerator CavesetTime(float sec)
    {
        while (true)
        {
            yield return new WaitForSeconds(sec);
            if (x > 0)
            {
                x -= 5;
                if (x <= 40) {
                    MainView.GetComponent<Image>().color = new Color(255, 0, 0, 0.3f);
                    DeadPoint.SetActive(true);
                } else if (x > 40) {
                    MainView.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    DeadPoint.SetActive(false);
                }
            }
            else if (x <= 0)
            {

                StopAllCoroutines();
                m_rigidbody.constraints = m_rigidbody.constraints | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                gameObject.AddComponent<GameOver>();
                this.enabled = false;
            }
        }

    }
    IEnumerator CavesetTime2(float sec) {
        while (true) {
            yield return new WaitForSeconds(sec);
            if (y > 0) {
                
                y -= 5;
                if (y <= 40) {
                    MainView.GetComponent<Image>().color = new Color(255, 0, 0, 0.3f);
                    DeadPoint.SetActive(true);
                } else if (y > 40) {
                    MainView.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    DeadPoint.SetActive(false);
                }
            } else if (y <= 0) {

                StopAllCoroutines();
                m_rigidbody.constraints = m_rigidbody.constraints | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                gameObject.AddComponent<GameOver>();
                this.enabled = false;
            }
        }

    }

}