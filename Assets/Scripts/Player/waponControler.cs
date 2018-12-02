using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waponControler : MonoBehaviour {
    public float timeSinceLastShoot = 0;
    Awapon wapon;
	private bool moveAndShootAllowed = true;
	private bool autoShootAllowed = true;
    bool facingRight = false;
	void Start () 
    {
        wapon = new Gun();
		EventManager.StartListening("MOVE_OR_SHOOT", () => { moveAndShootAllowed = false; });
		EventManager.StartListening("NO_AUTOSHOOT", () => { autoShootAllowed = false; });

	}
	void Update () {
        Vector3 mouseworldpose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float moveDirection = transform.position.x - mouseworldpose.x;
        if ((facingRight && moveDirection < -0.01) || (!facingRight && moveDirection > 0.01))
        {
            facingRight = !facingRight;
            //transform.position = new Vector3(0, 0, 0);
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, -1, 1));
        }
        float AngleRad = Mathf.Atan2(mouseworldpose.y - transform.position.y, mouseworldpose.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        if (Input.GetButton("Weapon"))
        {
            wapon = new MachineGun();
        }
        if (wapon.type=="LONG")
        {
            timeSinceLastShoot += Time.deltaTime;
            if (timeSinceLastShoot > wapon.delay)
            {
				Debug.Log(isAllowedToShoot() + "moveOrShoot");
                if (isAllowedToShoot()
					&& ((autoShootAllowed && Input.GetButton("Fire1"))   
						|| (Input.GetButtonDown("Fire1"))
						)
					)
				{

					Vector3 mouseworldpose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    float AngleRad = Mathf.Atan2(mouseworldpose.y - transform.position.y, mouseworldpose.x - transform.position.x);
                    float AngleDeg = (180 / Mathf.PI) * AngleRad;
                    GameObject instance = Object.Instantiate(Resources.Load("bullet", typeof(GameObject)), new Vector3(transform.position.x, transform.position.y, -2), Quaternion.Euler(0, 0, AngleDeg)) as GameObject;
                    instance.GetComponent<bulletControler>().damage = wapon.damage;
                    Destroy(instance, wapon.range);
                    timeSinceLastShoot = 0;
                }
            }
        }
    }

	public bool isAllowedToShoot()
	{
		if ( ! moveAndShootAllowed)
		{
			return ( Mathf.Abs(Input.GetAxis("Horizontal")) < 0.1 && Mathf.Abs(Input.GetAxis("Vertical")) < 0.1);
		}
		return true;
	}
	
}
public abstract class Awapon
{
    public float delay = 0;
    public float damage = 0;
    public float range = 0;
    public string type = "LONG";

}
public class Sword : Awapon
{
    public Sword()
    {
        type = "SHORT";
    }
}
public class Gun : Awapon
{
    public Gun()
    {
        delay = 1f;
        damage = 1000f;
        range = 5f;
        type = "LONG";
    }

}
public class MachineGun : Awapon
{
    public MachineGun()
    {
        delay = 0.2f;
        damage = 5f;
        range = 1f;
        type = "LONG";
    }

}
public class IceGun : Awapon
{
    public IceGun()
    {
        delay = 0.2f;
        damage = 5f;
        range = 3f;
        type = "LONG";
    }

}
public class ShotGun : Awapon
{
    public ShotGun()
    {
        delay = 3f;
        damage = 50f;
        range = 1f;
        type = "LONG";
    }

}