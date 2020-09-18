using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AEntityBase
{
    // Start is called before the first frame update
    void Start()
    {
        this.HP = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.HP <= 0)
            Destroy(this.gameObject);
    }
}
