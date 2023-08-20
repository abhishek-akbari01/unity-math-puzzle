using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lossScript : MonoBehaviour
{
    public GameObject lossObj,puzzleObj, homeObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onRetry()
    {

        lossObj.SetActive(false);
        puzzleObj.SetActive(true);

    }

    public void onMainMenu()
    {
        lossObj.SetActive(false);
        homeObj.SetActive(true);
    }
}
