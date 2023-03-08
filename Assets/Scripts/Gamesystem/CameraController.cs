using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 playerPos;
    private float speed = 700f;
    private float mouseInputX;
    //private float mouseInputY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        playerPos =player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
        }

        if(Input.GetMouseButton(1))
        {
            Cursor.visible = false;

        }
        transform.position += player.transform.position - playerPos;
        playerPos = player.transform.position;

        mouseInputX = Input.GetAxis("Mouse X");
        //mouseInputY = Input.GetAxis("Mouse Y");

        transform.RotateAround(playerPos, Vector3.up, mouseInputX * Time.deltaTime * speed);
        //transform.RotateAround(playerPos, transform.right, mouseInputY * Time.deltaTime * speed);


    }
}
