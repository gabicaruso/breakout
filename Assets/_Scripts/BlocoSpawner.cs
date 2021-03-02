using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{
    public GameObject Bloco;
    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
        Construir();
    }

    public void Construir()
    {
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
        for(int i = 0; i < 12; i++)
        {
            for(int j = 0; j < 3; j++){
                Vector3 posicao = new Vector3(-7.7f + 1.4f * i, 4 - 0.8f * j);

                Instantiate(Bloco, posicao, Quaternion.identity, transform);
            }
        }
    }

    void Update()
    {
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }
}
