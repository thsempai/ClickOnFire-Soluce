using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    [HideInInspector]
    public LevelManager manager;
    [HideInInspector]
    public bool clicked = false;

    public int value = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        float seconds = Random.Range(3f, 5f);
        Destroy(gameObject, seconds);        
    }

    private void OnDestroy() {
        manager.RemoveCube(gameObject);
    }

    private void OnMouseDown() {
        clicked = true;
        Destroy(gameObject);
    }

}
