using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Enemy��HP�Q�[�W�̊Ǘ�
public class EnemyUIManager : MonoBehaviour
{
    public Slider hpSlider;

    public void Init(EnemyManager enemyManager)
    {
        hpSlider.maxValue = enemyManager.hp;
        hpSlider.value = enemyManager.hp;
    }
    public void UpdateHP(int hp)
    {
        hpSlider.value = hp;
    }
}