using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject boss01;
    public GameObject player;
    //public GameObject canvaslose;
    public bool lose = false;
    

    enum GameState {
        WALKING,
        CHOOSE,
        FIGTH
    }

    GameState state;

    // Start is called before the first frame update
    void Start()
    {
       canvas.SetActive(false);
       state = GameState.WALKING;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) {
            case GameState.WALKING :
                 FairyMovement.StartMovement();   
                 Boss01();
                 break;
            case GameState.CHOOSE :
                 Choose();
                 break;
            case GameState.FIGTH :
                Fight();
                break;               
    }
        }

    void Fight() {
        
        Debug.Log("Yo won: " + lose.ToString());
        boss01.SetActive(!lose);
        state = lose ? GameState.WALKING : GameState.CHOOSE; 
    }   

    public void Choose()
    {   
        canvas.SetActive(true);
    }

    public void Boss01()
    {
        var posPlayer = player.transform.position;
        var posBoss = boss01.transform.position;
        
        if(!lose && Vector3.Distance(posPlayer,posBoss) < 9)
        {
            
            FairyMovement.StopMovement();
            state = GameState.CHOOSE;
        }
    }
    // public void Boss02()
    // {
        
    // }
    // public void Boss03()
    // {
        
    // }
    public void Tails1()
    {
       var rand = Random.Range(0,1);

        if (rand <= 0.50) {
            lose = true;
        } else {
            lose = false;
        }
        state = GameState.FIGTH;
        canvas.SetActive(false);

        
    }
    public void Head1()
    {
         var rand = Random.Range(0,1);

        if (rand <= 0.50) {
            lose = false;
        } else {
            lose = true;
        }
        state = GameState.FIGTH;
        canvas.SetActive(false);
    }
}
