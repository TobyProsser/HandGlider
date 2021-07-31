using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChillPlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject lineController;

    public float lift;
    public float speed;

    private bool canMove = true;
    private bool moveForward = true;

    public Sprite RedSprite;
    public Sprite BlueSprite;

    private void Awake()
    {
        lineController = this.transform.GetChild(0).gameObject;
        lineController.SetActive(false);
        rb = this.GetComponent<Rigidbody2D>();

        if (MenuController.blue) this.GetComponent<SpriteRenderer>().sprite = BlueSprite;
        else this.GetComponent<SpriteRenderer>().sprite = RedSprite;
    }

    void Update()
    {
        if (Mathf.Abs(rb.velocity.y) > 3) lineController.SetActive(true);
        else lineController.SetActive(false);


        if (this.transform.position.y < -10f || this.transform.position.y > 10f) StartCoroutine(Died());
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
    }

    IEnumerator Died()
    {
        GameController.dead = true;
        canMove = false;
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("BetweenChillGameScene");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            AudioManager.instance.Play("CollectScroll");
            Destroy(collision.gameObject);
            ChillController.lastChillScore++;
        }
    }
}
