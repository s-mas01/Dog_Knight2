using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    

    //�����n
    public Transform target;
    NavMeshAgent agent;
    Animator animator;
    bool At;


    //�����蔻��n
    public Collider weaponCollider;

    //�X�e�[�^�X
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO playerStatusSO;
    public EnemyUIManager enemyUIManager;
    public int hp;
    private int damage;


    //�Q�[���V�X�e��
    public ClearManager clearManager;


    void Start()
    {
        clearManager = GetComponent<ClearManager>();
        hp = enemyStatusSO.enemyStatusList[0].hp;
        enemyUIManager.Init(this);
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        HideColliderWeapon();
        At = false;
        damage = 0;
        
    }

    void Update()
    {
        agent.destination = target.position;
        animator.SetFloat("Distance", agent.remainingDistance);

        //�G�̓ガ�����U������p
        if (Input.GetKeyDown(KeyCode.E))
        {
            At = true;
        }
        //�ړI��B��(�Q�[���N���A)������ASpace��������MapPick��ʂɖ߂�
        if (clearManager.Clear == true && Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.visible = true;
            SceneManager.LoadScene("PickMap");
        }
    }
    
    //���퓖���蔻��
    public void HideColliderWeapon()
    {
        weaponCollider.enabled = false;
    }

    public void ShowColliderWeapon()
    {
        weaponCollider.enabled = true;
    }


    //�_���[�W�v�Z
    void Damage(int damage)
    {
        //�ガ�����_���[�W
        if(At==true)
        {
            damage = playerStatusSO.attack2;
            At = false;
        }
        //�ʏ�U���̏ꍇ
        hp -= damage;
        
        if (hp <= 0)
        {
            hp = 0;
            clearManager.count();
            animator.SetTrigger("Die");
            Destroy(gameObject, 3f);


        }
        //UI�X�V
        enemyUIManager.UpdateHP(hp);
        //Debug.Log("Enemy�c��HP�F" + hp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            damage = playerStatusSO.attack1;
            if (damage != 0)
            {
                // �_���[�W��^������̂ɂԂ�������
                animator.SetTrigger("Hurt");
                Damage(damage);
            }
        }

    }
}

