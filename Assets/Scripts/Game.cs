using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Game : MonoBehaviour
{

    public Text scoreText;
	public int offset;
	public int[] up_count = new int[5];

    void Start()
    {
        //Need to link scoretext to this here
        scoreText = GetComponentInChildren<Text>();
		offset = 1;
    }




    //When the Clicker is clicked add to the currency 
    public void Increment()
    {
        GameManager.score += GameManager.multiplier * offset;
    }


    private void Update()
    {
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
}
