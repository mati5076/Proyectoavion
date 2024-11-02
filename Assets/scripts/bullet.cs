using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bullet : MonoBehaviour
{
    private Vector2 Direction;
    public float speed;
    private Rigidbody2D Rigidbody2D;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        Rigidbody2D.velocity = Direction * speed;
    }

    public void Setdirection(Vector2 direction){
        Direction = direction;
    }
    public void Destroyed(){
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision){
        movement_enemy enemy = collision.collider.GetComponent<movement_enemy>();

        if(enemy != null){
            enemy.vida();
        }
    }
}