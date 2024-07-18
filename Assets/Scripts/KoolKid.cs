using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoolKid : Chracter
{
    public AudioClip boneBreak, Yap, Yap2;
    public Transform KKColl;
    public Sprite[] KK_Sprites;
    public bool yapping;
    int phase;
    // Start is called before the first frame update
    void Start()
    {
        Spawntime = Random.Range(12, 15);
        timetilDeath = this.Yap.length;
        
        phase = 0;
        sRenderer.sprite = KK_Sprites[0];
        yapping = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       if (spawned)
        {
            GoToPosition(KKColl.transform.position);
            if (!yapping)
            {
                Invoke("ShutTheFuckUpYouNastyBitch", 2f);
                yapping = true;
            }
          
        }
       if (MouseSelect && Input.GetMouseButtonDown(0))
        {
            phase++;
            sRenderer.sprite = KK_Sprites[phase];
            device.PlayOneShot(boneBreak);

        }


       if (phase == 4)
        {
            ResetCharacter();
            yapping = false;
            phase = 0;
            StartCoroutine(ByeKoolKid());
            this.gameObject.GetComponent<AudioEchoFilter>().enabled = true;
            IEnumerator ByeKoolKid()
            {
                yield return new WaitForSeconds(1f);
                this.gameObject.GetComponent<AudioEchoFilter>().enabled = false;
                device.clip = null;
            }
            Start();
        }
    }


    public void ShutTheFuckUpYouNastyBitch()
    {
       
        abouttodie = true;
        
        CallAudioPlay(Yap);
        

    }

 
}
