using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentação : MonoBehaviour
{
    public float forçapula; 
    public float velocidade;
    private Rigidbody2D pula;
    public bool pulando ;
    public bool pulandoDuas;
    public Animator animacao;
    void Start()
    {
        pula = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movimentacao();
        pular();
    }
    void movimentacao()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimento * Time.deltaTime * velocidade;
        if (Input.GetAxis("Horizontal") > 0f)
        {   
            animacao.SetBool("andando", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);

        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            animacao.SetBool("andando", true);
            transform.eulerAngles =  new Vector3(0f, 180f, 0f);
        }
        if (Input.GetAxis("Horizontal") == 0f)
        {
            animacao.SetBool("andando", false);
        }
    }
    void pular()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(pulando == false)
            {
              pula.AddForce(new Vector2(0, forçapula), ForceMode2D.Impulse);
              pulandoDuas = true;
                animacao.SetBool("pulando", true);
            }
            else
            {
                if (pulandoDuas)
                {
                 pula.AddForce(new Vector2(0, forçapula), ForceMode2D.Impulse);
                    pulandoDuas = false;
                }
            }
        }
    }

   void OnCollisionEnter2D (Collision2D colission)
    {
        if (colission.gameObject.layer == 8)
        {
            pulando = false;
            animacao.SetBool("pulando", false);


        }
        if(colission.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
        if (colission.gameObject.tag == "espinhos")
        {
            Controle.instancia.GameOver();
            Destroy(gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D colission)
    {
        if (colission.gameObject.layer == 8)
        {
            pulando = true;

        }
    }
   
}
