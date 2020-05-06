using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bird : MonoBehaviour
{
    public float Speed = 100.0f;
    public Text ScoreText;
    public Text HighScoreText;
    public GameObject GameoverPanel;
    public AudioClip DieSound;
    public AudioSource backgroundaudio;
    private AudioSource audioSource;
    private int score = 0;
    float maxvelocity = 2.0f;
    public static bool IsAlive = true;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        IsAlive = true;
        rigidbody2D = GetComponent<Rigidbody2D>();
        HighScoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 velocity = Vector2.up * Time.deltaTime * Speed;
            velocity.y = Mathf.Clamp(velocity.y, 0, maxvelocity);
            rigidbody2D.velocity = velocity;
         
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other);
        score++;
        ScoreText.text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        IsAlive = false;
        audioSource.clip = DieSound;
        audioSource.Play();
        OnGameOver();
    }
    private void OnGameOver()
    {
        var highScore = PlayerPrefs.GetInt("highscore");
        highScore = score > highScore ? score : highScore;

        PlayerPrefs.SetInt("highscore", highScore);
        GameoverPanel.SetActive(true);
        backgroundaudio.enabled = false;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

}