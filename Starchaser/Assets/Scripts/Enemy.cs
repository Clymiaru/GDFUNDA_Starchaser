using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AEntityBase
{
    public AudioClip hurtSFX;
    public AudioClip deathSFX;
    public AudioSource SFXPlayer;
    // Start is called before the first frame update
    void Start()
    {
        this.HP = 50;
    }

    private void OnDestroy()
    {
        if (SFXPlayer != null)
        {
            SFXPlayer.clip = deathSFX;
            SFXPlayer.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.HP <= 0)
            Destroy(this.gameObject);
    }

    protected override void PlaySFX()
    {
        SFXPlayer.clip = hurtSFX;
        SFXPlayer.Play();
    }
}
