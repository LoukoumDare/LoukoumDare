using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waponControler : MonoBehaviour {

    Awapon wapon;
    void Start () 
    {
        wapon = new Gun(this);

	}
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            wapon.Fire();
        }
    }
}
public abstract class Awapon
{
   protected waponControler _controller;

    public Awapon(waponControler _controller)
    {
        this._controller = _controller;
    }

    public virtual void Fire()
    {

    }
}
public class Sword : Awapon
{
    public Sword(waponControler _controller)
    : base(_controller)
    {
    }
    public override void Fire ()
    {

    }
}
public class Gun : Awapon
{
    public Gun(waponControler _controller)
    : base(_controller)
    {
    }

    public override void Fire()
    {
        Vector3 mouseworldpose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float AngleRad = Mathf.Atan2(mouseworldpose.y - _controller.transform.position.y, mouseworldpose.x - _controller.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        //this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        GameObject instance = Object.Instantiate(Resources.Load("bullet", typeof(GameObject)), new Vector3(_controller.transform.position.x, _controller.transform.position.y, 0), Quaternion.Euler(0, 0, AngleDeg)) as GameObject;
    }
}