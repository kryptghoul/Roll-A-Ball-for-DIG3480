using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController2 : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;
    public Text livesText;

    private Rigidbody rb;
    private int count;
    private int lives;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        lives = 3;
        SetLivesText ();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }

        if (other.gameObject.CompareTag("Enemy Pickup"))
        {
            other.gameObject.SetActive (false);
            lives = lives - 1;
            SetLivesText ();
            if (0 >= lives)
            {
                Destroy(gameObject);
            }
        }

        if (count == 12)
        {
        transform.position = new Vector3(-60.0f, transform.position.y, transform.position.z); 
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 20)
        {
            winText.text = "You Win!";
        }
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString ();
        if (0 >= lives)
        {
            loseText.text = "You Lose!";
        }
    }
}
