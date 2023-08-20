using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzleScrpt : MonoBehaviour
{
    public GameObject puzzleObj, winObj, homeObj, lossObj;

    public InputField input;
    int levelNo = 0;
    public Text headingText;
    public Text headingWinText;
    public Sprite[] allPuzzles;
    public Image puzzleImage;
    public Text scoreTxt;
    string score;
    int maxLevel = 0;

    public Image hintImg;
    public Text hintTxt;
    Image hideImg;

    string[] trueAns = { "10", "25", "6", "14", "128", "7", "50", "1025", "100", "3" };

    private void OnEnable()
    {

        levelNo = PlayerPrefs.GetInt("levelNo", 1);
        headingText.text = "PUZZLE" + levelNo;
        headingWinText.text = "PUZZLE " + levelNo + " COMPLETED";
        puzzleImage.sprite = allPuzzles[levelNo - 1];
        scoreTxt.text = "Score: " + PlayerPrefs.GetString("score", "0");

    }

    // Start is called before the first frame update
    void Start()
    {
        hintImg.gameObject.SetActive(false);
        //hideImg =  hintImg.GetComponentInParent<Image>();
        //hideImg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onNumClick(int n)
    {
        input.text = input.text + n;
    }

    public void cancelBtn()
    {

        if (input.text.Length > 0)
        {

            input.text = input.text.Remove(input.text.Length - 1);
        }
        else
        {
            input.text = "";
        }
    }

    public void submitClick()
    {
        score = PlayerPrefs.GetString("score", "0");
        if (input.text == trueAns[levelNo - 1])
        {
            print("correct");
            //headingWinText.text = "PUZZLE" + levelNo + "COMPLETED";
            puzzleObj.SetActive(false);
            winObj.SetActive(true);
            input.text = "";
            maxLevel = PlayerPrefs.GetInt("maxLevel", 1);

            if((levelNo+1) > maxLevel)
            {
                PlayerPrefs.SetInt("maxLevel", levelNo + 1);
            }



            if(levelNo == maxLevel)
            {
                score = (int.Parse(score) + 10).ToString();
                PlayerPrefs.SetString("score", score);
            }

            if (PlayerPrefs.HasKey("skip_" + levelNo))
            {
                score = (int.Parse(score) + 10).ToString();
                PlayerPrefs.SetString("score", score);

                PlayerPrefs.DeleteKey("skip_" + levelNo);
            }


            PlayerPrefs.SetInt("levelNo", levelNo + 1);
            
        }
        else
        {
            print("Opps wrong!");
            puzzleObj.SetActive(false);
            lossObj.SetActive(true);
            input.text = "";

        }

    }


    public void onContinue()
    {

        winObj.SetActive(false);
        puzzleObj.SetActive(true);

    }

    public void onMainMenu()
    {
        winObj.SetActive(false);
        homeObj.SetActive(true);
    }


    public void onHintClick()
    {
        hintImg.gameObject.SetActive(true);
        hintTxt.text = "Your Ans: " + trueAns[levelNo - 1];
     
        score = PlayerPrefs.GetString("score", "0");
        score = (int.Parse(score) - 10).ToString();

        PlayerPrefs.SetString("score", score);
        scoreTxt.text = "Score: " + PlayerPrefs.GetString("score", "0");
    }

    public void onHintClose()
    {
        hintImg.gameObject.SetActive(false);

    }

    public void skipLevel()
    {
        string key = "skip_" + levelNo;
        PlayerPrefs.SetInt(key, levelNo);

        input.text = "";
        maxLevel = PlayerPrefs.GetInt("maxLevel", 1);

        if ((levelNo + 1) > maxLevel)
        {
            PlayerPrefs.SetInt("maxLevel", levelNo + 1);
        }

        PlayerPrefs.SetInt("levelNo", levelNo + 1);

        OnEnable();
    }
}
