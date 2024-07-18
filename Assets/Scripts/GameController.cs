using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController gc;
    public int[] fbu;
    public static string whoyoudiedto;
    public static string chracterQuote;
    // Start is called before the first frame update
    void Start()
    {
        if (gc != null)
        {
            gc = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
