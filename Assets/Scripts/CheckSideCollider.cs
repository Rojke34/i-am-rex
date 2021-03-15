using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSideCollider : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collider)  {
		if (collider.tag == "Rock" || collider.tag == "Coronavirus") {

            //Get the "Enemy" script that is attached to the colliding game object
            EnemyMovement enemyComponent = transform.GetComponent<EnemyMovement>();
         
            //Make sure this component actually exists
            if(enemyComponent == null){
                Debug.Log("No enemy script is attached to the colliding object");
                return;
            }
    
            //Call the component's Hit function
            enemyComponent.CheckTouchLimit();

		} else if (collider.tag == "Player") {
            //Animation splash
            FindObjectOfType<Player>().PlayerTakeDamage(10);
            Destroy(gameObject);
        } 
    
    }
}
