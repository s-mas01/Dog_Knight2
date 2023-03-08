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

    //player�̓����n
    private float horizontalInput, verticalInput;
    private Vector3 cameraForward;
    public Vector3 moveForward;


    //music
    public AudioSource audioSource;
    public AudioClip AttackSound;
    public AudioClip DefanceSound;
    public AudioClip HurtSound;

    //�����蔻��n
    private Rigidbody rb;
    private Animator animator;
    public Collider weaponCollider;
    public Collider shieldCollider;


    //�X�e�[�^�X
    [SerializeField] PlayerStatusSO playerStatusSO; //�����̃X�e�[�^�X
    [SerializeField] EnemyStatusSO enemyStatusSO;�@//�G�̃X�e�[�^�X

    //�X�e�[�^�X����p
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

        //�ړ�
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

        //��~
        else
        {
            animator.SetBool("Run", false);
        }


        //���S
        if (isDie == true && Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.visible = true;
            SceneManager.LoadScene("PickMap");
        }
        if (isDie)
        {
            return;
        }

        //�ʏ�U��
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("Attack", true);

        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Attack", false);
        }

        //�ガ�����U��
        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("Attack2", true);

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            animator.SetBool("Attack2", false);
        }

        //�K�[�h
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
    //�U���A�N�V�����������]���s�\�ɂ��邽��
    public void attackTrue()
    {
        AT = true;
    }
    public void attackFalse()
    {
        AT = false;
    }
    //�U���A�N�V�����������]���s�\�ɂ��邽��
    public void defenceTrue()
    {
        DF = true;
    }
    public void defenceFalse()
    {
        DF = false;
    }


    //���퓖���蔻��
    public void HideColliderWeapon()�@//�Ȃ�
    {
        weaponCollider.enabled = false;
    }

    public void ShowColliderWeapon() //����
    {
        weaponCollider.enabled = true;
    }

    //�V�[���Ɠ����蔻��
    public void HideColliderShield()�@//�Ȃ�
    {
        shieldCollider.enabled = false;
        animator.SetBool("Damage", false);
    }

    public void ShowColliderShield() //����
    {
        shieldCollider.enabled = true;
        animator.SetBool("Damage", true);
    }


    //�U�����ʉ�
    public void StartAudio() //����
    {
        audioSource.PlayOneShot(AttackSound);
    }
    public void StartAudio2() //����
    {
        audioSource.PlayOneShot(HurtSound);
    }

    //�_���[�W�v�Z
    void Damage(int damages)
    {
        //�V�[���h�̓����蔻�肪ON���ƃ_���[�W0
        if (shieldCollider.enabled == true)
        {
            audioSource.PlayOneShot(DefanceSound);
            damages = 0;
        }
        //�V�[���h�����蔻��p���p
        else if (damage == 0)
        {

        }
        //��Lif����ʂ�Ȃ��ƃ_���\�W��0�ɂȂ�Ȃ����߂���if���ɓ���
        if (damages > 0)
        {
            animator.SetTrigger("Hurt");
        }
        hp = hp - damages;
        //HP == 0,���S����
        if (hp <= 0)
        {

            hp = 0;
            isDie = true;
            animator.SetTrigger("Die");
            //GameOver UI �\��
            GameOverText.SetActive(true);
            GetKeyText.SetActive(true);
            Canvas.SetActive(true);
        }
        playerUIManager.UpdateHP(hp);
    }

    //�����蔻��@�������������甽��
    private void OnTriggerEnter(Collider other)
    {
        if (isDie)
        {
            return;
        }
        
        //���������������Ȃ̂�����
        if (other.gameObject.CompareTag("Axe"))
        {
            damage = enemyStatusSO.enemyStatusList[0].attack1;
            // �_���[�W��^������̂ɂԂ�������
            Damage(damage);
        }

    }
}

