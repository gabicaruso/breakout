using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    public Sprite[] blocos;
    public SpriteRenderer spriteRenderer;
    public int resistencia;
    public AudioSource som;

    void Start() {
        som = GetComponent<AudioSource>();
        resistencia = (int)Random.Range(0,3);
        spriteRenderer.sprite = blocos[resistencia];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        resistencia--;
        som.Play();
        if (resistencia < 0) {
            Destroy(this.gameObject, som.clip.length);
        } else {
            spriteRenderer.sprite = blocos[resistencia];
        }
    }
}
