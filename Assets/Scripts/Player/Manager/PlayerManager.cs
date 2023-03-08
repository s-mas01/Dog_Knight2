using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    //UI
    public PlayerUIManager playerUIManager;
    public GameObject GameOverText;
    public GameObject GetKeyText;
    public GameObject Canvas;

    //playerの動き系
    private float horizontalInput, verticalInput;
    private Vector3 cameraForward;
    public Vector3 moveForward;


    //music
    public AudioSource audioSource;
    public AudioClip AttackSound;
    public AudioClip DefanceSound;
    public AudioClip HurtSound;

    //当たり判定系
    private Rigidbody rb;
    private Animator animator;
    public Collider weaponCollider;
    public Collider shieldCollider;


    //ステータス
    [SerializeField] PlayerStatusSO playerStatusSO; //自分のステータス
    [SerializeField] EnemyStatusSO enemyStatusSO;　//敵のステータス

    //ステータス制御用
    public int hp;
    public float MoveSpeed;
    private int damage = 0;
    bool isDie;
    bool AT;
    bool DF;


    // Start is called before the first frame update
    void Start()
    {
        AT = false;
        DF = false;
        hp = playerStatusSO.hp;
        MoveSpeed = playerStatusSO.moveSpeed;
        playerUIManager.Init(this);
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        HideColliderWeapon();
        HideColliderShield();
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //移動
        cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        moveForward = cameraForward * verticalInput + Camera.main.transform.right * horizontalInput;
        rb.velocity = moveForward * MoveSpeed + new Vector3(0, rb.velocity.y, 0);
        if (moveForward != Vector3.zero)
        {
            if(AT == true || DF == true)
            {

            }
            else
            {
                transform.rotation = Quaternion.LookRotation(moveForward);
                animator.SetBool("Run", true);
            }
            
        }

        //停止
        else
        {
            animator.SetBool("Run", false);
        }


        //死亡
        if (isDie == true && Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.visible = true;
            SceneManager.LoadScene("PickMap");
        }
        if (isDie)
        {
            return;
        }

        //通常攻撃
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("Attack", true);

        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Attack", false);
        }

        //薙ぎ払い攻撃
        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("Attack2", true);

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            animator.SetBool("Attack2", false);
        }

        //ガード
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Defend", true);
            ShowColliderShield();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Defend", false);
            defenceFalse();
            HideColliderShield();
        }


    }
    //攻撃アクション中方向転換不可能にするため
    public void attackTrue()
    {
        AT = true;
    }
    public void attackFalse()
    {
        AT = false;
    }
    //攻撃アクション中方向転換不可能にするため
    public void defenceTrue()
    {
        DF = true;
    }
    public void defenceFalse()
    {
        DF = false;
    }


    //武器当たり判定
    public void HideColliderWeapon()　//なし
    {
        weaponCollider.enabled = false;
    }

    public void ShowColliderWeapon() //あり
    {
        weaponCollider.enabled = true;
    }

    //シールと当たり判定
    public void HideColliderShield()　//なし
    {
        shieldCollider.enabled = false;
        animator.SetBool("Damage", false);
    }

    public void ShowColliderShield() //あり
    {
        shieldCollider.enabled = true;
        animator.SetBool("Damage", true);
    }


    //攻撃効果音
    public void StartAudio() //あり
    {
        audioSource.PlayOneShot(AttackSound);
    }
    public void StartAudio2() //あり
    {
        audioSource.PlayOneShot(HurtSound);
    }

    //ダメージ計算
    void Damage(int damages)
    {
        //シールドの当たり判定がONだとダメージ0
        if (shieldCollider.enabled == true)
        {
            audioSource.PlayOneShot(DefanceSound);
            damages = 0;
        }
        //シールド当たり判定継続用
        else if (damage == 0)
        {

        }
        //上記if文を通らないとダメ―ジが0にならないためこのif文に入る
        if (damages > 0)
        {
            animator.SetTrigger("Hurt");
        }
        hp = hp - damages;
        //HP == 0,死亡判定
        if (hp <= 0)
        {

            hp = 0;
            isDie = true;
            animator.SetTrigger("Die");
            //GameOver UI 表示
            GameOverText.SetActive(true);
            GetKeyText.SetActive(true);
            Canvas.SetActive(true);
        }
        playerUIManager.UpdateHP(hp);
    }

    //当たり判定　何か当たったら反応
    private void OnTriggerEnter(Collider other)
    {
        if (isDie)
        {
            return;
        }
        
        //当たった物が何なのか判定
        if (other.gameObject.CompareTag("Axe"))
        {
            damage = enemyStatusSO.enemyStatusList[0].attack1;
            // ダメージを与えるものにぶつかったら
            Damage(damage);
        }

    }
}

