using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject knifePrefab;

    public bool spawnKnife = false;

    public GameObject currentKnife;

    public PlayerController playerControllerScript;

    private int totalKnives = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
        //Total number of knives for this level.
        totalKnives = PlayerPrefs.GetInt("totalknives", 4);
        totalKnives += 1;
        PlayerPrefs.SetInt("totalknives", totalKnives);
        Debug.Log("Total knives: " + totalKnives);

        SpawnKnife();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnKnife && !playerControllerScript.gameOver)
        {
            SpawnKnife();
        }
    }

    //Spawns the knife.
    private void SpawnKnife()
    {
        if (totalKnives > 0)
        {
            currentKnife = Instantiate(knifePrefab);
            spawnKnife = false;
            totalKnives--;
            Debug.Log("Total knives: " + totalKnives);
        }
        else //Executes when the level is won.
        {
            playerControllerScript.gameOver = true;
            Debug.Log("Level Complete");
            Invoke("RestartGame", 4f);
            
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
