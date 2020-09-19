using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerTeamEntity
{
    [SerializeField] private int maxHP = 100;

    public int MaxHealth 
    { 
        get
        {
            return maxHP;
        }
    }

    public int Health
    { 
        get
        {
            return this.HP;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
