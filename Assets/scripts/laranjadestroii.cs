using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class laranjadestroii : MonoBehaviour
{
    private SpriteRenderer sprite;
    private CircleCollider2D circulo;
    public GameObject coletar;
    public int contador;
    void Start()
    {
        sprite= GetComponent<SpriteRenderer>();
        circulo= GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.gameObject.tag == "Player")
        {
            sprite.enabled= false;
            circulo.enabled= false;
            coletar.SetActive(true);
            Controle.instancia.pontuacao += contador;
            Controle.instancia.atualizarPontuacao();
            Destroy(gameObject, 0.3f);
        }
    }
}
