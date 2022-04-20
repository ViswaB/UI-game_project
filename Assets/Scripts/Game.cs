using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;


public class Game : MonoBehaviour
{
	public GameObject HelpBut;
	public GameObject QuitBut;
	public GameObject startRoundBut;
	public GameObject returnMainBut;
	public GameObject upgradeBut;
	public CanvasManager canvasManager;

	public Text scoreText;
	public Text multText;
	public float timer;
	public double offset;
	public int[] up_count = new int[5];

	public UpgradeBarScript upgradeBar1;
	public UpgradeBarScript upgradeBar2;
	public UpgradeBarScript upgradeBar3;
	public UpgradeBarScript upgradeBar4;
	public UpgradeBarScript upgradeBar5;

	public AudioSource clickerSound;
	public AudioSource victoryFanfare;

	public int victoryScore;
	private int victoryPointsRemaining;
	public bool victoryFlag = false;

	//Study Variables
	//Get Total number of clicks from when the player to complete the game
	int totalClicks;
	//Get the time it takes until the victory screen appears
	string endTime;
	string startTime;

	//Ouput to .txt file

    void Start()
    {
        //Need to link scoretext to this here
        scoreText = GetComponentInChildren<Text>();
		multText = GameObject.FindWithTag("mult").GetComponent<Text>();
		offset = 1;
		timer = 0;
		victoryScore = 10000;  //victoryScore = 10000;

		upgradeBar1.setSlider(0);
		upgradeBar2.setSlider(0);
		upgradeBar3.setSlider(0);
		upgradeBar4.setSlider(0);
		upgradeBar5.setSlider(0);


		totalClicks = 0;
		startTime = "Start: " + System.DateTime.Now + "\n";

	}




	//When the Clicker is clicked add to the Score
	public void Increment()
    {
		if(timer > 0)
		{
			GameManager.score += GameManager.multiplier * (int)offset;
			victoryPointsRemaining -= GameManager.multiplier * (int)offset;


			clickerSound.Play();
			totalClicks++;

			//This statement gets triggered only once after the player gets enough score in a round
			if(victoryPointsRemaining <= 0 && victoryFlag == false)
			{
				Text countdown = GameObject.FindWithTag("countdown").GetComponent<Text>();
				timer = 0;
				countdown.text = "TIME: 0";
				victoryFlag = true;
				victoryFanfare.Play();
				Debug.Log("Victory");
				canvasManager.SwitchCanvas(CanvasType.Victory);
				CreateText(totalClicks);
			}
			
		}

		

	}

	
    private void Update()
    {

		
		if(timer > 0)
		{	
			startRoundBut.SetActive(false);
			returnMainBut.SetActive(false);
			upgradeBut.SetActive(false);
			HelpBut.SetActive(false);
			QuitBut.SetActive(false);
		}
		else
		{
			startRoundBut.SetActive(true);
			returnMainBut.SetActive(true);
			upgradeBut.SetActive(true);
			HelpBut.SetActive(true);
			QuitBut.SetActive(true);
		}
		
        scoreText.text = "SCORE: " + GameManager.score;
		multText.text = "MULTIPLIER: " + offset;
    }
	
