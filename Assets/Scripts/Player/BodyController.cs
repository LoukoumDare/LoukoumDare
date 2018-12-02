using UnityEngine;

public class BodyController : MonoBehaviour {
    bool facingRight = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject Player = GameObject.Find("player");
        transform.position= new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        transform.rotation = Player.transform.rotation* Quaternion.Euler(0,0,90);
        Vector3 mouseworldpose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float moveDirection = transform.position.x - mouseworldpose.x;
        if ((facingRight && moveDirection < -0.01) || (!facingRight && moveDirection > 0.01))
        {
            facingRight = !facingRight;
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Enemi")
        //{
        //    // Destroy(gameObject);
        //    PlayerHealth playerHealth = this.GetComponentInParent<PlayerHealth>();
        //    playerHealth.TakeDamage((int)(collision.gameObject.damage));
        //}
    }
}
