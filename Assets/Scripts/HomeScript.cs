using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScript : MonoBehaviour
{
    public GameObject homeObj, levelObj, puzzleObj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void continueBtn()
    {
        homeObj.SetActive(false);
        puzzleObj.SetActive(true);
    }

    public void puzzlesBtn()
    {
        homeObj.SetActive(false);
        levelObj.SetActive(true);
    }
}
