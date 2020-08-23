using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconCooldown : MonoBehaviour
{

    public Image iconCooldown;

    public float cooldownTimer;
    public float currentCooldown = 0;


    private void FixedUpdate()
    {
        Cooldown();
    }
    void Cooldown()
    {

        if (currentCooldown < cooldownTimer)
        {
            currentCooldown += Time.deltaTime;

        }
        iconCooldown.fillAmount = currentCooldown / cooldownTimer;
    }
}
