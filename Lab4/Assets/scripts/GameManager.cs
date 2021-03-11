using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject instructionsButton;
    public GameObject startButton;
    public GameObject sourcesButton;
    public GameObject canvas;
    public GameObject events;
    public GameObject title;
    public GameObject backgroundImage;
    public GameObject sourcesText;
    public GameObject player;
    public GameObject camera;
    public Vector3 pos;
    public Vector3 nextPlayerLoc;
    public GameObject projectile;
    public GameObject dialoguebox;
    public GameObject dialoguetext;

    public GameObject instructionsText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(camera);
            DontDestroyOnLoad(projectile);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void InstructionsButton()
    {

        sourcesButton.SetActive(false);
        title.SetActive(false);
        instructionsButton.SetActive(false);
    

        instructionsText.GetComponent<TextMeshProUGUI>().text = "How to Play: To move, use the arrow keys. Find the lost members of your family!";

      
    }
    public void SourcesButton()
    {

        instructionsButton.SetActive(false);
        sourcesButton.SetActive(false);
        title.SetActive(false);
 
        sourcesText.GetComponent<TextMeshProUGUI>().text = "rock: https://pixy.org/203104/ popcorn: https://opengameart.org/content/popcorn-icon ship: https://opengameart.org/content/ufo-boss-set tilemap: https://soulares.itch.io/moonroar-cave-field shovel: https://opengameart.org/content/shovel-1 astronaut: https://marmoset.co/posts/sprite-sheet-creation-in-hexels/ sign: https://opengameart.org/content/lpc-sign-post";


    }
    public void StartButton()
    {
  
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 2));
        startButton.SetActive(false);
        instructionsButton.SetActive(false);
        sourcesButton.SetActive(false);
        title.SetActive(false);
        player.SetActive(true);
        StartCoroutine(LoadYourAsyncScenee("centralhub"));
      
        instructionsText.GetComponent<TextMeshProUGUI>().text = "";
        sourcesText.GetComponent<TextMeshProUGUI>().text = "";
       
        
    }
    IEnumerator LoadYourAsyncScene(string scene, Vector3 whereTo)
    {
        nextPlayerLoc = whereTo;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        player.transform.position = nextPlayerLoc;
       
    }



    IEnumerator ColorLerp(Color endValue, float duration)
    {
        float time = 0;
        Image sprite = backgroundImage.GetComponent<Image>();
        Color startValue = sprite.color;
        while (time < duration)
        {
            sprite.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = endValue;
    }
    public void NextScene(string whichScene, Vector3 whereTo)
    {


        StartCoroutine(LoadYourAsyncScene(whichScene, whereTo));

    }

    IEnumerator LoadYourAsyncScenee(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void startdialogue(string text)
    {
        dialoguebox.SetActive(true);
        dialoguetext.GetComponent<TextMeshProUGUI>().text = text;
    }

    public void hidedialogue()
    {
        dialoguebox.SetActive(false);
    }

}
