using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controle : MonoBehaviour
{
    public int pontuacao;
    public Text textoPontuacao;

    public GameObject gameover;

    public static Controle instancia;
    void Start()
    {
        instancia = this;
    }
    public void atualizarPontuacao()
    {
          textoPontuacao.text = pontuacao.ToString();
    }

    public void GameOver()
    {
        gameover.SetActive(true);
    }

    public void Reiniciar(string level)
    {
        SceneManager.LoadScene(level);
    }
}
