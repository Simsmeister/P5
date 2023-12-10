using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleUI()
    {
        IntervalPlayer intervalPlayer = this.gameObject.GetComponent<IntervalPlayer>();
        if (intervalPlayer.intervals[intervalPlayer.intervalCounter-1].uIToToggle.activeSelf == true)
        {
            intervalPlayer.intervals[intervalPlayer.intervalCounter-1].uIToToggle.SetActive(false);
            intervalPlayer.waitForInteraction = false;
        }
    }
}
