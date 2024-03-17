/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover2 : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Movement speed in meters per seconds")]
    float speed = 1f;


    [SerializeField]
    KeyCode upKey = KeyCode.UpArrow;
    [SerializeField]
    KeyCode downKey = KeyCode.DownArrow;
    [SerializeField]
    KeyCode rightKey = KeyCode.RightArrow;
    [SerializeField]
    KeyCode leftKey = KeyCode.LeftArrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.UpArrow)) {
            transform.position += new Vector3(0,speed*Time.deltaTime,0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

        }
    }
}
*/