using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearDirector : MonoBehaviour {

    GameObject resultText;
    GameObject echoText;

    private void Start()
    {
        int scroe = PlayerPrefs.GetInt("resultScore");
        resultText = GameObject.Find("Score");
        echoText = GameObject.Find("EchoText");
        resultText.GetComponent<Text>().text = "" + scroe;

        if (PlayerPrefs.GetInt("resultScore") < PlayerPrefs.GetInt("HighScore"))
        {
            echoText.GetComponent<Text>().fontSize = 22;
            echoText.GetComponent<Text>().text = "Best: " + PlayerPrefs.GetInt("HighScore") + "\n\n" + "분발하세요";

        }
        else
        {
            resultText.GetComponent<Text>().color = Color.red;
            echoText.GetComponent<Text>().text = "최고점 갱신";
        }

    }
    // Update is called once per frame
    void Update () {
	   
	}


    public void reLode()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
