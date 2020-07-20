<?php
  require_once("conexao.php");

  $loginUser = $_GET['login'];
  $senhaUser = $_GET['senha'];


  $login = mysqli_real_escape_string($conn, $loginUser);
  $senha = mysqli_real_escape_string($conn, $senhaUser);
  $senha = md5($senha);

  $sql = mysqli_query($conn, "SELECT * FROM users WHERE Email = '$login' AND Senha = '$senha'");

  if($sql){
    $dados = mysqli_num_rows($sql);
    if ($dados == 1) {
      echo '1'; //se retorno = 1, o usuario pode logar
    }else{
      echo '0';
    }
  }

  mysqli_close($conn);
?>