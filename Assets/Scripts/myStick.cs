using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myStick : MonoBehaviour
{
    protected Joystick joystick;
    protected Joybutton joybutton;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType <Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = GetComponent<Transform>().position;

        GetComponent<Transform>().position = new Vector3(joystick.Horizontal * 2f, -3.3f, 0);
    }
}
