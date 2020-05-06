using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float Speed = 100.0f;
    float maxvelocity = 10.0f;
    public Text ScoreText;
    public Text HighScoreText;
    public GameObject GameoverPanel;
    public GameObject HighscorePanel;
    public GameObject fireanim;
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;
    public AudioClip coins;
    public AudioClip obstacle;
    public AudioClip fire;
    public AudioSource backgroundaudio;
    private AudioSource audioSource;
    public obstaclegen obstaclegen;
    public obstaclegen obstaclegen2;
    private Transform cameraT;
    private int score = 0;
    private int c = 0;
    int h = 0;
    public static bool IsAlive = true;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        if(mainmenu.level == "Level I")
        {
            obstacle2.SetActive(false);
            bg2.SetActive(false);
            bg3.SetActive(false);
        }
        else if(mainmenu.level == "Level II")
        {
            obstacle1.SetActive(false);
            bg1.SetActive(false);
            bg3.SetActive(false);
        }
        else if (mainmenu.level == "Level III")
        {
            bg1.SetActive(false);
            bg2.SetActive(false);
        }
        cameraT = Camera.main.transform;
        IsAlive = true;
        rigidbody2D = GetComponent<Rigidbody2D>();
        HighScoreText.text = PlayerPrefs.GetInt("coinhighscore").ToString();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Vector2 velocity = Vector2.up * Time.deltaTime * Speed;
            velocity.y = Mathf.Clamp(velocity.y, 0, maxvelocity);
            rigidbody2D.velocity = velocity;

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.transform.localScale -= new Vector3(0.2f,0.2f, 0);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0);
        }

        if (gameObject.transform.position.x < cameraT.position.x || gameObject.transform.position.y < -5.72)
        {
            if (cameraT.position.x - gameObject.transform.position.x >= 13 || gameObject.transform.position.y < -5.72)
            {
               
                OnGameOver();

            }
        }
        h = PlayerPrefs.GetInt("coinhighscore");
        if (c == 0)
        {
            if (score > h)
            {
                c = 1;
                StartCoroutine(highscorepanel());
            }
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {


        
           other.GetComponent<SpriteRenderer>().enabled = false;
            audioSource.clip = coins;
            audioSource.Play();
        if (mainmenu.level == "Level I")
        {
            score ++;
        }
        else if (mainmenu.level == "Level II")
        {
            score += 2;
        }
        else if (mainmenu.level == "Level III")
        {
            score += 3;
        }
       
       
        ScoreText.text = score.ToString();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fire"))
        {
           
            audioSource.clip = fire;
            audioSource.Play();
            
            OnGameOver();
        }
        else if (collision.gameObject.CompareTag("obstacle1") || collision.gameObject.CompareTag("obstacle2"))
        {
            
            audioSource.clip = obstacle;
            audioSource.Play();
            
            OnGameOver();
        }
    }
    private void OnGameOver()
    {
        
        IsAlive = false;
        fireanim.GetComponent<Animator>().enabled = false;
        obstaclegen.turnoffanim();
        obstaclegen2.turnoffanim();
        var highScore = PlayerPrefs.GetInt("coinhighscore");
        highScore = score > highScore ? score : highScore;
        PlayerPrefs.SetInt("coinhighscore", highScore);
        GameoverPanel.SetActive(true);
        backgroundaudio.enabled = false;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
       

    }
    private IEnumerator highscorepanel()
    {
      
                HighscorePanel.SetActive(true);
                yield return new WaitForSeconds(5);
                HighscorePanel.SetActive(false);
        
        
    }
}
