using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesign : MonoBehaviour
{
    public bool waveStart=false;
    public GameObject enemy;
    public Transform spawnPosition1;
    public Transform spawnPosition2;
    public float summonRate = 1f;
    public int waveLength = 25;
    public int remainingEnemies;
    public static float wellhealth = 100;
    public RectTransform well;
    public static bool gameOver;
    public GameObject tutorialCanva;
    public GameObject panelW;
    public GameObject panelGO;
    // Start is called before the first frame update
    void Start()
    {
        LevelDesign.wellhealth = 100;
        LevelDesign.gameOver = false;
        //waveStart=true;
        InvokeRepeating("SummonEnemy",0f,summonRate);
        remainingEnemies = waveLength *2;

        

    }

    // Update is called once per frame
    void Update()
    {
        well.localScale = Vector3.one * wellhealth / 100;
        Debug.Log(well.anchoredPosition);

        well.anchoredPosition = new Vector2(-(wellhealth-50)*2 + 100, well.anchoredPosition.y);

        if (gameOver)
        {
            Time.timeScale = 0.001f;
            panelGO.SetActive(true);

        }
        if(!GameObject.FindGameObjectWithTag("enemy") && waveStart)
        {
            panelW.SetActive(true);
        }
    }
    public void KillEnemy(){
        remainingEnemies --;
    }

    void SummonEnemy(){
        if(waveStart && waveLength>0){
            var e1 = Instantiate(enemy,spawnPosition1.position,spawnPosition1.rotation);
            var e2 = Instantiate(enemy,spawnPosition2.position,spawnPosition2.rotation);
            waveLength --;
        }
    }
    public void startLevel()
    {
        waveStart = true;
        tutorialCanva.SetActive(false);

        GameObject [] towers = GameObject.FindGameObjectsWithTag("Towers");
        foreach(GameObject go in towers)
        {
            go.transform.localScale = Vector3.one;
        }
    }
}
