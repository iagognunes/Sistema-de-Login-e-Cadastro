<?php
  require_once("conexao.php");

  if(mysqli_connect_error())
  {
    echo "1: Conexão falhou!"; //error 1 = conexao falhou
    exit();
  }

  $CodProd = $_POST["Cod_Produto"];
  $NomeProd = $_POST["Nome_Produto"];
  $QtdProd = $_POST["Qtd_Produto"];
  $PrecoProd = $_POST["Preco_Produto"];
  $Usuario = $_POST["Usuario"];

  $ChecagemProd = "SELECT * FROM Produto WHERE Cod_Produto ='". $CodProd ."';";
  $ChecandoQuery = mysqli_query($conn, $ChecagemProd) or die("2: Checagem falhou!");

  if(mysqli_num_rows($ChecandoQuery) > 0)
  {
    echo "Código de produto ja cadastrado!";
    exit();
  }

  //adicionando ao banco
  $inserirProd = "INSERT INTO Produto (Cod_Produto, Nome_Produto, Qtd_Produto, Preco_Produto, Usuario) VALUES ('" . $CodProd ."','" . $NomeProd ."','" . $QtdProd ."','" . $PrecoProd ."','" . $Usuario ."');";

  mysqli_query($conn, $inserirProd) or die("4: Inserção falhou!");

  echo("0");

  mysqli_close($conn);
?>
