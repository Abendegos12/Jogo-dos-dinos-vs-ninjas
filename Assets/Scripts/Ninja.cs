﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    public float velocidade;
    public float tempoPulo;
    private float tempoPulado;
    private Vector3 posicaoInicial;
    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            Vector3 pos = this.transform.position;
            //pos.x = pos.x + velocidade;
            pos.x += velocidade;
            this.transform.position = pos;
        }
        if(Input.GetKey(KeyCode.A))
        {
            Vector3 pos = this.transform.position;
            //pos.x = pos.x - velocidade;
            pos.x -= velocidade;
            this.transform.position = pos;
        }
        if(Input.GetKey(KeyCode.W) && tempoPulado <= 0)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 forca = new Vector2(0f, 10f);
            rb.AddForce(forca, ForceMode2D.Impulse);
            tempoPulado = tempoPulo;       
        }
        //Debug.Log(Time.deltaTime);
        tempoPulado -= Time.deltaTime;

        if(this.transform.position.y < -14f)
        {
            this.transform.position = posicaoInicial;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "cacto")
        {
            this.transform.position = posicaoInicial;
        }
    }
}