using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public int Quest1Stage;
    private bool St2;
    private DialogController dialogController;

    void Start()
    {
        dialogController = FindObjectOfType<DialogController>();
    }

    public void StartQuest(int quest)
    {
        if (quest == 1 && Quest1Stage != 2)
        {
            Quest1Stage = 1;
            Debug.Log(Quest1Stage);
            if (St2)
            {
                Quest1Stage = 2;
                Debug.Log(Quest1Stage);
                //UpdateDialog();
            }
        }
    }

    public void UpdateStage(int stage)
    {
        if (Quest1Stage == 1 && stage == 1)
        {
            Quest1Stage = 2;
            Debug.Log(Quest1Stage);
            //UpdateDialog();
        }
        if (Quest1Stage == 0 && stage == 1)
        {
            St2 = true;
        }
    }

    private void UpdateDialog()
    {
        dialogController.ActivateDialog(14);
    }
}
