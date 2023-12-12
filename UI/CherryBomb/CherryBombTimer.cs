using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CherryBombTimer : MonoBehaviour
{
    public int countDownInt = 10;
    public bool explosion;
    public TextMeshProUGUI countdownText;

    void Start()
    {
        countdownText = GetComponent<TextMeshProUGUI>();
        UpdateCountdownText();
        InvokeRepeating("DecreaseCountdown", 1f, 1f);
    }

    void DecreaseCountdown()
    {
        if (GameObject.Find("CherryBomb").transform.parent != null)
        {
            countDownInt = Mathf.Max(0, countDownInt - 1);
            UpdateCountdownText();
        }

    }

    void UpdateCountdownText()
    {
        countdownText.text = "Countdown: " + countDownInt.ToString();
    }
}
