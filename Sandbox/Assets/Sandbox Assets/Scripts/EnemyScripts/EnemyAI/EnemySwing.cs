using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwing : MonoBehaviour
{

    public float swingingSpeed = 2f;
    public float coolDownSpeed = 2f;
    public float coolDownDuration = 0.5f;
    public float attackDurration = .35f;
    public GameObject lftPivt;
    public GameObject rhtPivt;
    public Collider leftArm;
    public Collider rightArm;


    private float coolDownTimer;
    [SerializeField]
    private Quaternion targetRotationLft;
    [SerializeField]
    private Quaternion targetRotationRht;
    private bool isAttacking;
    private bool lftPiviot;



    void Start()
    {
        targetRotationLft = Quaternion.Euler(0, 0, 72);
        targetRotationRht = Quaternion.Euler(-50, -11, -55);
        lftPiviot = true;
        rightArm.enabled = false;
        leftArm.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        lftPivt.transform.localRotation = Quaternion.Lerp(lftPivt.transform.localRotation, targetRotationLft, Time.deltaTime * (isAttacking ? swingingSpeed : coolDownSpeed));
        rhtPivt.transform.localRotation = Quaternion.Lerp(rhtPivt.transform.localRotation, targetRotationRht, Time.deltaTime * (isAttacking ? swingingSpeed : coolDownSpeed));

        coolDownTimer -= Time.deltaTime;
    }
    public bool LftPiviot
    {
        get { return lftPiviot; }
    }
    public bool IsAttacking
    {

        get { return isAttacking; }

    }
    public void Attack()
    {
        if (lftPiviot == true)
        {

            if (coolDownTimer > 0f)
            {
                return;
            }
            targetRotationLft = Quaternion.Euler(0, 105, 72);
            coolDownTimer = coolDownDuration;

            StartCoroutine(Cooldownwait());
        }
        if (lftPiviot == false)
        {
            if (coolDownTimer > 0f)
            {
                return;
            }
            targetRotationRht = Quaternion.Euler(-50, -105, -55);
            coolDownTimer = coolDownDuration;

            StartCoroutine(Cooldownwait());
        }
    }
    private IEnumerator Cooldownwait()
    {
        isAttacking = true;
        if (lftPiviot == true)
        {
            leftArm.enabled = true;
            yield return new WaitForSeconds(attackDurration);
            isAttacking = false;
            targetRotationLft = Quaternion.Euler(0, 0, 72);
            lftPiviot = false;
            leftArm.enabled = false;
        }
        else
        {
            rightArm.enabled = true;
            yield return new WaitForSeconds(attackDurration);
            isAttacking = false;
            rightArm.enabled = false;
            targetRotationRht = Quaternion.Euler(-50, -11, -55);
            lftPiviot = true;
        }

    }

}