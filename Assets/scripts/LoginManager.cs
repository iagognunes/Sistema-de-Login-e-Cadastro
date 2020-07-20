using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{

  [SerializeField]
  private InputField usuarioField = null;
  [SerializeField]
  private InputField senhaField = null;
  [SerializeField]
  private Text feedbackmsg = null;

  private string url ="https://jambug.000webhostapp.com/TesteLogin/loginTeste.php";

    public void FazerLogin()
    {
      if (usuarioField.text=="" || senhaField.text == ""){
        FeedBackError("Preencha todos os campos!");
      } else{
      string usuario = usuarioField.text;
      string senha = senhaField.text;

      PlayerPrefs.SetString("EmailLogado", usuario );

      WWW www = new WWW (url + "?login="+ usuario + "&senha=" + senha);
      StartCoroutine(ValidaLogin(www));
      }
    }
    IEnumerator ValidaLogin(WWW www){
      yield return www;
      if (www.error == null) {
        if(www.text == "1"){
          FeedBackOk("Login realizado com sucesso");
          StartCoroutine(CarregaScene());
        } else{
          FeedBackError("Usuário ou senha inválidos");
        }
      } else {
        if(www.error == "coulndn't connect to host"){
          FeedBackError("Servidor indisponível");
        }
      }
    }

    IEnumerator CarregaScene(){
      yield return new WaitForSeconds(1);
      SceneManager.LoadScene("Dados");
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
      usuarioField.text = "";
      senhaField.text = "";
    }
}
