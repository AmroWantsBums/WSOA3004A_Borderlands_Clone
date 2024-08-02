using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI MoneyText;
    [SerializeField]
    private TextMeshProUGUI EridiumText;
    [SerializeField]
    private TextMeshProUGUI Description;

    [SerializeField]
    private GameObject FancyCanvas;

    public int CurrentMoney = 0, CurrentEridium = 0;

    [SerializeField]
    private float SetTimer = 2, CdTimer;
    [SerializeField]
    private bool Countdown = false;

    // Start is called before the first frame update
    void Start()
    {
        GainCurrency(0);
        GainedEridium(0);
        FancyCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CdTimer >= 0 &&
            Countdown == true)
        {
            CdTimer -= Time.deltaTime;

            if (CdTimer < 0)
            {
                FancyCanvas.SetActive(false);
                Countdown = false;
            }
        }
    }

    public void GainCurrency(int Gained)
    {
        CurrentMoney = CurrentMoney + Gained;

        MoneyText.text ="Money: " + $"{CurrentMoney}";
    }

    public void GainedEridium(int Gained)
    {
        CurrentEridium = CurrentEridium + Gained;

        EridiumText.text ="Eridium: " + $"{CurrentEridium}";
    }


    public void DisplayCollectableInfo(string Message)
    {
        FancyCanvas.SetActive(true);
        Description.text = Message;
        Countdown = true;
        CdTimer = SetTimer;
    }

    
}
