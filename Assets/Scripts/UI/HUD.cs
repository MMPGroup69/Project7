using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class HUD : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 300f;

    public static int currentLifes = 0;
    int startingLifes = 1;

    public static int currentCoins = 0;
    int startingCoins = 0;

    public static int currentKeys = 0;
    int startingKeys = 0;

    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI keyText;
    [SerializeField] TextMeshProUGUI countdownText;
  
    void Start()
    {
        currentLifes = startingLifes;
        currentCoins = startingCoins;
        currentTime = startingTime;
        currentKeys = startingKeys;
    }

    void Update()
    {
        lifeText.text = currentLifes.ToString();
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
        else if (currentLifes <= 0) {
            //load GAME OVER scene
            SceneManager.LoadScene(2);
        }
        else if (currentCoins >= 10)
        {
            currentCoins = 0;
            currentLifes += 1;
        }
        else if (currentKeys >=3) {

            Debug.Log("arrrrr3");
        }
    }
}
