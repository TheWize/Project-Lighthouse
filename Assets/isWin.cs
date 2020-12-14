using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isWin : MonoBehaviour
{
    public static bool playerWon;
    [SerializeField] private GameObject beam;
    // Start is called before the first frame update
    void Start()
    {
        if (playerWon)
        {
            beam.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
