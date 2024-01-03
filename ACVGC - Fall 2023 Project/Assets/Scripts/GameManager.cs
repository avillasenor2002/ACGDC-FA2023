using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float ingedient1;
    public float ingedient2;
    public float ingedient3;
    public SpriteRenderer Ing1;
    public SpriteRenderer Ing2;
    public SpriteRenderer Ing3;

    public Sprite Tomato;
    public Sprite Meat;
    public Sprite Lettice;
    public Sprite Bread;
    public Sprite FailImg;

    public float TimeLeft;
    public float TimeLoss;
    public bool TimerOn = false;
    public Image LifeUI;

    public bool isIng1;
    public bool isIng2;
    public bool isIng3;
    public float maxlife;
    public GameObject GameOver;
    public float playerObjID;
    public float score;
    public float complete;
    public bool taskcomplete;
    public bool taskcompleteB;

    public PlayerControllerNew PlayerA;
    public PlayerControllerNew PlayerB;

    public enum ObjectState
    {
        Idle,
        ObjCheck,
        restart
    }
    public ObjectState currentState;

    void Start()
    {
        TimerOn = true;
        ingedient1 = Random.RandomRange(3, 6);
        ingedient2 = Random.RandomRange(3, 6);
        ingedient3 = Random.RandomRange(3, 6);
        if (ingedient1 == 3)
        {
            Ing1.sprite = Lettice;
        }
        else if (ingedient1 == 4)
        {
            Ing1.sprite = Bread;
        }
        else if (ingedient1 == 5)
        {
            Ing1.sprite = Tomato;
        }
        else if (ingedient1 == 6)
        {
            Ing1.sprite = Meat;
        }

        if (ingedient2 == 3)
        {
            Ing2.sprite = Lettice;
        }
        else if (ingedient2 == 4)
        {
            Ing2.sprite = Bread;
        }
        else if (ingedient2 == 5)
        {
            Ing2.sprite = Tomato;
        }
        else if (ingedient2 == 6)
        {
            Ing2.sprite = Meat;
        }

        if (ingedient3 == 3)
        {
            Ing3.sprite = Lettice;
        }
        else if (ingedient3 == 4)
        {
            Ing3.sprite = Bread;
        }
        else if (ingedient3 == 5)
        {
            Ing3.sprite = Tomato;
        }
        else if (ingedient3 == 6)
        {
            Ing3.sprite = Meat;
        }

        taskcomplete= false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case ObjectState.Idle:
                UpdateIdle();
                break;

            case ObjectState.ObjCheck:
                UpdateObjCheck();
                break;

            case ObjectState.restart:
                UpdateRestart();
                break;
        }

        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer();
            }
            else
            {
                Debug.Log("TimeLeft is Up!");
                TimeLeft = 0;
                TimerOn = false;
            }
        }

        if (score <= 1)
        {
            GameOver.SetActive(true);
        }
    }

    void updateTimer()
    {
        TimeLeft = TimeLeft - TimeLoss;

        LifeUI.fillAmount = (TimeLeft / maxlife);

        if (TimeLeft < 0)
        {
            TimeLeft = 0;
        }

        //Visual Feedback as Plant Life depleats
        if (TimeLeft > 67)
        {
            LifeUI.color = new Color32(35, 255, 42, 255);
        }

        if (TimeLeft > 34 && TimeLeft < 67)
        {
            LifeUI.color = new Color32(255, 234, 35, 255);
        }

        if (TimeLeft > 0.0001 && TimeLeft < 34)
        {
            LifeUI.color = new Color32(255, 88, 35, 255);
        }

        if (TimeLeft == 0)
        {
            //Destroy(GameObject.Find("Player"));
            GameOver.SetActive(true);
        }
    }

    void UpdateIdle()
    {
        if (taskcomplete == true)
        {
            PlayerA.ishold = false;
            taskcomplete= false;
        }
        if (taskcompleteB == true)
        {
            PlayerB.ishold = false;
            taskcomplete = false;
        }
    }

    void UpdateObjCheck()
    {
        if (isIng1 == false)
        {
            if (playerObjID >= ingedient1 - 0.5f && playerObjID <= ingedient1 + 0.5f)
            {
                Ing1.color = new Color32(255, 255, 255, 255);
                isIng1 = true;
                currentState = ObjectState.Idle;
            }
            else
            {
                Ing1.color = new Color32(255, 255, 255, 255);
                Ing1.sprite = FailImg;
                isIng1 = true;
                score -= 1;
                currentState = ObjectState.Idle;
            }
        }
        else if (isIng1 == true && isIng2 == false)
        {
            if (playerObjID == ingedient2)
            {
                Ing2.color = new Color32(255, 255, 255, 255);
                isIng2 = true;
                currentState = ObjectState.Idle;
            }
            else
            {
                Ing2.color = new Color32(255, 255, 255, 255);
                Ing2.sprite = FailImg;
                isIng2 = true;
                score -= 1;
                currentState = ObjectState.Idle;
            }
        }
        else if (isIng1 == true && isIng2 == true && isIng3 == false)
        {
            if (playerObjID == ingedient3)
            {
                Ing3.color = new Color32(255, 255, 255, 255);
                isIng3 = true;
                currentState = ObjectState.restart;
            }
            else
            {
                Ing3.color = new Color32(255, 255, 255, 255);
                Ing3.sprite = FailImg;
                isIng3 = true;
                score -= 1;
                currentState = ObjectState.restart;
            }
        }
    }

    void UpdateRestart()
    {
        complete += 1;
        if (complete <= 5)
        {
            maxlife = 150;
            TimeLeft = 150;
        }
        else if (complete > 5 && complete <= 12)
        {
            maxlife = 100;
            TimeLeft = 100;
        }
        else if (complete > 12 && complete <= 24)
        {
            maxlife = 90;
            TimeLeft = 90;
        }
        else if (complete > 24 && complete <= 36)
        {
            maxlife = 75;
            TimeLeft = 75;
        }
        else if (complete > 36 && complete <= 50)
        {
            maxlife = 50;
            TimeLeft = 50;
        }

        ingedient1 = Random.RandomRange(3, 6);
        ingedient2 = Random.RandomRange(3, 6);
        ingedient3 = Random.RandomRange(3, 6);
        isIng1 = false;
        isIng2 = false;
        isIng3 = false;
        Ing1.color = new Color32(0, 0, 0, 170);
        Ing2.color = new Color32(0, 0, 0, 170);
        Ing3.color = new Color32(0, 0, 0, 170);
        
        if(ingedient1 == 3)
        {
            Ing1.sprite = Lettice;
        }
        else if (ingedient1 == 4)
        {
            Ing1.sprite = Bread;
        }
        else if (ingedient1 == 5)
        {
            Ing1.sprite = Tomato;
        }
        else if (ingedient1 == 6)
        {
            Ing1.sprite = Meat;
        }

        if (ingedient2 == 3)
        {
            Ing2.sprite = Lettice;
        }
        else if (ingedient2 == 4)
        {
            Ing2.sprite = Bread;
        }
        else if (ingedient2 == 5)
        {
            Ing2.sprite = Tomato;
        }
        else if (ingedient2 == 6)
        {
            Ing2.sprite = Meat;
        }

        if (ingedient3 == 3)
        {
            Ing3.sprite = Lettice;
        }
        else if (ingedient3 == 4)
        {
            Ing3.sprite = Bread;
        }
        else if (ingedient3 == 5)
        {
            Ing3.sprite = Tomato;
        }
        else if (ingedient3 == 6)
        {
            Ing3.sprite = Meat;
        }
        currentState = ObjectState.Idle;
    }
}
