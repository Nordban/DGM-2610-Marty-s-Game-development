using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconCooldown : MonoBehaviour
{

    public Image iconCooldown;
    
    public float cooldownTimer;
    public float currentCooldown;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
