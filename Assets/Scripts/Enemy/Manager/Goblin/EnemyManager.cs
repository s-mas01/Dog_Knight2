using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    

    //動き系
    public Transform target;
    NavMeshAgent agent;
    Animator animator;
    bool At;


    //当たり判定系
    public Collider weaponCollider;

    //ステータス
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO playerStatusSO;
    public EnemyUIManager enemyUIManager;
    public int hp;
    private int damage;


    //ゲームシステム
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

        //敵の薙ぎ払い攻撃判定用
        if (Input.GetKeyDown(KeyCode.E))
        {
            At = true;
        }
        //目的を達成(ゲームクリア)したら、Spaceを押すとMapPick画面に戻る
        if (clearManager.Clear == true && Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.visible = true;
            SceneManager.LoadScene("PickMap");
        }
    }
    
    //武器当たり判定
    public void HideColliderWeapon()
    {
        weaponCollider.enabled = false;
    }

    public void ShowColliderWeapon()
    {
        weaponCollider.enabled = true;
    }


    //ダメージ計算
    void Damage(int damage)
    {
        //薙ぎ払いダメージ
        if(At==true)
        {
            damage = playerStatusSO.attack2;
            At = false;
        }
        //通常攻撃の場合
        hp -= damage;
        
        if (hp <= 0)
        {
            hp = 0;
            clearManager.count();
            animator.SetTrigger("Die");
            Destroy(gameObject, 3f);


        }
        //UI更新
        enemyUIManager.UpdateHP(hp);
        //Debug.Log("Enemy残りHP：" + hp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            damage = playerStatusSO.attack1;
            if (damage != 0)
            {
                // ダメージを与えるものにぶつかったら
                animator.SetTrigger("Hurt");
                Damage(damage);
            }
        }

    }
}

