using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Game : MonoBehaviour
{
	
	public GameObject startRoundBut;
	public GameObject returnMainBut;
	public GameObject upgradeBut;
	public CanvasManager canvasManager;

	public Text scoreText;
	public float timer;
	public int offset;
	public int[] up_count = new int[5];

	public int victoryScore = 100;
	private int victoryPointsRemaining;
	public bool victoryFlag = false;


    void Start()
    {
        //Need to link scoretext to this here
        scoreText = GetComponentInChildren<Text>();
		offset = 1;
		timer = 0;
    }




    //When the Clicker is clicked add to the Score
    public void Increment()
    {
		if(timer > 0)
		{
			GameManager.score += GameManager.multiplier * offset;
			victoryPointsRemaining--;
			
		}

		//This statement gets triggered only once after the player gets enough score in a round
		if(victoryPointsRemaining <= 0 && victoryFlag == false)
        {
			timer = 0;
			victoryFlag = true;
			Debug.Log("Victory");
			canvasManager.SwitchCanvas(CanvasType.Victory);
		}

	}

	
    private void Update()
    {

		
		if(timer > 0)
		{	
			startRoundBut.SetActive(false);
			returnMainBut.SetActive(false);
			upgradeBut.SetActive(false);
		}
		else
		{
			startRoundBut.SetActive(true);
			returnMainBut.SetActive(true);
			upgradeBut.SetActive(true);
		}
		
        scoreText.text = "Score: " + GameManager.score;
    }
	
	public void increaseMult()
	{
		if(EventSystem.current.currentSelectedGameObject.tag == "up1")
		{
			if(GameManager.score >= 100 && up_count[0] < 10)
			{
				offset = offset * 2;
				GameManager.score = GameManager.score - 100;
				up_count[0] += 1;
				Text count = GameObject.FindWithTag("upCount1").GetComponent<Text>();
				count.text = up_count[0] + "/10";
			}
		}
		if(EventSystem.current.currentSelectedGameObject.tag == "up2")
		{
			if(GameManager.score >= 200 && up_count[1] < 10)
			{
				offset = offset * 3;
				GameManager.score = GameManager.score - 200;
				up_count[1] += 1;
				Text count = GameObject.FindWithTag("upCount2").GetComponent<Text>();
				count.text = up_count[1] + "/10";
			}
		}
		if(EventSystem.current.currentSelectedGameObject.tag == "up3")
		{
			if(GameManager.score >= 300 && up_count[2] < 10)
			{
				offset = offset * 4;
				GameManager.score = GameManager.score - 300;
				up_count[2] += 1;
				Text count = GameObject.FindWithTag("upCount3").GetComponent<Text>();
				count.text = up_count[2] + "/10";
			}
		}
		if(EventSystem.current.currentSelectedGameObject.tag == "up4")
		{
			if(GameManager.score >= 400 && up_count[3] < 10)
			{
				offset = offset * 5;
				GameManager.score = GameManager.score - 400;
				up_count[3] += 1;
				Text count = GameObject.FindWithTag("upCount4").GetComponent<Text>();
				count.text = up_count[3] + "/10";
			}
		}
		if(EventSystem.current.currentSelectedGameObject.tag == "up5")
		{
			if(GameManager.score >= 500 && up_count[4] < 10)
			{
				offset = offset * 6;
				GameManager.score = GameManager.score - 500;
				up_count[4] += 1;
				Text count = GameObject.FindWithTag("upCount5").GetComponent<Text>();
				count.text = up_count[4] + "/10";
			}
		}
		Debug.Log(offset);
	}
	
	public void startRound()
	{
		timer = 30;
		victoryPointsRemaining = victoryScore;              //When each round is started set the victoryPointsRemaining to the victoryScore needed
		Debug.Log("Score to win is: " + victoryPointsRemaining);

		Text countdown = GameObject.FindWithTag("countdown").GetComponent<Text>();
		countdown.text = "TIME: 30";
		StartCoroutine(timeWait());
	}
	
	IEnumerator timeWait()
	{
		while(timer > 0)
		{
			yield return new WaitForSeconds(1);
			timer -= 1;
			Text countdown1 = GameObject.FindWithTag("countdown").GetComponent<Text>();
			countdown1.text = "TIME: " + timer;
		}
	}


	


}
