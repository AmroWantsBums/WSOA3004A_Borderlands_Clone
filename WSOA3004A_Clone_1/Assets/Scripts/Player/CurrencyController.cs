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
    private int CurrentMoney = 0, CurrentEridium = 0;



    // Start is called before the first frame update
    void Start()
    {
        GainCurrency(0);
        GainedEridium(0);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
