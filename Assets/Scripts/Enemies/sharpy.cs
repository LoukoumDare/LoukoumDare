using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharpy : MonoBehaviour
{

    public Vector3 aimedPosition;
    public float speed = 1f;
    public float sideSpeed = 3f;
    private float SPEED_BOOST = 3f;
    private float SPEED_STANDARD = 1f;
    private float x;
    private float y;
    public float timeSinceLastChangeState = 0;
    public int state = 0;
    private int STANDARD = 0;
    private int BOOST = 1;
    private float currentJerk = 0;
    public float jerkIncrementBase = 0.5f;

    public float BOOST_TIME_DURATION = 1f;
    public float STANDARD_TIME_DURATION = 2f;
    public float timeToNextJerk = 2f;
    public float JERK_DELAY = 0.5f;
    public float MAX_JERK_RANGE = 5f;
    public float damage = 20;
    enemyHealth _enemyHealth;
    PlayerHealth playerHealth;

    bool facingRight = false;

    void Start()
    {
        // aimedPosition = new Vector3(Random.Range (1, 10), Random.Range (0, 10));
        this.currentJerk = Random.Range(0f, MAX_JERK_RANGE);
    }

    void checkState()
    {
        this.timeSinceLastChangeState += Time.deltaTime;
        if (state == BOOST)
        {
            if (this.timeSinceLastChangeState > this.BOOST_TIME_DURATION)
            {
                this.timeSinceLastChangeState = 0;
                this.state = STANDARD;
                this.speed = SPEED_STANDARD;
                this.sideSpeed = SPEED_STANDARD;
            }
        }
        else if (state == STANDARD)
        {
            if (this.timeSinceLastChangeState > this.STANDARD_TIME_DURATION)
            {
                this.timeSinceLastChangeState = 0;
                this.state = BOOST;
                this.speed = SPEED_BOOST;
                this.sideSpeed = SPEED_BOOST;
            }
        }

    }
    void checkIncrementJerk()
    {
        if (timeToNextJerk > JERK_DELAY)
        {
            this.currentJerk = Random.Range(0f, MAX_JERK_RANGE);
            timeToNextJerk = 0;
        }
        timeToNextJerk += Time.deltaTime;
    }

    void Update()
    {
        aimedPosition = GameObject.Find("player").transform.position;
        //float AngleRad = Mathf.Atan2(aimedPosition.x - transform.position.x, aimedPosition.y - transform.position.y);
        //float AngleDeg = (180 / Mathf.PI) * AngleRad * -1;
        //this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg); 

        Vector3 diffPosition = aimedPosition - transform.position;
        Vector3 vectorMotion = diffPosition.normalized * speed * Time.deltaTime;
        this.checkState();
        this.checkIncrementJerk();

        // compute shift right/left
        Vector3 vectorShift = transform.right * (Mathf.Sin(currentJerk) - 0.5f) * sideSpeed * Time.deltaTime;

        if (diffPosition.magnitude < speed * Time.deltaTime)
        {
            transform.position = aimedPosition;
            this.speed = 0;
            this.sideSpeed = 0;

        }
        else
        {
            var translationVector = vectorMotion + vectorShift;
            transform.Translate(translationVector, Space.World);

            if ((facingRight && translationVector.x < -0.01) || (!facingRight && translationVector.x > 0.01))
            {
                facingRight = !facingRight;
                transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            _enemyHealth = GetComponent<enemyHealth>();
            _enemyHealth.TakeDamage((int)(collision.gameObject.GetComponent<bulletControler>().damage), new Vector3(0, 0, 0));
            Debug.Log(collision.gameObject.GetComponent<bulletControler>().damage);
        }
        if (collision.gameObject.tag == "Body")
        {
            // Destroy(gameObject);
            playerHealth = collision.gameObject.GetComponentInParent<PlayerHealth>();
            playerHealth.TakeDamage((int)(this.damage));
        }
    }
}
