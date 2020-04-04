using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMove : MonoBehaviour {

    // Use this for initialization

    float xpos; // 소수점까지 지정 가능한 변수 
    float ypos;
    float speed;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(xpos, ypos, 0f);
        ypos = ypos - speed;

        if (ypos < -3f) 
        {
            Destroy(gameObject);
        }
	}
    public void setPostion(float x, float y, float s)
    {
        xpos = x;
        ypos = y;
        speed = s;
    }
}

