using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KnockbackAttack : MonoBehaviour
{
    public Image attackUnavailable;
    public GameObject vinePrefab;
    public GameObject vineSpawnPoint;
    public Image cooldownMask;
    public float cooldownTimer;
    public float maxCooldownLength;
    public List<GameObject> enemies = null;

    


    [SerializeField]
    private InstancateVine instanciateVineScript;
    [SerializeField]
    private List<GameObject> vines = null;
    // Start is called before the first frame update
    void Start()
    {
        instanciateVineScript = vineSpawnPoint.GetComponent<InstancateVine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && enemies.Count >= 1 && cooldownTimer <= 0)
        {

            AreaAttack();

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
            attackUnavailable.enabled = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
            attackUnavailable.enabled = true;
        }
    }
    void AreaAttack()
    {
        foreach (var gameObject in enemies)
        {

            vines.Add(instanciateVineScript.InstanciateVinePrefab());
        }
        for (int i = 0; i < vines.Count; i++)
        {
            vines[i].gameObject.transform.LookAt(enemies[i].gameObject.transform);
        }
        foreach (var gameObject in vines)
        {
            gameObject.transform.localScale = new Vector3(10f, 10f, 115);

        }
        StartCoroutine("DestroyVines");
        //cooldown.currentCooldown = cooldownTime;

    }
    private IEnumerator DestroyVines()
    {
        yield return new WaitForSeconds(.5f);
        foreach (var gameObject in vines)
        {
            Destroy(gameObject.gameObject);

        }
        vines.Clear();
    }
}
