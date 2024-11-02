using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_enemy : MonoBehaviour
{
    private float speed = 2.0f;
    private float limitRigth = 9.80f;
    private float limitLeft = -9.80f;
    private Vector2 currentDirection = Vector2.right;
    private int health = 3;
    void Update(){
        transform.Translate(currentDirection * speed * Time.deltaTime);
        if(transform.position.x >= limitRigth){
            currentDirection = Vector2.left;
        }
        if(transform.position.x <= limitLeft){
            currentDirection = Vector2.right;
        }
    }
    public void vida(){
        health = health - 1;
        if(health == 0){
            Destroy(gameObject);
        }
    }
}