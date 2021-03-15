using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public int damage = 40;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;

    public Image reload;
    public Image reloading;

    int shotCounter = 0;
    bool isShooting = true;

    void Start() {
        PlayCoronavirusHa();
    }

    void PlayCoronavirusHa() {
        FindObjectOfType<AudioManager>().Play("Ha");
        
        Invoke("PlayCoronavirusHa", 60f);
    }

    public void ShotAction() {
        if (isShooting) {
            StartCoroutine(Shot());
        }
    }

    IEnumerator Shot() {
        //Play effect
        FindObjectOfType<AudioManager>().Play("Laser");

        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo) {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

            if (enemy != null) {
                enemy.TakeDamage(damage);
            }    

            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
            
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        } else {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;

        shotCounter += 1;

        if (shotCounter % 32 == 0) {
            isShooting = false;
            reload.enabled = true;
            reloading.enabled = true;
            FindObjectOfType<AudioManager>().Play("Reloading");

            Invoke("EnableShot", 3f);
        }
    }

    void EnableShot() {
        isShooting = true;
        reload.enabled = false;
        reloading.enabled = false;
    }
}
