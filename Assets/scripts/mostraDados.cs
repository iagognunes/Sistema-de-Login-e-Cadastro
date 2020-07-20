using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mostraDados : MonoBehaviour
{

  [SerializeField]
  private Text feedbackmsg = null;

  string TestoBanco;

  private string url ="https://jambug.000webhostapp.com/TesteLogin/MostrarDados.php";

    void Start()
    {
      string email = PlayerPrefs.GetString("EmailLogado");
      WWW www = new WWW (url + "?Email="+ email);
      StartCoroutine(ShowData(www));
    }

    IEnumerator ShowData(WWW www){
      yield return www;
      if (www.error != null) {
          print(www.error);
        } else{
          TestoBanco = www.text; //here we return the data our PHP told us

          feedback(TestoBanco);
        }

    }

    void feedback (string mensagem1){
      feedbackmsg.CrossFadeAlpha(100f, 0f, false);
      feedbackmsg.color = Color.black;
      feedbackmsg.text = mensagem1;
    }



}
