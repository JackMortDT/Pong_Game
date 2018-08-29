using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour {
    public float speed = 30;

	void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
	}

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "RacketLeft"){
            float y = hitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if(collision.gameObject.name == "RacketLeft"){
            float y = hitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    float hitFactor(Vector2 ballPosition, Vector2 racketPosition, float racketHeight){
        return (ballPosition.y - racketPosition.y) / racketHeight;
    }

}
