using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public int Quest1Stage;

    public void StartQuest(int quest)
    {
        if (quest == 1)
        {
            Quest1Stage = 1;
            Debug.Log(Quest1Stage);
        }
    }
}
