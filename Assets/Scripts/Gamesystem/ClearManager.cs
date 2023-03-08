using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour
{
    public static int co=0;
    public int co1=0;
    public bool Clear;
    public GameObject GameClearText;
    public GameObject GetKeyText;
    public GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
        Clear = false;
    }

    // Update is called once per frame
    public void count()
    {
        co = co + 1;
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
