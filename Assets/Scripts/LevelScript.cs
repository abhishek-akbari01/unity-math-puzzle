using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    public GameObject homeObj, levelObj, puzzleObj;
    int levelNo = 0;
    public Button[] allLevels;
    public Sprite newImage;
    public Sprite nullImg;
    //allTxt[i].GetComponentInParent<Button>().interactable = false;

    private void OnEnable()
    {
        levelNo = PlayerPrefs.GetInt("maxLevel", 1);
        print("=====levelNo" + levelNo);

        if (levelNo > 1)
        {
            for (int i = 0; i < levelNo-1; i++)
            {
                //print("====skip" + i + );
                if (!PlayerPrefs.HasKey("skip_" + (i + 1)))
                {
                    allLevels[i].image.sprite = newImage;
                }
                else
                {
                    allLevels[i].image.sprite = nullImg;
                }
                
                allLevels[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
                allLevels[i].GetComponent<Button>().interactable = true;
                //if(PlayerPrefs.HasKey("skip_" + i))
                //{

                //}
                //PlayerPrefs.DeleteKey("skip_"+i)
            }

            for(int i=levelNo; i<allLevels.Length;i++)
            {
                
                allLevels[i].GetComponent<Button>().interactable = false;
            }
            
            //allLevels[levelNo].GetComponentInChildren<Text>().text = (levelNo+1).ToString();
            //allLevels[levelNo].image.sprite = nullImg;
        }


            allLevels[levelNo - 1].GetComponent<Button>().interactable = true;
            allLevels[levelNo - 1].GetComponentInChildren<Text>().text = (levelNo).ToString();
            allLevels[levelNo - 1].image.sprite = nullImg;
        



    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void levelClick(int n)
    {
        PlayerPrefs.SetInt("levelNo", n);
        levelObj.SetActive(false);
        puzzleObj.SetActive(true);
    }
}
