using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 5f;

    public GameObject countdownUI;
    public GameObject warningUI;

    [SerializeField] TMP_Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

  

        if (currentTime < 0)
        {
            countdownUI.SetActive(false);
            warningUI.SetActive(false);

        }
    }
}
