using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private bool isOnGround;
	private bool jumped;
	private bool doubleJumped;
	private float startingY;
	private Rigidbody2D rb2d;

	public float jumpForce;

	//coins
	private bool canJump;
	private bool isImmortal;
	private bool extraFuel;
	public float coinTime;

	void Start () {
		isOnGround = true;
		startingY = transform.position.y;
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.InGame == false)
		{
			return;
		}

		isOnGround = transform.position.y <= startingY;
		if (isOnGround)
        {
			jumped = false;
			doubleJumped = false;
        }

		//Input.GetKeyDown(KeyCode.Space) - spacja
		//Input.GetKeyDown(KeyCode.W) - w
		//Input.GetKeyDown(KeyCode.UpArrow) - w górę
		//Input.GetMouseButtonDown(0) - przycisk myszy
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
			if (!jumped) //!jumped to samo jumped == false
            {
				rb2d.velocity = new Vector2(0, jumpForce);
				jumped = true;
            }
			else if (!doubleJumped || canJump == true)
			{
				rb2d.velocity = new Vector2(0, jumpForce);
				doubleJumped = true;
			}
        }
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag("Obstacle") && isImmortal == false)
        {
			GameManager.instance.GameOver();
			rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
		
		if (other.CompareTag("JumpCoin"))
        {
			canJump = true;
			Invoke("ResetCoins", coinTime);
			Destroy(other.gameObject);
        }
		
		if (other.CompareTag("ImmortalCoin"))
        {
			isImmortal = true;
			Invoke("ResetCoins", coinTime);
			Destroy(other.gameObject);
			// Można przerobić na miganie za pomocą InvokeRepeating i CancelRepeating
			gameObject.GetComponent<SpriteRenderer>().color = Color.green;
		}

		if (other.CompareTag("FuelCoin"))
        {
			Destroy(other.gameObject);
			GameManager.instance.ExtraFuel();
		}
    }

	void ResetCoins()
    {
		canJump = false;
		isImmortal = false;
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
	}
}
