using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject lineController;

    public float lift;
    public float speed;

    private bool canMove = true;
    private bool moveForward = true;

    private GameObject Shadow;

    public GameObject fireExplosion;
    public GameObject blueExplosion;

    public Sprite RedSprite;
    public Sprite BlueSprite;

    private void Awake()
    {
        lineController = this.transform.GetChild(0).gameObject;
        lineController.SetActive(false);
        rb = this.GetComponent<Rigidbody2D>();
        Shadow = GameObject.FindGameObjectWithTag("PlayerShadow");

        if (MenuController.blue) this.GetComponent<SpriteRenderer>().sprite = BlueSprite;
        else this.GetComponent<SpriteRenderer>().sprite = RedSprite;
    }

    void Update()
    {
        if (Mathf.Abs(rb.velocity.y) > 3) lineController.SetActive(true);
        else lineController.SetActive(false);


        if (this.transform.position.y < -6.3f || this.transform.position.y > 10f) StartCoroutine(Died());
    }

    private void LateUpdate()
    {
        Vector2 moveDirection = rb.velocity;         //Rotate player towards move direction
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (moveForward) rb.velocity = new Vector2(speed, rb.velocity.y); //Continously move player forward

        if (Input.GetMouseButton(0) && canMove) rb.AddForce(new Vector2(0, 1) * lift * Time.deltaTime);

        if (Shadow != null)
        {
            if (transform.position.y <= Shadow.transform.position.y) Shadow.SetActive(false);
            else Shadow.SetActive(true);
        }
    }

    IEnumerator Died()
    {
        GameController.dead = true;
        canMove = false;
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("BetweenGameScene");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            GameObject curFireBall = Instantiate(fireExplosion, this.transform.position, Quaternion.identity);
            AudioManager.instance.Play("FireBallHit");
            Destroy(curFireBall, 6);
            Destroy(collision.gameObject);
            StartCoroutine(Died());
        }

        if (collision.tag == "Projectile1")
        {
            GameObject curFireBall = Instantiate(blueExplosion, this.transform.position, Quaternion.identity);
            AudioManager.instance.Play("FireBallHit");
            Destroy(curFireBall, 6);
            Destroy(collision.gameObject);
            StartCoroutine(Died());
        }

        if (collision.tag == "Coin")
        {
            GameController.lastScore += 8;
            AudioManager.instance.Play("CollectScroll");
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obsticle")
        {
            AudioManager.instance.Play("Hit");
            StartCoroutine(Died());
            moveForward = false;
        }
    }
}
