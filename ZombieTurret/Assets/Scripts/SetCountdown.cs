using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCountdown : MonoBehaviour {

    private GameManager GameManager;

    public void CountDownSet()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameManager.countdownDone = true;
        FindObjectOfType<Timer>().UnPauseAfterCountDown();

    }

    public void StartCountDown()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameManager.countdownDone = false;
        FindObjectOfType<Timer>().PauseGameAfterTimerRunOut();
    }


}
