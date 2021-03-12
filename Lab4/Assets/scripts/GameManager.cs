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
    private int score = 0;
    private int numm = 0;
    private int fish = 0;
    public GameObject backgroundImage;
    public GameObject black;
    public GameObject sourcesText;
    public GameObject player;
    public GameObject camera;
    public Vector3 pos;
    public Vector3 nextPlayerLoc;
    public GameObject projectile;
    public GameObject dialoguebox;
    public GameObject dialoguetext;
    public TextMeshProUGUI scoreText;
    public GameObject jellysave1;
    public GameObject jellysave2;
    public GameObject jellysave3;
    public GameObject dest;
    private GameObject instance;
    public Image[] hearts;
    private bool[] heartEnabled;
    private int playerLife = 3;

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
        heartEnabled = new bool[hearts.Length];

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
        
        //StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 2,backgroundImage));
        startButton.SetActive(false);
        instructionsButton.SetActive(false);
        sourcesButton.SetActive(false);
        title.SetActive(false);
        player.SetActive(true);
        dest.SetActive(true);
        StartCoroutine(LoadYourAsyncScenee("centralhub"));
      
        instructionsText.GetComponent<TextMeshProUGUI>().text = "";
        sourcesText.GetComponent<TextMeshProUGUI>().text = "";
        
       for(int i = 0; i < hearts.Length; i++ ){
            heartEnabled[i] = true;
        }
        


    }
    IEnumerator LoadYourAsyncScene(string scene, Vector3 whereTo)
    {
        nextPlayerLoc = whereTo;
        if (!SceneManager.GetActiveScene().name.Equals("Start"))
        {
            StartCoroutine(ColorLerp(new Color(0, 0, 0, 1), .5f,black));
            while (!black.GetComponent<Image>().color.Equals(new Color(0, 0, 0, 1)))
            {
                yield return null;
            }
            foreach (Image image in hearts) {
                image.enabled = false;
            }
        }
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        player.transform.position = nextPlayerLoc;
        StartCoroutine(ColorLerp(new Color(0, 0, 0, 0), 1,black));
        while (!black.GetComponent<Image>().color.Equals(new Color(0, 0, 0, 0)))
        {
            yield return null;
        }
        StartCoroutine(DisplayHearts());

    }



    IEnumerator ColorLerp(Color endValue, float duration,GameObject pic)
    {
        float time = 0;
        Image sprite = pic.GetComponent<Image>();
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
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 2, backgroundImage));
        while (!backgroundImage.GetComponent<Image>().color.Equals(new Color(1, 1, 1, 0)))
        {
            yield return null;
        }
        StartCoroutine(DisplayHearts());
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
    public void PlayerHit()
    {

        playerLife--;
        hearts[playerLife].enabled = false;
        heartEnabled[playerLife] = false;
        if (playerLife == 0)
        {
            NextScene(SceneManager.GetActiveScene().name,new Vector3(0,0,0));
            playerLife = 3;
            for (int i = 0; i < hearts.Length; i ++) {
                heartEnabled[i] = true;
            }
            StartCoroutine(DisplayHearts());
        }

    }

    public void IncScore(int ds)
    {
        score += ds;
        scoreText.text = "Jellyfish saved: " + score + "/3";
        
        
    }

    public void number(int num)
    {
        if (numm == 0)
        {
            numm = num;
        }
    }

    public void Jelly1()
    {
        
        jellysave1.SetActive(true);
        dest.SetActive(true);
        if (score == 2 && numm == 3){
            jellysave3.SetActive(true);
        } if (score == 2 && numm == 2)
        {
            jellysave2.SetActive(true);
        }
        if (score == 3){
            jellysave2.SetActive(true);
            jellysave3.SetActive(true);
            dest.SetActive(false);
        }
    }
    public void Jelly2()
    {

        jellysave2.SetActive(true);
        dest.SetActive(true);
        if (score == 2 && numm == 1)
        {
            jellysave1.SetActive(true);
        }
        if (score == 2 && numm == 3)
        {
            jellysave3.SetActive(true);
        }
        if (score == 3)
        {
            jellysave1.SetActive(true);
            jellysave3.SetActive(true);
            dest.SetActive(false);
        }
    }
    public void Jelly3()
    {

        jellysave3.SetActive(true);
        dest.SetActive(true);
        if (score == 2 && numm == 1)
        {
            jellysave1.SetActive(true);
        }
        if (score == 2 && numm == 2)
        {
            jellysave2.SetActive(true);
        }
        if (score == 3)
        {
            jellysave1.SetActive(true);
            jellysave2.SetActive(true);
            dest.SetActive(false);
        }
    }

    public void JellyNo()
    {
        jellysave1.SetActive(false);
        jellysave2.SetActive(false);
        jellysave3.SetActive(false);
        dest.SetActive(false);
    }
    public GameObject GetPlayer()
    {
        return player;
    }
    IEnumerator DisplayHearts()
    {
        for (int i = 0; i < hearts.Length; i++ ) {
            if (heartEnabled[i]) {
                yield return new WaitForSeconds(.5f);
                hearts[i].enabled = true;
            }
        }
    }

    public void AddFish()
    {
        fish++;
        GameWin();
    }

    public void GameWin()
    {
        if (fish > 23)
        {
            NextScene("startmenu", Vector3.zero);
        }
    }

    public int GetScore()
    {
        return score;
    }

}
