using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    public float velocidade = 400;
    public Rigidbody2D rb;
    public Transform raquete;

    GameManager gm;

    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        if (!gm.inPlay) {
            transform.position = raquete.position;
            rb.velocity = Vector2.zero;
        }

        if(Input.GetKeyDown(KeyCode.Space) && !gm.inPlay) {
            gm.inPlay = true;
            rb.AddForce (Vector2.up * velocidade);
        }
    }

    private void FinishGame()
    {
        gm.vidas--;

        if(gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("bottom"))
        {
            rb.velocity = Vector2.zero;
            gm.inPlay = false;
            FinishGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Tijolo"))
        {
            gm.pontos++;
        }
    }

}
