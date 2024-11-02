using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class movment : MonoBehaviour
{
    private float lastprefabs;
    public GameObject bulletPrefab;
    public float speed;
    private float jumpforce = 5;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            subir();
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            bajar();
        }
        else{
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, 0);
        }

        if(Input.GetKey(KeyCode.Space) && Time.time > lastprefabs + 0.25f){
            disparo();
            lastprefabs = Time.time;
        }
    }
    private void subir(){
        Rigidbody2D.AddForce(Vector2.up * jumpforce);
    }

    private void bajar(){
        Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, -speed); // Asigna velocidad vertical negativa
    }
    private void FixedUpdate(){
        if (Horizontal != 0){
            Rigidbody2D.velocity = new Vector2(Horizontal *speed , Rigidbody2D.velocity.y);
        }
        Rigidbody2D.position = new Vector2(Rigidbody2D.position.x, Mathf.Clamp(Rigidbody2D.position.y,-3.46f , 3.46f));
    }
    private void disparo(){
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        
        // Configura la dirección de la bala hacia arriba
        bullet.GetComponent<bullet>().Setdirection(Vector2.up);
    }
}