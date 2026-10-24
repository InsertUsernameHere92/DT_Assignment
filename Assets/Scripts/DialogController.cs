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
            B1[i].SetActive(false);
            B2[i].SetActive(false);
        }
        pages[dialogNo].SetActive(true);
        B1[dialogNo].SetActive(true);
        B2[dialogNo].SetActive(true);
    }
}
