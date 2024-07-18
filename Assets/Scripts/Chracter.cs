using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Chracter : MonoBehaviour
{
    public NavMeshAgent agent;
    public SpriteRenderer sRenderer;
    public AudioSource device;
    public float Spawntime;
    public bool spawned;
    public AudioClip jumpscareSound;
    public float timetilDeath;
    public Animator jumpscareAnim;
    public bool abouttodie;
    public string Jumpname;
    public bool MouseSelect;
    public Vector3 OGpoint;
    float originalSpawntime;
    public string Quote;
    // Start is called before the first frame update




    void Awake()
    {
        spawned = false;

        device = this.GetComponent<AudioSource>();
        originalSpawntime = this.Spawntime;
        sRenderer.enabled = false;
        OGpoint = this.transform.position;
    }




 
    private void OnMouseOver()
    {
        MouseSelect = true;
    }

    private void OnMouseExit()
    {
        MouseSelect = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Spawntime > 0f)
        {
            Spawntime -= 1f * Time.deltaTime;
        }
        else
        {
            if (!spawned)
            {
                spawned = true;
                SpawnCharacter(this.transform.position);
            }

        }


        if (abouttodie)
        {
            timetilDeath -= 1f * Time.deltaTime;
        }

        if (timetilDeath < 0f)
        {
            
            CallAudioPlay(jumpscareSound);
            
           
            jumpscareAnim.SetBool(Jumpname, true);
            GameController.whoyoudiedto = this.gameObject.name;
            GameController.chracterQuote = this.Quote;
            Debug.Log("You died to " + this.gameObject.name);
            GameObject.Find("Player").GetComponent<PlayerManager>().isDying = true;

        }
    }


    public void ResetCharacter()
    {
        DespawnCharacter();

        CancelInvoke();
        
        device.clip = null;
  
        
        abouttodie = false;
        
        agent.Warp(OGpoint);
        spawned = false;
        Spawntime = originalSpawntime;
        Awake();
    }


    public void SpawnCharacter(Vector3 spawnPos)
    {
        sRenderer.enabled = true;
        this.gameObject.transform.position = spawnPos;
    }

    public void GoToPosition(Vector3 targetPos)
    {
        agent.SetDestination(targetPos);
    }

    public void DespawnCharacter()
    {
        sRenderer.enabled = false;
    }


    public void ChangeSprite(Sprite toChange)
    {
        sRenderer.sprite = toChange;
    }

    public void CallAudioPlay(AudioClip clip)
    {
        if (!device.isPlaying)
        {
            device.clip = clip;
            device.Play();
        }
    }
}
