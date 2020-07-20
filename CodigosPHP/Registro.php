<?php
  require_once("conexao.php");

  if(mysqli_connect_error())
  {
    echo "1: Conexão falhou!"; //error 1 = conexao falhou
    exit();
  }

  $nome = $_POST["Nome"];
  $email = $_POST["Email"];
  $cpf = $_POST["CPF"];
  $telefone = $_POST["Telefone"];
  $senha = $_POST["Senha"];
  $senha = md5($senha);

  //checar se o user ja existe
  $checagemUser ="SELECT CPF FROM users WHERE Email='". $email ."';";

  $checagemQuery = mysqli_query($conn, $checagemUser) or die("2: Checagem falhou!");//error 2 = checagem de email

  if(mysqli_num_rows($checagemQuery) > 0)
  {
    echo "3: Usuario ja existe!";
    exit();
  }

  //adicionando ao banco
  $inserirUser = "INSERT INTO users (Nome, Email, CPF, Telefone, Senha) VALUES ('" . $nome ."','" . $email ."','" . $cpf ."','" . $telefone ."','" . $senha ."');";

  mysqli_query($conn, $inserirUser) or die("4: Inserção falhou!");

  echo("0");

  mysqli_close($conn);
?>
