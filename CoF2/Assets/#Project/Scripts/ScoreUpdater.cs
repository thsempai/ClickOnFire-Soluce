using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreUpdater : MonoBehaviour
{
    public LevelManager manager;
    // Start is called before the first frame update
    void Start()
    {
        if(manager == null) {
            manager = FindObjectOfType<LevelManager>();
        }        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = 
            manager.score.ToString();
    }
}
