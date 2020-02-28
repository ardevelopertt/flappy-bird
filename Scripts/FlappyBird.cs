using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FlappyBird : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Vector2 initialPosition;
    public bool isDead = false;
    private int Score = 0;
    public Text ScoreText;
    private bool isFlap = false;
    public PipeSpawner PipeSpawner;


    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Score.ToString();

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            Flap();
        }
    }

    public void Flap()
    {
        rb2d.AddForce(Vector2.up, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "goal")
        {
            Score++;
            print(Score);

        } else {
           
            isDead = true;
            ResetAll();
        }
    }

    public void ResetAll()
    {
        transform.localPosition = initialPosition;
        Score = 0;
        rb2d.velocity = Vector2.zero;
        isDead = false;
        PipeSpawner.ResetPipes();
    }

}