	public void increaseMult()
	{
		//upgrade 1 - +1
		if(EventSystem.current.currentSelectedGameObject.tag == "up1")
		{
			if(GameManager.score >= 100 && up_count[0] < 5)
			{
				offset = offset + 1;
				GameManager.score = GameManager.score - 100;
				up_count[0] += 1;
				Text count = GameObject.FindWithTag("upCount1").GetComponent<Text>();
				count.text = up_count[0] + "/5";
				Text pc = GameObject.FindWithTag("pc").GetComponent<Text>();
				pc.text = "Successfully purchased upgrade 1!";
				upgradeBar1.setSlider(up_count[0]);
			}
			else
			{
				Text pc = GameObject.FindWithTag("pc").GetComponent<Text>();
				pc.text = "Unable to purchase upgrade 1.";
			}
		}
		
		//upgrade 2 - +2
		if(EventSystem.current.currentSelectedGameObject.tag == "up2")
		{
			if(GameManager.score >= 300 && up_count[1] < 5)
			{
				offset = offset + 2;
				GameManager.score = GameManager.score - 200;
				up_count[1] += 1;
				Text count = GameObject.FindWithTag("upCount2").GetComponent<Text>();
				count.text = up_count[1] + "/5";
				Text pc = GameObject.FindWithTag("pc").GetComponent<Text>();
				pc.text = "Successfully purchased upgrade 2!";
				upgradeBar2.setSlider(up_count[1]);
			}
			else
			{
				Text pc = GameObject.FindWithTag("pc").GetComponent<Text>();
				pc.text = "Unable to purchase upgrade 2.";
			}
		}
		
		//upgrade 3 - +3
		if(EventSystem.current.currentSelectedGameObject.tag == "up3")
		{
			if(GameManager.score >= 500 && up_count[2] < 5)
			{
				offset = offset + 3;
				GameManager.score = GameManager.score - 300;
				up_count[2] += 1;
				Text count = GameObject.FindWithTag("upCount3").GetComponent<Text>();
				count.text = up_count[2] + "/5";
				Text pc = GameObject.FindWithTag("pc").GetComponent<Text>();
				pc.text = "Successfully purchased upgrade 3!";
				upgradeBar3.setSlider(up_count[2]);
			}
			else
			{
				Text pc = GameObject.FindWithTag("pc").GetComponent<Text>();
				pc.text = "Unable to purchase upgrade 3.";
			}
		}
		
		//upgrade 4 - *1.5
		if(EventSystem.current.currentSelectedGameObject.tag == "up4")
		{
			if(GameManager.score >= 1000 && up_count[3] < 5)
			{
				offset = offset * 1.5;
				GameManager.score = GameManager.score - 400;
				up_count[3] += 1;
				Text count = GameObject.FindWithTag("upCount4").GetComponent<Text>();
				count.text = up_count[3] + "/5";
				Text pc = GameObject.FindWithTag("pc").GetComponent<Text>();
				pc.text = "Successfully purchased upgrade 4!";
				upgradeBar4.setSlider(up_count[3]);
			}
			else
			{
				Text pc = GameObject.FindWithTag("pc").GetComponent<Text>();
				pc.text = "Unable to purchase upgrade 4.";
			}
		}
		
		//upgrade 5 - *2
		if(EventSystem.current.currentSelectedGameObject.tag == "up5")
		{
			if(GameManager.score >= 2000 && up_count[4] < 5)
			{
				offset = offset * 2;
				GameManager.score = GameManager.score - 500;
				up_count[4] += 1;
				Text count = GameObject.FindWithTag("upCount5").GetComponent<Text>();
				count.text = up_count[4] + "/5";
				Text pc = GameObject.FindWithTag("pc").GetComponent<Text>();
				pc.text = "Successfully purchased upgrade 5!";
				upgradeBar5.setSlider(up_count[4]);
			}
			else
			{
				Text pc = GameObject.FindWithTag("pc").GetComponent<Text>();
				pc.text = "Unable to purchase upgrade 5.";
			}
		}
		Debug.Log(offset);
	}
	
	public void startRound()
	{
		timer = 10;
		victoryPointsRemaining = victoryScore;              //When each round is started set the victoryPointsRemaining to the victoryScore needed
		Debug.Log("Score to win is: " + victoryPointsRemaining);

		Text countdown = GameObject.FindWithTag("countdown").GetComponent<Text>();
		countdown.text = "TIME: 10";
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


	void CreateText(int c)
    {
		//File Path
		string path = Application.dataPath + "/Study.txt";


		//Create new file if it doesn't exist
        if (!File.Exists(path))
        {
			File.WriteAllText(path, "Study Measurements \n \n");
        }

		//Create string Content

		endTime = "End: " + System.DateTime.Now + "\n";
		string totalClickString = "It took the player " + c + " clicks to complete the game \n";
        

		//Add some text to it

		File.AppendAllText(path, startTime + "\n");
		File.AppendAllText(path, endTime + "\n");

		File.AppendAllText(path, totalClickString);
		


    }

}
