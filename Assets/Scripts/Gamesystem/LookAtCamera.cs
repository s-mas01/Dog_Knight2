using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Enemy��UI��Camera�̕��Ɍ�������
* 
*/

public class LookAtCamera : MonoBehaviour
{

    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}