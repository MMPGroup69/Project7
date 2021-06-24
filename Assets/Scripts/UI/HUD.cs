using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class HUD : MonoBehaviour

{

    public GameObject door;

    float currentTime = 0f;
    float startingTime = 300f;

    public static int currentLives = 0;

    public static int currentCoins = 0;
    public int startingCoins = 0;

    public static int currentKeys = 0;
    public int startingKeys = 0;

    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI keyText;
    [SerializeField] TextMeshProUGUI countdownText;

    public bool isLocked = true;

    void Start()
    {
        currentLives = PlayerHealth.lives;
        currentCoins = startingCoins;
        currentTime = startingTime;
        currentKeys = startingKeys;
    }

    void Update()
    {
        lifeText.text = PlayerHealth.lives.ToString();
        coinText.text = currentCoins.ToString();
        keyText.text = currentKeys.ToString();
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            //load GAME OVER scene
            SceneManager.LoadScene(2);
        }
        else if (currentLives <= 0) {
            //load GAME OVER scene
            SceneManager.LoadScene(2);
        }
        else if (currentCoins >= 10)
        {
            currentCoins = 0;
            PlayerHealth.lives += 1;
        }
        else if (currentKeys >= 3) {
            if (isLocked == true){
                SoundManager.PlaySound("secret");
                isLocked = false;
                Destroy(door);
                Debug.Log("door");
            }
        }
    }
}
