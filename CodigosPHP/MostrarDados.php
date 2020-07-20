<?php
  require_once("conexao.php");

  $emailUser = $_GET['Email'];


  $email = mysqli_real_escape_string($conn, $emailUser);


    $sql = "SELECT * FROM users WHERE Email = '$email'";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
       // echo "Nome: " . $row["Nome"]. " - Email: " . $row["Email"]. " - CPF: " . $row["CPF"]. " - Telefone: " . $row['Telefone'] . "<br>";
        $Nome = $row['Nome'];
        $Email = $row['Email'];
        $Cpf = $row['CPF'];
        $Telefone = $row['Telefone'];

        /*echo $row['Nome'].'*';
        echo $row['Email'].'*';
        echo $row['CPF'].'*';
        echo $row['Telefone'].'*';
        */
    }
    echo "Nome: " . $Nome . "\n";
    echo "\n";

    echo "Email: " . $Email . "\n";
    echo "\n";

    echo "CPF: " . $Cpf . "\n";
    echo "\n";

    echo "Telefone: " . $Telefone . "\n";
    echo "\n";


    } else {
        echo "0 results";
    }



$result->free();
  mysqli_close($conn);
?>
