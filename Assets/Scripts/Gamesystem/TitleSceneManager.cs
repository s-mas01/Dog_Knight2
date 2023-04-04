using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



// ボタンを押したらBattleシーンに行きたい
public class TitleSceneManager : MonoBehaviour
{
    public GameObject VolumeButton;
    //public GameObject TitleButton;
    private int count = 0;

    public void GoHowTo()
    {
        SceneManager.LoadScene("HowTo");
    }
    public void GoHome()
    {
        SceneManager.LoadScene("Title");
    }
    public void Object()
    {
        SceneManager.LoadScene("Object");
    }
    public void Object1()
    {
        SceneManager.LoadScene("Object1");
    }
    public void Object2()
    {
        SceneManager.LoadScene("Object2");
    }
    public void PickMap()
    {
        SceneManager.LoadScene("PickMap");;
    }
    public void OnStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnStart1()
    {
        SceneManager.LoadScene("SampleScene1");
    }
    public void OnStart2()
    {
        SceneManager.LoadScene("SampleScene2");
    }
    public void OnConfig()
    {
        SceneManager.LoadScene("Config");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
        Application.Quit();//ゲームプレイ終了
#endif
    }

    public void MenuOpen()
    {
        count++;
        VolumeButton.SetActive(true);
        if (count == 2)
        {
            VolumeButton.SetActive(false);
            count = 0;
        }

    }

}
