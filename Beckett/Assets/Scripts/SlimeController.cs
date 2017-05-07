using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    private bool moving;

    public float timeBetweenMove;
    private float timebetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    public float waitToReload;
    private bool reloading;
    private GameObject thePlayer;

    private Vector3 movedirection;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        //timebetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        timebetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
    }

    // Update is called once per frame
    /// <summary>
    /// Handles the movement of slime.
    /// </summary>
    void Update()
    {

        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = movedirection;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timebetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                //timebetweenMoveCounter = timeBetweenMove;
            }


        }
        else
        {
            timebetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;

            if (timebetweenMoveCounter < 0f)

                moving = true;
            timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
            //timeToMoveCounter = timeToMove;

            movedirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
        }
        if (reloading) {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                thePlayer.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        /*if (other.gameObject.name == "Player") {
            other.gameObject.SetActive(false);
            reloading = true;
            thePlayer = other.gameObject;
        }*/
    }
}