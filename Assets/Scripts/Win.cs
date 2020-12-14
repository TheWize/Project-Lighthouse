using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private bool canTrigger;
    public GameObject[] objectsToActivate;
    private bool mouseDown { get => Input.GetMouseButtonDown(0); }
    void Start()
    {
        isWin.playerWon = false;
        canTrigger = false;
    }
    private void Update()
    {
        if (mouseDown && canTrigger)
        {
            WinFunc();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTrigger = false;
        }
    }
    private void WinFunc()
    {
        foreach (GameObject item in objectsToActivate)
        {
            item.SetActive(true);
        }
        isWin.playerWon = true;
        SceneManager.LoadScene(0);
    }
}
