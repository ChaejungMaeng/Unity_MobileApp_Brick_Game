using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class character : MonoBehaviour
{
    Vector3 character_pos;
    Vector3 pos;
    GameObject Chef;
    Texture2D texture;

    bool gameStart = false; 

    public Canvas endGame; // 종료 메세지   
    public Canvas winGame;
    public Canvas intro;

    public Camera myCamera; //카메라
    Vector3 cameraDist; //공에서 카메라까지 거리

    public Text countText;
    public Text winText;

    private int count;

 //   protected Joybutton joybutton;


    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        intro.enabled = true;

        winGame.enabled = false;
        endGame.enabled = false; //처음엔 끄고(비활성화) // 안끄면 처음부터 game over        //종료화면끄기        
        gameStart = true;

        count = 0;
        SetCountText();
        winText.text = ""; 

       // joybutton = FindObjectOfType<Joybutton>();

       /* if (joybutton == true)
         {
             Restart();
         }*/

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButton(0))
        {
            intro.enabled = false;

            pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z));
            // pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        character_pos.x = Mathf.Lerp(character_pos.x, pos.x, 0.1f); //0.1f를 조절함에 따라 속도 차이 생긴다

        //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스 좌표를 스크린 좌표로 바꿔주는 

        transform.position = new Vector3(character_pos.x, transform.position.y, transform.position.z); //삼각함수 계산해서 좌표 가저오는거지

        //x좌표만 바꿔주고 y, z는 유지시켜주기

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            Debug.Log("hit box");

            Renderer chefColor = GameObject.FindGameObjectWithTag("chef").GetComponent<Renderer>(); //other 빼야 
            chefColor.material.color = new Color(1f, 0f, 0f);

            endGame.enabled = true; //game over 활성화 true            
            gameStart = false;
        }

        //////////item///////////
        /// 
        if (other.tag == "burger")
        {
            Debug.Log("hit burger");
            count = count + 50;
            SetCountText();

            //   Renderer chefColor = GameObject.FindGameObjectWithTag("chef").GetComponent<Renderer>(); //other 빼야 
            //   chefColor.material.color = new Color(0f, 0f, 0.5f);

        }

        if (other.tag == "chicken")
        {
            Debug.Log("hit chicken");
            count = count + 60;
            SetCountText();
            //   Renderer chefColor = GameObject.FindGameObjectWithTag("chef").GetComponent<Renderer>(); //other 빼야 
            //   chefColor.material.color = new Color(0f, 0f, 0.3f);


        }
        if (other.tag == "hotdog")
        {
            Debug.Log("hit hotdog");
            count = count + 40;
            SetCountText();
            //  Renderer chefColor = GameObject.FindGameObjectWithTag("chef").GetComponent<Renderer>(); //other 빼야 
            //  chefColor.material.color = new Color(0f, 0f, 0.1f);

        }
        if (other.tag == "pizza")
        {
            Debug.Log("hit pizza");
            count = count + 30;
            SetCountText();
            //   Renderer chefColor = GameObject.FindGameObjectWithTag("chef").GetComponent<Renderer>(); //other 빼야 
            //   chefColor.material.color = new Color(0f, 0f, 0.2f);

        }

     
    }
        
    void SetCountText()
    {
        countText.text = "SCORE : " + count.ToString();
        if (count >= 1000)
        {
            winText.text = "You Win!";
            winGame.enabled = true;

         //   endGame.enabled = false;
        }
    }

      

    /*
    public void Restart() {//gameover되고 다시 시작 //만들어서쓰면돼    
        
        transform.position = new Vector3(1f, 0f, 0f); //공을 처음 좌표로 다시 위치시키   

        Renderer boxColor = GameObject.FindGameObjectWithTag("Box").GetComponent<Renderer>();  

        boxColor.material.color = new Color(1f, 1f, 1f); //Color.white;로해도 상관없어              
        endGame.enabled = false; //endgame을 비활성화 한다        //박스 초기화       
        gameStart = true;   
    }
    */

    public void Restart()
    {//gameover되고 다시 시작 //만들어서쓰면돼  

        countText.text = "SCORE : 0";
        count = 0;

    //    time minute2 = GameObject.Find("minutes").GetComponent<time>();
    //    time second2 = GameObject.Find("seconds").GetComponent<time>();
    //      time millisecond2 = GameObject.Find("milliseconds").GetComponent<time>();


     //   time timer = GameObject.Find("timerText").GetComponent<time>();
     //   timer.timerText.text = ("00" + ":" + "00" + ":" + "00");

        transform.position = new Vector3(-0.2f, -3.22f, 0.03f); //공을 처음 좌표로 다시 위치시키

    //    texture = (Texture2D)Resources.Load("chr_chef_texture0");
    //    GameObject cheF = GameObject.FindGameObjectWithTag("chef");
    //    cheF.GetComponent<Renderer>().material.mainTexture = texture; //Color.white;로해도 상관없어

        Renderer chefColor = GameObject.FindGameObjectWithTag("chef").GetComponent<Renderer>();
        chefColor.material.color = new Color(1f, 1f, 1f); //Color.white;로해도 상관없어 


        winGame.enabled = false;
        endGame.enabled = false; //endgame을 비활성화 한다        //박스 초기화  
        gameStart = true;

    }



    /*
    if(Input.GetMouseButton(0)){
        pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z));
    }
     */

}
