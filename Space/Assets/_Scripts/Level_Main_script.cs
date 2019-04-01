using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Контроль уровней
[System.Serializable]
public class Level_Main_script : MonoBehaviour
{
    public static int countUnlockedLevel = 1;

    public void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.name = (i + 1).ToString();
            transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = ("Level " + (i + 1)).ToString();

            if (i < countUnlockedLevel)
                transform.GetChild(i).GetComponent<Button>().interactable = true;
            else
                transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
    }
    
}
