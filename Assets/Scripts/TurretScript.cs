using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform firePoint;
    public float laserDist;
    public GameObject laser;
    private bool canShoot = true;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot)
            WaitForShoot();
        Debug.DrawRay(firePoint.position, firePoint.TransformDirection(Vector2.left) * laserDist, Color.green);
    }

    void WaitForShoot()
    {
        RaycastHit2D detect = Physics2D.Raycast(firePoint.position, firePoint.TransformDirection(Vector2.left),laserDist,LayerMask.GetMask("Player"));
        if (detect)
        {
            //activate the getting ready to shoot animation
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        anim.SetBool("fire", true);
        yield return new WaitForSeconds(1.48f);
        anim.SetBool("fire", false);
        RaycastHit2D detect = Physics2D.Raycast(firePoint.position, firePoint.TransformDirection(Vector2.left), laserDist, LayerMask.GetMask("Player"));
        
        GameObject laserInstance = Instantiate(laser, firePoint.position, laser.transform.rotation);
        laserInstance.transform.localScale = new Vector3(detect.distance*100+75,30,1);
        laserInstance.transform.position -= new Vector3(detect.distance /2+0.375f, 0, 0);
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(5f);
        canShoot = true;
    }
}
