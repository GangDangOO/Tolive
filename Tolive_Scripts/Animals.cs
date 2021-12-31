using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Animals : MonoBehaviour
{
    string[] AnimalState = { "Patrol", "Runaway", "Attack" };
    bool FirstAtk = false;
    string State;
    // Animator : 0 = Idle, 1 = Walk, 2 = Run, 3 = Attack, 4 = Eat, 5 = Dead
    Animator Anim;
    GameObject Player;
    Animator PlayerAnim;
    public float moveSpeed;
    int RdValue;
    float RdRot;
    float MoveCooltime;
    [HideInInspector]
    public bool attack = false;
    public float ATKcool;
    bool A = false;
    Transform B;
    SphereCollider ThisCol;
    public bool isDead = false; // 죽음체크
    Rigidbody m_rigidbody;
    Stat PlayerStat;
    Animals[] AllAnimal;
    

    [Header("AnimalState")]
    public int AnimalHP; // 체력
    public int AnimalATK; // 공격력
    public int AnimalDEF; // 방어력

    int[] SaveState = new int[3]; // 스탯초기화

    [HideInInspector] public AudioSource MyAudio;
    [Header("AnimalSound")]
    public AudioClip[] AnimalSound;

    bool AudioCheck = false;
    bool Chickensound = false;

    DropItem ThisItem;

    private void Awake()
    {
        AllAnimal = GameObject.FindObjectsOfType<Animals>();
        PlayerStat = GameObject.FindWithTag("Player").GetComponent<Stat>();
        ThisItem = transform.GetComponent<DropItem>();
        MyAudio = transform.GetComponent<AudioSource>();
        Anim = gameObject.GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
        PlayerAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl UserControl;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Scene 1") {
            UserControl = GameObject.FindObjectOfType<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>();
        }
        if(gameObject.tag == "AnimalC" || gameObject.tag == "AnimalB")
        {
            ThisCol = gameObject.GetComponentInChildren<SphereCollider>();
            ThisCol.enabled = false;
        }
        SaveState[0] = AnimalHP;
        SaveState[1] = AnimalATK;
        SaveState[2] = AnimalDEF;
        State = AnimalState[0];
        
    }

    private void Update()
    {
        if(isDead == false)
        {
            CheckAnimal();
            Main();
            ThisDead();
        }
    }

    void CheckAnimal()
    {
        MoveCooltime += Time.deltaTime;
        if(gameObject.tag == "AnimalA")
        {
            AnimalA();
        }
        if(gameObject.tag == "AnimalB")
        {
            AnimalB();
        }
        if(gameObject.tag == "AnimalC")
        {
            AnimalC();
        }
    }
    void AnimalA() // 비공형
    {
        if(Vector3.Distance(transform.position, Player.transform.position) < 8 || FirstAtk == true)
        {
            if (SceneManager.GetActiveScene().name == "Scene 1") {
                if(UserControl.crouch == false) {
                    State = AnimalState[1];
                }
            } else State = AnimalState[1];
        }
        if(Vector3.Distance(transform.position, Player.transform.position) > 30)
        {
            State = AnimalState[0];
            FirstAtk = false;
        }
    }
    void AnimalB() // 선공형
    {

        
        if (Vector3.Distance(transform.position, Player.transform.position) < 20 || FirstAtk == true)
        {
            if (SceneManager.GetActiveScene().name == "Scene 1") {
                if (UserControl.crouch == false) {
                    State = AnimalState[2];
                }
            } else State = AnimalState[2];
        }
        if (Vector3.Distance(transform.position, Player.transform.position) > 40)
        {
            State = AnimalState[0];
            FirstAtk = false;
        }
    }
    void AnimalC() // 비선공형
    {
        if (FirstAtk == true)
        {
            State = AnimalState[2];
        }
        else
        {
            State = AnimalState[0];
            FirstAtk = false;
        }
    }
    void Main()
    {
        switch (State)
        {
            case "Patrol":
                doPatrol();
                if (AudioCheck == false)
                {
                    float RDsound = Random.Range(5.0f, 7.5f);
                    StartCoroutine(Growl_Sound(RDsound));
                }
                break;
            case "Runaway":
                doRunaway();
                break;
            case "Attack":
                doAttack();
                break;
            default:
                break;
        }
    }

    void doPatrol() // 정찰상태
    {
        if(MoveCooltime > 2.5f)
        {
            if(A == false)
            {
                StartCoroutine(RandomMove());
                A = true;
            }
        }
        switch (RdValue)
        {
            case 0:
                if (MoveCooltime < 5.0f && MoveCooltime > 2.5f)
                {
                    Anim.SetInteger("AnimalState", 0);
                    transform.Rotate(Vector3.up * RdRot * Time.deltaTime);
                }
                else if (MoveCooltime > 5.0f)
                {
                    MoveCooltime = 0;
                    A = false;
                }
                break;
            case 1:
                if (MoveCooltime < 5.0f && MoveCooltime > 2.5f)
                {
                    Anim.SetInteger("AnimalState", 1);
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                }
                else if (MoveCooltime > 5.0f)
                {
                    Anim.SetInteger("AnimalState", 0);
                    MoveCooltime = 0;
                    A = false;
                }
                break;
            default:
                break;
        }
    }
    IEnumerator RandomMove() // 정찰상태 시 이동경로결정
    {
        RdValue = Random.Range(0, 2);
        RdRot = Random.Range(-90.0f, 90.0f);
        yield return null;
    }

    void doRunaway() // 비선공일 시 플레이어에게서 도망침
    {
        Anim.SetInteger("AnimalState", 2);
        transform.LookAt(2 * transform.position - Player.transform.position);
        Vector3 direction = (transform.position - Player.transform.position).normalized;
        transform.position += direction * (moveSpeed * 3) * Time.deltaTime;
        if(transform.name == "Chicken" && Chickensound == false)
        {
            Chickensound = true;
            StartCoroutine(ChickenRun(2.5f));
        }
    }

    IEnumerator ChickenRun(float time)
    {
        MyAudio.clip = AnimalSound[1];
        MyAudio.Play();
        yield return new WaitForSeconds(time);
        Chickensound = false;
    }
    void doAttack()
    {
        if(Vector3.Distance(transform.position, Player.transform.position) < 2) // 플레이어와의 거리
        {
            if(attack == false) // 플레이어 공격
            {
                transform.LookAt(Player.transform.position);
                Anim.SetInteger("AnimalState", 3);
                attack = true;
                StartCoroutine(AttackCooltime(ATKcool));
            }
        }
        else if(attack == false) // 공격 비활성화 시 플레이어 재추격
        {
            Anim.SetInteger("AnimalState", 2);
            transform.LookAt(Player.transform.position);
            Vector3 direction = (transform.position - Player.transform.position).normalized;
            transform.position -= direction * (moveSpeed * 3) * Time.deltaTime;
        }
    }

    IEnumerator AttackCooltime(float Cooltime) // 공격 시 쿨타임 및 트리거 관리
    {
        ThisCol.enabled = true;
        yield return new WaitForSeconds(Cooltime);
        ThisCol.enabled = false;
        attack = false;
    }

    void ThisDead()
    {
        if(AnimalHP <= 0)
        {
            isDead = true;
            if(AnimalSound.Length != 0)
            {
                MyAudio.Stop();
                MyAudio.clip = AnimalSound[AnimalSound.Length - 1];
                MyAudio.Play();
            }
            if(gameObject.name == "Boss_Bear")
            {
                potal AWW = GetComponent<potal>();
                AWW.ASD();
            }
            if(gameObject.name == "Boss_Bear3")
            {
                StartCoroutine(LoadEnd());
            }
            Anim.SetInteger("AnimalState", 5);
            ThisItem.Drop();
            StartCoroutine(Dead());
        }
    }
    IEnumerator LoadEnd()
    {
        yield return new WaitForSeconds(3f);
        LoadingScene.LoadScene("Ending");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Inventory.op.name ||
            other.gameObject.name == "Arrow(Clone)" ||
            other.gameObject.name == "SlingRock(Clone)")
        {
            
            FirstAtk = true;
        } else if(other.gameObject.tag == "Player")
        {
            int Dmg = AnimalATK - PlayerStat.PlayerDEF;
            if(Dmg <= 0)
            {
                PlayerStat.health -= 1;
            }
            else
            {
                PlayerStat.health -= Dmg;
            }
        }
        if (PlayerStat.health <= 0) {
            PlayerAnim.SetInteger("Dead", 5);
            for (int i = 0; i < AllAnimal.Length; i++)
            {
                AllAnimal[i].enabled = false;
            }
            gameObject.AddComponent<GameOver>();
        }
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(3f);
        AnimalHP = SaveState[0];
        AnimalATK = SaveState[1];
        AnimalDEF = SaveState[2];
        gameObject.SetActive(false);
    }

    IEnumerator Growl_Sound(float time)
    {
        if(AnimalSound.Length != 0)
        {
            MyAudio.clip = AnimalSound[0];
            MyAudio.Play();
            AudioCheck = true;
            yield return new WaitForSeconds(time);
            AudioCheck = false;
        }
    }
}
