using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRaquete : MonoBehaviour
{
    [Range(1, 10)]
    public float velocidade = 6.5f;

    public float bordaEsq;
    public float bordaDir;
    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        float inputX = Input.GetAxis("Horizontal");

        transform.Translate (Vector2.right * inputX * Time.deltaTime * velocidade); 

        if (transform.position.x < bordaEsq){
            transform.position = new Vector2 (bordaEsq, transform.position.y);
        }
        if (transform.position.x > bordaDir){
            transform.position = new Vector2 (bordaDir, transform.position.y);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            Time.timeScale = 0f;
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
    }
}
