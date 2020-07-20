using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MostrarProd : MonoBehaviour
{
    [SerializeField]
    private Text feedbackmsg = null;

    string TestoBanco;
    string stringToEdit;
    string CodProd;
    string NomeProd;
    string QtdProd;
    string PrecoProd;
    string Usuario;

    private string url ="https://jambug.000webhostapp.com/TesteLogin/MostrarProd.php";

      void Start()
      {
        string email = PlayerPrefs.GetString("EmailLogado");
        WWW www = new WWW (url + "?Usuario="+ email);
        StartCoroutine(ShowData(www));
      }

      IEnumerator ShowData(WWW www){
        yield return www;
        if (www.error != null) {
            print(www.error);
          } else{
            TestoBanco = www.text; //here we return the data our PHP told us

            if(TestoBanco == "0 results"){
              feedBackBanco("O usuário nao cadastrou nenhum produto!");
            }
            else{
            TestoEco(TestoBanco);
            }
          }

      }

      void feedBackBanco (string feedback){
        feedbackmsg.CrossFadeAlpha(100f, 0f, false);
        feedbackmsg.color = Color.red;
        feedbackmsg.text =  feedback;
      }

      void TestoEco (string feedback){
        feedbackmsg.CrossFadeAlpha(100f, 0f, false);
        feedbackmsg.color = Color.black;
        feedbackmsg.text =  feedback;
      }

  }
