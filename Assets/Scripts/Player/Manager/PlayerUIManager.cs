using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Player��HP��UI����
 * �EHP�̍쐬
 * �E�R�[�h����HP�Q�[�W�̕ύX�FHP���擾/�ύX
*/
public class PlayerUIManager : MonoBehaviour
{
    public Slider hpSlider;

    public void Init(PlayerManager playerManager)
    {
        hpSlider.maxValue = playerManager.hp;
        hpSlider.value = playerManager.hp;
    }

    public void UpdateHP(int hp)
    {
        hpSlider.value = hp;
    }

}