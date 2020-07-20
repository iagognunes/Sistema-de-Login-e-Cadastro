using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena : MonoBehaviour
{

    public void CenaLogin(){
        SceneManager.LoadScene("CenaLogin");
    }

    public void CenaRegistro(){
        SceneManager.LoadScene("Registro");
    }

    public void CenaInicial(){
      PlayerPrefs.DeleteKey("EmailLogado");
        SceneManager.LoadScene("CenaInicial");
    }

    public void CenaDados(){
        SceneManager.LoadScene("Dados");
    }

    public void sair(){
      PlayerPrefs.DeleteKey("EmailLogado");
      Application.Quit();
      Debug.Log("Saiu");
    }

    public void CadastrarProd(){
      SceneManager.LoadScene("AddProd");
    }

    public void MostrarProd(){
      SceneManager.LoadScene("MostraProd");
    }

}
