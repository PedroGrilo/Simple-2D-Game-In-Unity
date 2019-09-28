using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private GameObject fireball;
    private Rigidbody2D fireballRigidBody;
    private SpriteRenderer fireballSpriteRender;


    public Text textLives;
    public Text textCoins;
    public Text infoCoinsEarned;
    public Text textBalls;

    public float timeToDeath;
    public float fireballSpeed = 15f;
    public double maxVelocity;
    public int initialFireBalls;

    public int lives;
    public int coins;
    public int emeraldPrice;
    public int jumpForce;
    private int instaCoins;
    private int maxJumpTimes;

    private bool leftBall = false;
    private bool mobCollide;
    private bool canTakeDamage = true;

    public GameObject finished;
    public Text finishedScore;


    public Joystick joystick;


    // Start is called before the first frame update
    void Start(){
        textCoins.text = coins.ToString();
        textLives.text = lives.ToString();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        fireball = transform.GetChild(0).transform.gameObject;

        fireballRigidBody = fireball.GetComponent<Rigidbody2D>();
        fireballSpriteRender = fireball.GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    public void Update(){
        textLives.text = lives.ToString();
        textBalls.text = initialFireBalls.ToString();
        textCoins.text = coins.ToString();

        float movimento = 0;

        if (lives <= 0)
            _animator.SetBool("die", true);


        if (joystick.Horizontal >= .3f || joystick.Horizontal <= -.3f)
            movimento = joystick.Horizontal;
        else
            movimento = 0;

        _rigidbody2D.velocity = new Vector2((float) (movimento * maxVelocity), _rigidbody2D.velocity.y);


        if (movimento < 0){
            leftBall = true;
            fireballSpriteRender.flipX = true;
            _spriteRenderer.flipX = true;
        }

        if (movimento > 0){
            leftBall = false;
            fireballSpriteRender.flipX = false;
            _spriteRenderer.flipX = false;
        }


        if (movimento > 0 || movimento < 0)
            _animator.SetBool("andando", true);
        else
            _animator.SetBool("andando", false);
    }


    public void Jump(){
        _animator.SetBool("jump", true);
        if (maxJumpTimes < 2){
            _rigidbody2D.AddForce(new Vector2(0, jumpForce));
            maxJumpTimes++;
        }
    }

    public void fire(){
        if(initialFireBalls > 0){
            initialFireBalls--;
            var fireballInst = Instantiate(fireballRigidBody, transform.position, Quaternion.Euler(new Vector2(5, 0)));
                if (leftBall){
                    fireballInst.velocity = new Vector2(-fireballSpeed, 0);
                }else{
                    fireballInst.velocity = new Vector2(fireballSpeed, 0);
                }
        }
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Coin")){
            GetComponent<AudioSource>().Play();
            instaCoins += emeraldPrice;
            infoCoinsEarned.text = "+" + instaCoins;
            infoCoinsEarned.fontSize += 10;
            coins += emeraldPrice;
            Destroy(other.gameObject);
        }
    }


    private void takeDamage(){
        lives--;
    }

    public void OnCollisionEnter2D(Collision2D collision2D){
        if (collision2D.gameObject.CompareTag("Animal")){
            _spriteRenderer.color = new Color(255, 0, 0);
        }

        if (collision2D.gameObject.CompareTag("Plataformas")){
            _animator.SetBool("jump", false);
            infoCoinsEarned.text = "";
            instaCoins = 0;
            infoCoinsEarned.fontSize = 25;
        }

        if (collision2D.gameObject.CompareTag("Plataformas")){
            maxJumpTimes = 0;
        }

        if (collision2D.gameObject.CompareTag("endbar")){
            finishGame();
        }
    }

    public void finishGame(){
        finished.SetActive(true);
        finishedScore.text = coins.ToString();
    }

    public void OnCollisionExit2D(Collision2D collision2D){
        if (collision2D.gameObject.CompareTag("Animal") || collision2D.gameObject.CompareTag("Saw")){
            _spriteRenderer.color = new Color(255, 255, 255);
        }
    }

    private void OnCollisionStay2D(Collision2D other){
        if (other.gameObject.CompareTag("Animal")){
            if (canTakeDamage){
                _spriteRenderer.color = new Color(255, 0, 0);
                StartCoroutine(WaitForSeconds(timeToDeath));
                takeDamage();
            }
        }

        if (other.gameObject.CompareTag("Saw")){
            if (canTakeDamage){
                StartCoroutine(WaitForSeconds(0.5f));
                takeDamage();
            }
        }
    }

    IEnumerator WaitForSeconds(float time){
        canTakeDamage = false;
        yield return new WaitForSecondsRealtime(time);
        canTakeDamage = true;
    }


    public void restartGame(){
        Application.LoadLevel(1);
        Time.timeScale = 1;
    }

    public void exitGame(){
        SceneManager.LoadScene(0);
    }
}