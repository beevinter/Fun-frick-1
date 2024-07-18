using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOver : MonoBehaviour
{

    public TMP_Text characterName, characterQuote;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        characterName.text = GameController.whoyoudiedto;
        characterQuote.text = GameController.chracterQuote;
       
    }
}
