using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public Text ScoreText;
	public GameObject ResetButton;
	public Slider fuelSlider;
	
	private float score;
	public bool InGame;

	// settings
	public float worldSpeed;

	// obstacles
	public List<ObstacleObject> obstacle;
	public float obstacleSpawnRate;
	public float obstacleMinX;
	public float obstacleMaxX;
	public float obstacleY;

	//coins
	public List<GameObject> Coins;
	public float coinSpawnRate;
	public float coinMinX;
	public float coinMaxX;
	public float coinMinY;
	public float coinMaxY;

	private Image fill;

	void Start () {
		instance = this;
		score = 0;
		InGame = true;
		fuelSlider.value = 1;

		InvokeRepeating("SpawnObstacle", obstacleSpawnRate, obstacleSpawnRate);
		InvokeRepeating("SpawnCoin", coinSpawnRate, coinSpawnRate);
		ResetButton.SetActive(false);

		fill = fuelSlider
			.GetComponentsInChildren<Image>()
			.FirstOrDefault(x => x.name == "Fill");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (InGame)
		{
			UpdateScore(worldSpeed);
			fuelSlider.value -= worldSpeed / 300;
			if (fuelSlider.value <= 0)
            {
				GameOver();
            }

			if (fuelSlider.value <= 0.6)
            {
				fill.color = fuelSlider.value < 0.2 ? Color.red : Color.yellow;
            }
		}
	}

	// Dodaje liczbę do wyniku i wyświetla wynik
	void UpdateScore(float number)
    {
		score += number;
		ScoreText.text = "Wynik: " + score.ToString("0");
    }

	void SpawnObstacle()
    {
		int obstacleIndex = Random.Range(0, obstacle.Count);
		ObstacleObject obs = obstacle[obstacleIndex];
		
		float x = Random.Range(obstacleMinX, obstacleMaxX);
		float y = Random.Range(obs.MinY, obs.MaxY);
		Vector3 position = new Vector3(x, y, 0);

		Instantiate(obs.Obstacle, position, Quaternion.identity);
    }

	void SpawnCoin() // gdy 3 razy z rzędu nie pokaże się fuel, to pokaż fuel
    {
		float x = Random.Range(coinMinX, coinMaxX);
		float y = Random.Range(coinMinY, coinMaxY);
		Vector3 position = new Vector3(x, y, 0);

		int coinIndex = Random.Range(0, Coins.Count);
		GameObject coin = Coins[coinIndex];

		Instantiate(coin, position, Quaternion.identity);
    }

	public void GameOver()
    {
		InGame = false;
		CancelInvoke("SpawnObstacle");
		CancelInvoke("SpawnCoin");
		ResetButton.SetActive(true);
    }

	public void Restart()
    {
		SceneManager.LoadScene(0);
    }

	public void ExtraFuel()
    {
		fuelSlider.value = 1;
		fill.color = Color.green;
    }
}

public class ObstacleObject
{
	public GameObject Obstacle;
	public float MinY;
	public float MaxY;
}
