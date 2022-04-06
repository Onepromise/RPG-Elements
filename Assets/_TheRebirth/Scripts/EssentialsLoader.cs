using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{

    public GameObject UIScreen;
    public GameObject player;
    public GameObject gameMan;
    // Start is called before the first frame update
    void Start()
    {

  
        if(GameManager.instance == null)
        {
            Instantiate(gameMan);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
