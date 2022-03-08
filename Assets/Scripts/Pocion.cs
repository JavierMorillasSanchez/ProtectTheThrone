using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion : MonoBehaviour
{
    public bool curativa;
    public int cura;
    public bool mejora;
    public int mejorar;

    public AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (curativa)
            {
                if (Player.instance.vida < Player.instance.vidaMax)
                {
                    Player.instance.vida += 10;
                    if (Player.instance.vida > Player.instance.vidaMax)
                        Player.instance.vida = Player.instance.vidaMax;
                    SoundManager.instance.SoundPlay(SoundManager.instance.source, clip);
                    Destroy(this.gameObject);
                }
            }
            else if (mejora)
            {
                Player.instance.fuerza += 2;
                Player.instance.defensa += 2;
                SoundManager.instance.SoundPlay(SoundManager.instance.source, clip);
                Destroy(this.gameObject);
            }
        }
    }
}
