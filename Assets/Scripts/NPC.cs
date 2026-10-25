using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public GameObject dialogBox;

    void Start()
    {
        dialogBox.SetActive(false);
    }

    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        RunDialog();
    }

    private void RunDialog()
    {
        dialogBox.SetActive(true);
    }
}
