using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Sprite up, down, left, right;
    float speed = 4.0f;

    public TMP_Text livesTxt;

    AudioSource src;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        src = GetComponent<AudioSource>();
        if (GameData.lives == 0) {
            GameData.lives = 3;
        }

        UpdateLivesText();
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKey(KeyCode.W)) {
            rb.velocity = new Vector2(0, speed);
            GetComponent<SpriteRenderer>().sprite = up;
        }
        else if (Input.GetKey(KeyCode.S)) {
            rb.velocity = new Vector2(0, -speed);
            GetComponent<SpriteRenderer>().sprite = down;

        }
        else if (Input.GetKey(KeyCode.A)) {
            rb.velocity = new Vector2(-speed, 0);
            GetComponent<SpriteRenderer>().sprite = left;

        }
        else if (Input.GetKey(KeyCode.D)) {
            rb.velocity = new Vector2(speed, 0);
            GetComponent<SpriteRenderer>().sprite = right;

        }
        else {
            rb.velocity = Vector2.zero;
        }
    }

    void Die() 
    {
        GameData.lives--;
        UpdateLivesText();

        rb.velocity = Vector2.zero;
        this.enabled = false;

        src.PlayOneShot(deathSound);

        if (GameData.lives == 0) {
            Invoke("LoadLoseScene", deathSound.length); 
        } else {
            Invoke("ReloadScene", deathSound.length); 
        }
    }

    void LoadLoseScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
    }

void ReloadScene()
    {
        var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
        this.enabled = true;
    }

    void UpdateLivesText()
    {
        livesTxt.text = "Lives: " + GameData.lives.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("AI")) {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("AI")) {
            Die();
        }
    }
}
