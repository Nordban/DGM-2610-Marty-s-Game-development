using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancateVine : MonoBehaviour
{
    public GameObject vinePrefab;
    [SerializeField]
    private GameObject vineAttackCollider;
    // Start is called before the first frame update
    void Start()
    {
        vineAttackCollider = gameObject.GetComponentInParent<KnockbackAttack>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject InstanciateVinePrefab()
    {
        //(Instantiate(vinePrefab, this.gameObject.transform.position, Quaternion.LookRotation(gameObject.transform.forward)) as GameObject).transform.parent = this.gameObject.transform;
        var vinePrefabClone =  (Instantiate(vinePrefab, this.gameObject.transform.position, Quaternion.identity)) as GameObject;
        vinePrefabClone.transform.parent = this.gameObject.transform;
        return vinePrefabClone;
    }
}
