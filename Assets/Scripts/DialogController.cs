using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public GameObject[] pages;
    public GameObject[] B1;
    public GameObject[] B2;

    void Start()
    {
        ActivateDialog(0);
    }

    public void ActivateDialog(int dialogNo)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        for (int i = 0; i < B1.Length; i++)
        {
            B1[i].SetActive(false);
            B2[i].SetActive(false);
        }
        pages[dialogNo].SetActive(true);

        if(dialogNo == 0)
        {
            B1[0].SetActive(true);
            B2[0].SetActive(true);
        }
        if (dialogNo == 1)
        {
            B1[1].SetActive(true);
            B2[1].SetActive(true);
        }
        if (dialogNo == 2)
        {
            B1[2].SetActive(true);
            B2[2].SetActive(true);
        }
        if (dialogNo == 3)
        {
            B1[3].SetActive(true);
            B2[3].SetActive(true);
        }
        if (dialogNo == 4)
        {
            B1[3].SetActive(true);
            B2[3].SetActive(true);
        }
        if (dialogNo == 5)
        {
            B1[4].SetActive(true);
            B2[4].SetActive(true);
        }
        if (dialogNo == 6)
        {
            B1[4].SetActive(true);
            B2[4].SetActive(true);
        }
    }
}
