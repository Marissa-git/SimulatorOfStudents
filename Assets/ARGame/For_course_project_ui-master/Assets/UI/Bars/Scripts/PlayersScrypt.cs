using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersScrypt : MonoBehaviour
{
    //To get tag
    public HitsOnDormitory dormTag;
    public HitsOnHSE HSETag;
    public HitsOnMall mallTag;

    /// Раздел для описания ui объектов
    public GameObject HSECanvas;
    public GameObject DormitoryCanvas;
    public GameObject MallCanvas;
    public GameObject StartCanvas;
    public bool IsStartCanvasActive; // for debug and tests
    public GameObject SessionCanvas;
    public GameObject FinalGoodCanvas;
    public GameObject FinalBadCanvas;

    ///  Объекты статуса отображающие текущее состояние
    public int maxEnergy = 100;
    //public int maxKnowledge = 100;
    //public int maxReputation = 100;
    //public int maxFortune = 10;
    public int maxMoney = 30000;

    public int currentEnergy;
    public int currentKnowledge = 0;
    public int currentReputation = 0;
    public int currentMoney;
    public int currentFortune;

    /// для обработки нажатия на конкретную модельку (отрисовка нужного canvas)
    public string touched_model;

    /// анимация user gui
    public EnergyBarScript energyBar;
    public KnowledgeRepBarScript knowledgeBar;
    public KnowledgeRepBarScript reputationBar;
    public MoneyAmountScript moneyAmountText;
    public FortuneScript fortuneBar;

    /// Длина игры и счётчик дней
    public int GameLength;
    public int dayCounter;
    private bool endfl = false;
    void Start()
    {
        currentEnergy = maxEnergy;
        currentMoney = maxMoney;
        knowledgeBar.SetRepKnow(currentKnowledge);
        reputationBar.SetRepKnow(currentReputation);
        moneyAmountText.SetMoneyAmount(currentMoney.ToString());
        fortuneBar.SetFortune(currentFortune);
        DormitoryCanvas.SetActive(false);
        HSECanvas.SetActive(false);
        MallCanvas.SetActive(false);
        SessionCanvas.SetActive(false);
        FinalGoodCanvas.SetActive(false);
        FinalBadCanvas.SetActive(false);
        StartCanvas.SetActive(IsStartCanvasActive);
        dayCounter = 0;

    }

    void Update()
    {
        if (dayCounter == GameLength && endfl == false)
        {
            endfl = true;
            SessionCanvas.SetActive(true);
            GameObject.Find("TextPassExam").GetComponent<Text>().text = "Ваши очки знаний: " + currentKnowledge + "/100. Ваши очки репутации: " + currentReputation.ToString() + "/100.";
            GameObject.Find("WriteOffText").GetComponent<Text>().text = "Ваша удача: " + currentFortune + "/10.Соответственно,это ваши шансы списать";
            if (currentKnowledge < 100 || currentReputation < 100)
            {
                Button btn = GameObject.Find("ButtonPassExam").GetComponent<Button>();
                btn.interactable = false;
            }
            DormitoryCanvas.SetActive(false);
            HSECanvas.SetActive(false);
            MallCanvas.SetActive(false);
        }
        else
        {

            if (dormTag.getTag == "Dormitory" && currentEnergy > 0 && endfl == false)
            {
                dormTag.getTag = "";
                dayCounter++;
                DormitoryCanvas.SetActive(true);
                if (currentMoney < 50)
                {
                    Button btn = GameObject.Find("d2Buttonevent3").GetComponent<Button>();
                    btn.interactable = false;
                }
                if (currentMoney < 100)
                {
                    Button btn = GameObject.Find("d2Buttonevent1").GetComponent<Button>();
                    btn.interactable = false;
                }
                if (currentMoney < 200)
                {
                    Button btn = GameObject.Find("h2Buttonevent2").GetComponent<Button>();
                    btn.interactable = false;
                }

            }
            if (HSETag.getTag == "HSE" && currentEnergy > 0 && endfl == false)
            {
                HSETag.getTag = "";
                dayCounter++;
                HSECanvas.SetActive(true);
                if (currentMoney < 120)
                {
                    Button btn = GameObject.Find("h2Buttonevent3").GetComponent<Button>();
                    btn.interactable = false;
                }
                if (currentMoney < 100)
                {
                    Button btn = GameObject.Find("h2Buttonevent1").GetComponent<Button>();
                    btn.interactable = false;
                }
                if (currentMoney < 200)
                {
                    Button btn = GameObject.Find("h2Buttonevent2").GetComponent<Button>();
                    btn.interactable = false;
                }
            }
            if (mallTag.getTag == "Mall" && currentEnergy > 0 && endfl == false)
            {
                mallTag.getTag = "";
                dayCounter++;
                MallCanvas.SetActive(true);
                if (currentMoney < 150)
                {
                    Button btn1 = GameObject.Find("mButtonevent1").GetComponent<Button>();
                    btn1.interactable = false;
                }
                if (currentMoney < 120)
                {
                    Button btn2 = GameObject.Find("mButtonevent2").GetComponent<Button>();
                    btn2.interactable = false;
                }
                if (currentMoney < 200)
                {
                    Button btn3 = GameObject.Find("mButtonevent3").GetComponent<Button>();
                    btn3.interactable = false;
                }
                if (currentMoney < 10000)
                {
                    Button btn4 = GameObject.Find("mButtonevent4").GetComponent<Button>();
                    btn4.interactable = false;
                    Button btn5 = GameObject.Find("mButtonevent5").GetComponent<Button>();
                    btn5.interactable = false;
                }

            }
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (dayCounter == GameLength && endfl == false)
                {
                    endfl = true;
                    SessionCanvas.SetActive(true);
                    GameObject.Find("TextPassExam").GetComponent<Text>().text = "Ваши очки знаний: " + currentKnowledge + "/100. Ваши очки репутации: " + currentReputation.ToString() + "/100.";
                    GameObject.Find("WriteOffText").GetComponent<Text>().text = "Ваша удача: " + currentFortune + "/10.Соответственно,это ваши шансы списать";
                    if (currentKnowledge < 100 || currentReputation < 100)
                    {
                        Button btn = GameObject.Find("ButtonPassExam").GetComponent<Button>();
                        btn.interactable = false;
                    }
                    DormitoryCanvas.SetActive(false);
                    HSECanvas.SetActive(false);
                    MallCanvas.SetActive(false);
                }
                else
                {
                    switch (touched_model)
                    {
                        case "HSE":
                            dayCounter++;
                            HSECanvas.SetActive(true);
                            if (currentMoney < 120)
                            {
                                Button btn = GameObject.Find("h2Buttonevent3").GetComponent<Button>();
                                btn.interactable = false;
                            }
                            if (currentMoney < 100)
                            {
                                Button btn = GameObject.Find("h2Buttonevent1").GetComponent<Button>();
                                btn.interactable = false;
                            }
                            if (currentMoney < 200)
                            {
                                Button btn = GameObject.Find("h2Buttonevent2").GetComponent<Button>();
                                btn.interactable = false;
                            }
                            break;
                        case "Dormitory":
                            dayCounter++;
                            DormitoryCanvas.SetActive(true);
                            if (currentMoney < 50)
                            {
                                Button btn = GameObject.Find("d2Buttonevent3").GetComponent<Button>();
                                btn.interactable = false;
                            }
                            if (currentMoney < 100)
                            {
                                Button btn = GameObject.Find("d2Buttonevent1").GetComponent<Button>();
                                btn.interactable = false;
                            }
                            if (currentMoney < 200)
                            {
                                Button btn = GameObject.Find("h2Buttonevent2").GetComponent<Button>();
                                btn.interactable = false;
                            }
                            break;
                        case "Mall":
                            dayCounter++;
                            MallCanvas.SetActive(true);
                            if (currentMoney < 150)
                            {
                                Button btn1 = GameObject.Find("mButtonevent1").GetComponent<Button>();
                                btn1.interactable = false;
                            }
                            if (currentMoney < 120)
                            {
                                Button btn2 = GameObject.Find("mButtonevent2").GetComponent<Button>();
                                btn2.interactable = false;
                            }
                            if (currentMoney < 200)
                            {
                                Button btn3 = GameObject.Find("mButtonevent3").GetComponent<Button>();
                                btn3.interactable = false;
                            }
                            if (currentMoney < 10000)
                            {
                                Button btn4 = GameObject.Find("mButtonevent4").GetComponent<Button>();
                                btn4.interactable = false;
                                Button btn5 = GameObject.Find("mButtonevent5").GetComponent<Button>();
                                btn5.interactable = false;
                            }
                            break;
                    }
                }

            }
        }
    }


    public void DoSomeAtcion(int spend=5)
    {
        if (currentEnergy >= spend)
        {
            currentEnergy -= spend;
            energyBar.SetEnergy(currentEnergy);
        }
    }
    public void GetEnergy(int increase)
    {
        if (currentEnergy + increase > maxEnergy)
        {
            currentEnergy = maxEnergy;
            energyBar.SetEnergy(currentEnergy);
        }
        else
        {
            currentEnergy += increase;
            energyBar.SetEnergy(currentEnergy);
        }
    }
    public void SpendMoney(int sum)
    {
        if (currentMoney - sum >= 0)
        {
            currentMoney -= sum;
            moneyAmountText.SetMoneyAmount(currentMoney.ToString());
        }
    }
    public void GetReputation(int increase)
    {
        if (increase > 0)
        {
            if (currentReputation + increase < 100)
            {
                currentReputation += increase;
                reputationBar.SetRepKnow(currentReputation);
            }
        }
        else if (currentReputation - increase > 0)
        {
            currentReputation += increase;
            reputationBar.SetRepKnow(currentReputation);
        }
    }
    public void GetKnowledge(int increase)
    {
        if (increase > 0)
        {
            if (currentKnowledge + increase < 100)
            {
                currentKnowledge += increase;
                knowledgeBar.SetRepKnow(currentKnowledge);
            }
        }
        else if (currentKnowledge - increase > 0)
        {
            currentKnowledge += increase;
            knowledgeBar.SetRepKnow(currentKnowledge);
        }
    }
    public void GetFortune(int increase)
    {
        if (increase > 0)
        {
            if (currentFortune + increase < 10)
            {
                currentFortune += increase;
                fortuneBar.SetFortune(currentFortune);
            }
        }
        else if (currentFortune - increase > 0)
        {
            currentFortune += increase;
            fortuneBar.SetFortune(currentFortune);
        }
    }



    /*public void CombinedCheck(int Money, int Knowledge, int Reputation = 0, int Energy = 0, int Fortune = 0)
    {
        if (SpendMoney(Money))
        {
            if (Energy != 0)
                GetEnergy(Energy);
            if (Knowledge != 0)
                GetKnowledge(Knowledge, 1);
            if (Reputation != 0)
                GetReputation(Reputation);
            if (Fortune != 0)
                GetFortune(Fortune);
        }
    }*/

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str">Money;Knowledge;Reputation;Energy;Fortune</param>
    public void CombinedCheck(string str)
    {
        string[] arr = str.Split(';');

        if (currentMoney - Convert.ToInt32(arr[0]) > 0)
        {
            if (Convert.ToInt32(arr[1]) != 0)
                GetKnowledge(Convert.ToInt32(arr[1]));
            if (Convert.ToInt32(arr[2]) != 0)
                GetReputation(Convert.ToInt32(arr[2]));
            if (Convert.ToInt32(arr[3]) != 0)
                GetEnergy(Convert.ToInt32(arr[3]));
            if (Convert.ToInt32(arr[4]) != 0)
                GetFortune(Convert.ToInt32(arr[4]));
        }
    }


}
