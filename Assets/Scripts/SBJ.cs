using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBJ :Chracter
{
    public Transform player;
    public bool quizzing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned & !quizzing)
        {
            GoToPosition(player.transform.position);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
        {
            quizzing = true;
        }
    }
}
