using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunCooldown : MonoBehaviour
{
    public Image runIcon;
    public Image cooldownMask;
    [SerializeField]
    private SimpleMove simpleMoveScript;

    // Start is called before the first frame update
    void Start()
    {
        simpleMoveScript = gameObject.GetComponent<SimpleMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cooldownMask.fillAmount = simpleMoveScript.runTimer / simpleMoveScript.runAmount;
        
    }
}
