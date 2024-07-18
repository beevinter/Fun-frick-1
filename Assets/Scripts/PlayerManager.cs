using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    public string gameoverScene;
    public float delay;
    public bool isDying;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDying)
        {
            StartCoroutine(GameOver());
        }
    }


    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(gameoverScene, LoadSceneMode.Single);
      
    }
}
