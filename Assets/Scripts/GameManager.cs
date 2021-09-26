using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    // Create a static instance of this game manager.
    public static GameManager instance;
    [Header("Data:")]
    // Store the points.
    public int points;
    // Store the money.
    public int money;
    public int startingMoney;
    // Store the amount health the base has.
    public int health;
    public int maxHealth;
    // Stores data to determine if the game is paused or not.
    public bool isPaused;
    // Stores an array of waves.
    public Wave[] waves;
    // Stores the current debris existing in the scene.
    public List<GameObject> debrisList = new List<GameObject>();
    public Transform[] debrisSpawnPoints;
    [System.Serializable]
    public struct Wave
    {
        [Tooltip("How long the wave will last. Time in seconds.")]
        [Range(0.001f, Mathf.Infinity)]
        public float timer;

        [Tooltip("How much debris will fall every second")]
        [Range(0.001f, Mathf.Infinity)]
        public float debrisPerSecond;

        [Tooltip("The maximum amount of debris at one time.")]
        [Range(0, 20)]
        public int maxDebrisAtATime;

        [Tooltip("The health multiplier to make the debris stronger.")]
        [Range(1, Mathf.Infinity)]
        public float healthModifier;

        [Tooltip("The amount of money given at the end of a wave.")]
        [Range(0, 999999)]
        public int moneyBonus;

        [Tooltip("The debris that will fall during this wave.")]
        public GameObject[] debris;
    }


    [Header("UI Assests:")]
    // Stores the text UI's for the points and money.
    public Text pointsText;
    public Text moneyText;
    // Stores the gameobject for the pause menu panel and the start wave panel.
    public GameObject pausePanel;
    public GameObject startWavePanel;




    float timer;
    // Debris per second timer.
    float debrisDelay = 0;
    bool waveStarted;
    int currentWave;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        health = maxHealth;
        money = startingMoney;
    }
    void Update()
    {
        if (!isPaused)
        {
            WaveManager();
        }
    }

    private void WaveManager()
    {
        if (waveStarted)
        {
            if (timer >= 0)
            {
                Debug.Log("Debris Delay Timer: " + debrisDelay);
                Debug.Log("Timer: " + timer);
                // If the delay between spawing debris is less than or equal to zero and
                // current amount of debris exceed the maximum amount at a time.
                if (debrisDelay <= 0 && debrisList.Count <= waves[currentWave].maxDebrisAtATime)
                {
                    // Pick a random spawn point
                    Transform randomSpot = debrisSpawnPoints[Random.Range(0, debrisSpawnPoints.Length)];
                    // Pick a random debris object.
                    GameObject debrisToSpawn = waves[currentWave].debris[Random.Range(0, waves[currentWave].debris.Length)];
                    // Spawn in the debris
                    GameObject debris = Instantiate(debrisToSpawn, randomSpot.position, Quaternion.identity);
                    debrisList.Add(debris);
                    // Add into the delay.

                    debrisDelay = (1 / waves[currentWave].debrisPerSecond);

                }
                else
                {
                    debrisDelay -= Time.deltaTime;
                }


                // Subtract the timer in real time.
                timer -= Time.deltaTime;
            }
            else
            {
                // End the wave.
                waveStarted = false;
                // Give the money bonus/
                money += waves[currentWave].moneyBonus;
                startWavePanel.SetActive(true);
            }

        }
    }

    /// <summary>
    /// Changes the state of the game if it's paused or not.
    /// </summary>
    /// <param name="pause"> Is it paused? True or False. </param>
    public void ChangePauseState(bool pause)
    {
        // If the game is paused.
        if (pause)
        {
            // Sets the paused to true.
            isPaused = true;
            // Sets the timescale to 0.
            Time.timeScale = 0;
        }
        // If the game is not paused.
        else
        {
            // Sets the paused to false.
            isPaused = false;
            // Sets the timescale to 1.
            Time.timeScale = 1;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartWave()
    {
        currentWave += Mathf.Clamp(currentWave, 0, waves.Length-1);
        // Set the timer.
        timer = waves[currentWave].timer;
        waveStarted = true;
        waves[currentWave].debrisPerSecond = Mathf.Clamp(waves[currentWave].debrisPerSecond, 0.001f, Mathf.Infinity);
        currentWave += 1;
    }

    public void GameOver()
    {
        waveStarted = false;
        SceneManager.LoadScene("EndGameScene");
    }
    public void ResetData()
    {
        money = 0;
        points = 0;
        currentWave = 0;
    }
}

