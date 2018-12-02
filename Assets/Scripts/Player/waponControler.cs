using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waponControler : MonoBehaviour {
    public float timeSinceLastShoot = 0;
    Awapon wapon;
    void Start () 
    {
        wapon = new Gun();

	}
	void Update () {
        if (Input.GetButton("Weapon"))
        {
            wapon = new MachineGun();
        }
        if (wapon.type=="LONG")
        {
            timeSinceLastShoot += Time.deltaTime;
            if (timeSinceLastShoot > wapon.delay)
            {
                if (Input.GetButton("Fire1"))
                {
                    Vector3 mouseworldpose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    float AngleRad = Mathf.Atan2(mouseworldpose.y - transform.position.y, mouseworldpose.x - transform.position.x);
                    float AngleDeg = (180 / Mathf.PI) * AngleRad;
                    GameObject instance = Object.Instantiate(Resources.Load("bullet", typeof(GameObject)), new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, 0, AngleDeg)) as GameObject;
                    instance.GetComponent<bulletControler>().damage = wapon.damage;
                    Destroy(instance, wapon.range);
                    timeSinceLastShoot = 0;
                }
            }
        }
    }
}
public abstract class Awapon
{

    protected waponControler _controller;
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
        delay = 1;
        damage = 10;
        range = 1;
        type = "LONG";
    }

}
public class MachineGun : Awapon
{
    public MachineGun()
    {
        delay = 0.2f;
        damage = 5;
        range = 2;
        type = "LONG";
    }

}
public class IceGun : Awapon
{
    public IceGun()
    {
        delay = 0.2f;
        damage = 5;
        range = 3;
        type = "LONG";
    }

}
public class ShotGun : Awapon
{
    public ShotGun()
    {
        delay = 3f;
        damage = 50;
        range = 1;
        type = "LONG";
    }

}