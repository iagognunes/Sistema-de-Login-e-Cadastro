using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CadastroProduto : MonoBehaviour
{
      public InputField campoNomeProd;
      public InputField campoCodProd;
      public InputField campoQtdProd;
      public InputField campoPrecoProd;
      public Text feedbackmsg;


      public Button botaoEnivar;

      public void ChamarRegistro()
      {
        if (campoNomeProd.text=="" || campoCodProd.text == "" || campoQtdProd.text == "" || campoPrecoProd.text == ""){
          FeedBackError("Preencha todos os campos!");
        } else{
          StartCoroutine(Registro());
        }
      }

      IEnumerator Registro()
      {
          WWWForm form = new WWWForm();

          //CPFint = int.Parse(campoCPF.text);
          //TELint = int.Parse(campoTelefone.text);

          form.AddField("Cod_Produto", campoCodProd.text);
          form.AddField("Nome_Produto", campoNomeProd.text);
          form.AddField("Qtd_Produto", campoQtdProd.text);
          form.AddField("Preco_Produto", campoPrecoProd.text);
          form.AddField("Usuario", PlayerPrefs.GetString("EmailLogado"));
          Debug.Log(PlayerPrefs.GetString("EmailLogado"));
          WWW www = new WWW("https://jambug.000webhostapp.com/TesteLogin/RegistroProd.php", form);
          yield return www;
          if (www.text == "0")
          {
            FeedBackOk("Registro efetuado com sucesso!");
            Debug.Log("Registro criado com sucesso!");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Dados");
          }
          else
          {
            FeedBackError("Registro falhou!");
            if(www.text == "Código de produto ja cadastrado!")
            {
              FeedBackError("O Código de produto ja foi   cadastrado!");
            }
            Debug.Log("Registro falhou! Erro #" + www.text);
          }
      }


      void FeedBackOk (string mensagem){
        feedbackmsg.CrossFadeAlpha(100f, 0f, false);
        feedbackmsg.color = Color.green;
        feedbackmsg.text = mensagem;
      }

      void FeedBackError(string mensagem){
        feedbackmsg.CrossFadeAlpha(100f, 0f, false);
        feedbackmsg.color = Color.red;
        feedbackmsg.text = mensagem;
        feedbackmsg.CrossFadeAlpha(0f, 2f, false);
        campoCodProd.text = "";
        campoNomeProd.text = "";
        campoQtdProd.text = "";
        campoPrecoProd.text = "";

      }

  }
