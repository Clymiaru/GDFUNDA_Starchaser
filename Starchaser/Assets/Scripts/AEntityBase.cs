using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEntityBase : MonoBehaviour
{
    protected int HP;
    public void TakeDamage(int damage)
    {
        this.HP -= damage;
        StartCoroutine(this.DisplayDamageReceived());
        Debug.Log("remaining HP: " + HP);
    }

    protected IEnumerator DisplayDamageReceived()
    {
        Renderer[] materials = this.GetComponentsInChildren<Renderer>();
        List<Color> originalColors = new List<Color>();
        for (int i = 0; i < materials.Length; i++)
        {
            originalColors.Add(materials[i].material.color);
            materials[i].material.color = Color.red;
        }
        yield return new WaitForSeconds(0.25f);
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].material.color = originalColors[i];
        }
    }
}
