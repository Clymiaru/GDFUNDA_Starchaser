using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeamEntity : AEntityBase
{
    public AudioClip hurtSFX;
    public AudioSource SFXPlayer;
    // Start is called before the first frame update
    void Start()
    {
        this.HP = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void PlaySFX()
    {
        SFXPlayer.clip = hurtSFX;
        SFXPlayer.Play();
    }
}
