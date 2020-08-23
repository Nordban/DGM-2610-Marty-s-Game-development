using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DeathUI : MonoBehaviour
{

    public TextMeshProUGUI deathWording;
    public Button respawn;
    public Button quit;
    public GameObject deathTxt;
    public Respawn respawnScript;
    public EnemySpawnpointManager enemySpawnpointManager;

    [SerializeField]
    private bool fadeInComplete = false;
    private Color deathBGAlpha;
    private Color deathWordingAlpha;


    private Image deathTextBGAlpha;





    // Start is called before the first frame update
    void Start()
    {

        deathTextBGAlpha = deathTxt.gameObject.GetComponent<Image>();

        deathBGAlpha = deathTextBGAlpha.color;
        deathBGAlpha.a = 0;

        deathWordingAlpha = deathWording.color;
        deathWordingAlpha.a = 0;

        //this is how you make buttons trigger multiple functions
        respawn.onClick.AddListener(() => DisableDeathUI());
        respawn.onClick.AddListener(() => respawnScript.ReEnablePlayerControls());
        //respawn.onClick.AddListener(() => enemySpawnpointManager.Respwan());
    }


    public void EnableDeathUI()
    {
        deathTxt.SetActive(true);
        StartCoroutine(DeathMenuFadeIn());
    }
    public void DisableDeathUI()
    {
        deathTxt.SetActive(false);
        deathBGAlpha.a = 0;
        deathWordingAlpha.a = 0;
        deathTextBGAlpha.color = deathBGAlpha;
        deathWording.color = deathWordingAlpha;
        respawn.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        fadeInComplete = false;
    }

    private IEnumerator DeathMenuFadeIn()
    {
        while (fadeInComplete != true)
        {
            deathBGAlpha.a += .005f;
            deathWordingAlpha.a += .005f;
            deathTextBGAlpha.color = deathBGAlpha;
            deathWording.color = deathWordingAlpha;
            if (deathTextBGAlpha.color.a >= 1)
            {
                fadeInComplete = true;
            }

            //Debug.Log("This is my current alpha  " + deathTextBGAlpha.color.a);
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        respawn.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
    }

}
