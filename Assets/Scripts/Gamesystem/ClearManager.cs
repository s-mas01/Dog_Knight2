using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearManager : MonoBehaviour
{
    public static int co=0;
    public int co1=0;
    public bool Clear;
    public Text killText;
    public GameObject GameClearText;
    public GameObject GetKeyText;
    public GameObject Canvas;
    public int Map;

    // Start is called before the first frame update
    void Start()
    {
        killText = GameObject.Find("KillText").GetComponent<Text>();
        killText.text = "ÉSÉuÉäÉìì¢î∞êî : " + co1.ToString()+ " / " + co.ToString();
        Clear = false;
    }

    // Update is called once per frame
    public void count()
    {
        co = co + 1;
        killText.text = "ÉSÉuÉäÉìì¢î∞êî : " + co1.ToString() + " / " + co.ToString();
        //Debug.Log("co:" + co);


        Debug.Log("co1:" + co1);
        if (co == co1)
        {
            Clear = true;
            GameClearText.SetActive(true);
            GetKeyText.SetActive(true);
            Canvas.SetActive(true);
        }
    }
}
