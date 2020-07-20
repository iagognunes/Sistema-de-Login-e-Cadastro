using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CadastroUser : MonoBehaviour
{
    public InputField campoNome;
    public InputField campoEmail;
    public InputField campoCPF;
    public InputField campoTelefone;
    public InputField campoSenha;
    public Text feedbackmsg;


    public Button botaoEnivar;

    public void ChamarRegistro()
    {
      if (campoNome.text=="" || campoEmail.text == "" || campoCPF.text == "" || campoTelefone.text == "" || campoSenha.text == ""){
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

        form.AddField("Nome", campoNome.text);
        form.AddField("Email", campoEmail.text);
        form.AddField("CPF", campoCPF.text);
        form.AddField("Telefone", campoTelefone.text);
        form.AddField("Senha", campoSenha.text);
        WWW www = new WWW("https://jambug.000webhostapp.com/TesteLogin/Registro.php", form);
        yield return www;
        if (www.text == "0")
        {
          FeedBackOk("Registro efetuado com sucesso!");
          Debug.Log("Registro criado com sucesso!");
          yield return new WaitForSeconds(1);
          SceneManager.LoadScene("CenaInicial");
        }
        else
        {
          FeedBackError("Registro falhou!");
          if(www.text == "3: Usuario ja existe!")
          {
            FeedBackError("O Usuário Ja Existe!");
          }
          Debug.Log("Registro falhou! Erro #" + www.text);
        }
    }

    public void VerifyInputs()
    {
      botaoEnivar.interactable = (campoNome.text.Length >= 4 && campoEmail.text.Length >= 9 && campoCPF.text.Length == 11 && campoTelefone.text.Length >= 9 && campoSenha.text.Length >= 4);
      // if(campoNome.text.Length < 4)
      // {
      //   FeedBackError("Nome menor que 4 caracteres! Digite o Nome Completo.");
      // }
      //
      // if(campoEmail.text.Length < 9)
      // {
      //   FeedBackError("Nome menor que 9 caracteres!");
      // }
      //
      // if(campoCPF.text.Length != 11)
      // {
      //   FeedBackError("Digite um CPF válido! (11 caracteres)");
      // }
      //
      // if(campoTelefone.text.Length < 9)
      // {
      //   FeedBackError("Telefone menor que 9 caracteres!");
      // }
      //
      // if(campoSenha.text.Length < 4)
      // {
      //   FeedBackError("Digite uma senha maior.");
      // }
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
      campoNome.text = "";
      campoEmail.text = "";
      campoCPF.text = "";
      campoTelefone.text = "";
      campoSenha.text = "";

    }

}
