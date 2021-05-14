using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	public Text txtHighscore;
	public Text txtCoins;

	void Start () {
		int highscore = 0;
		int coins = 0;

		if (PlayerPrefs.HasKey("highscore"))
        {
			highscore = PlayerPrefs.GetInt("highscore");
		}
		txtHighscore.text = "HIGHSCORE " + highscore;

		if (PlayerPrefs.HasKey("coins"))
        {
			coins = PlayerPrefs.GetInt("coins");
        }
		txtCoins.text = "COINS " + coins;
	}

	public void PlayButton()
    {
		UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
