using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSB : Chracter
{

    public int spamAmm;
    public bool tweaking, clickSpawn;
    public Sprite tweak_sprite;
    public AudioClip Spamthe, Tweak;
    // Start is called before the first frame update
    void Start()
    {
        tweaking = false;
        spamAmm = 0;
        timetilDeath = 20f;
        clickSpawn = false;
    }

    // Update is called once per frame



    void Update()
    {
        if (!clickSpawn)
        {
            if (Spawntime < 0f)
            {
                OnSpawn();
                clickSpawn = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) & spawned)
        {
            spamAmm++;
        }

        if (Input.GetKeyDown(KeyCode.Space) & !spawned)
        {
            ResetCharacter();
        }

        if (spawned)
        {

            SpamTheSpaceBar();




            if (spamAmm == 35)
            {
                ResetCharacter();
                Start();
            }
        }
    }


    public void SpamTheSpaceBar()
    {
        abouttodie = true;


        if (!tweaking)
        {
            CallAudioPlay(Spamthe);
        }
        else
        {
            device.clip = null;
            CallAudioPlay(Tweak);
        }
    }


    void TweakOut()
    {
        tweaking = true;
        ChangeSprite(tweak_sprite);
    }



    void OnSpawn()
    {
        Invoke("TweakOut", 8f);
    }


}


