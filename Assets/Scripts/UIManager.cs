using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    public float DayTimer;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI count;
    public TextMeshProUGUI govText;

    public TextMeshProUGUI quotaTest;

    public CanvasGroup timerParent;
    public CanvasGroup GovernmentParent;

    [HideInInspector]
    public int dayCount = 7;

    private bool nextText = false;

    private bool secondChance = true, gameOver = false;
    private int govFood;

    public int govQuota;

    // Start is called before the first frame update
    void Start()
    {
        //gov = GetComponent<Government>();
        timer.text = ((int)DayTimer).ToString();
        GovernmentParent.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && FarmManager._instance.GetCrops() > 0)
        {
            FarmManager._instance.TakeCrops();
            govFood++;
        }
        quotaTest.text = (govFood).ToString();

        if(!nextText)
        {
            if (DayTimer >= 0f)
            {
                DayTimer -= Time.deltaTime;
                timer.text = ((int)DayTimer).ToString();
            }
            else
            {
                if (dayCount != 0)
                {
                    DayTimer = 24f;
                    timer.text = ((int)DayTimer).ToString();
                    dayCount--;
                    count.text = dayCount.ToString();
                }
                else if (dayCount == 0)
                {
                    if (govFood >= govQuota)
                    {
                        nextText = true;
                        timerParent.alpha = 0f;
                        GovernmentParent.alpha = 1f;
                        govText.text = "Great job comrade!\n\nYour harvest will serve the union well!";

                        DayTimer = 24f;
                        timer.text = ((int)DayTimer).ToString();
                        dayCount = 7;
                        count.text = dayCount.ToString();
                    }
                    else if (!secondChance)
                    {
                        nextText = true;
                        timerParent.alpha = 0f;
                        GovernmentParent.alpha = 1f;
                        govText.text = "comrade?\n\nDo you hate the motherland?\nYou must as you didn't do your part to sustain her! Soldiers arrest this traitor!";
                        gameOver = true;
                    }
                    else if (govFood < govQuota)
                    {
                        nextText = true;
                        timerParent.alpha = 0f;
                        GovernmentParent.alpha = 1f;
                        govText.text = "COMRADE!\n\nYour have failed your motherland!\nFortunately for you she is forgiving.\nDO NOT FAIL HER AGAIN!";

                        DayTimer = 24f;
                        timer.text = ((int)DayTimer).ToString();
                        dayCount = 7;
                        count.text = dayCount.ToString();
                        secondChance = false;
                    }
                }            
            }
        }

        if (nextText)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (gameOver)
                {
                    Application.Quit();
                }
                else
                {
                    nextText = false;
                    timerParent.alpha = 1f;
                    GovernmentParent.alpha = 0f;
                    govFood = 0;
                }
            }
        }
    }
}
