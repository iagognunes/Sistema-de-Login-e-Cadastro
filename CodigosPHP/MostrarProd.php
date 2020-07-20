<?php
  require_once("conexao.php");

  $emailUser = $_GET['Usuario'];


  $email = mysqli_real_escape_string($conn, $emailUser);


    $sql = "SELECT * FROM Produto WHERE Usuario = '$email'";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
       // echo "Nome: " . $row["Nome"]. " - Email: " . $row["Email"]. " - CPF: " . $row["CPF"]. " - Telefone: " . $row['Telefone'] . "<br>";
        $CodProd = $row['Cod_Produto'];
        $NomeProd = $row['Nome_Produto'];
        $QtdProd = $row['Qtd_Produto'];
        $PrecoProd = $row['Preco_Produto'];
        $Usuario = $row['Usuario'];

        /*echo $row['Cod_Produto'].'*';
        echo $row['Nome_Produto'].'*';
        echo $row['Qtd_Produto'].'*';
        echo $row['Preco_Produto'].'*';
        echo $row['Usuario'].'*';*/

        #Arrays
        $Cod[] = $CodProd;
        $Nome[] = $NomeProd;
        $Qtd[] = $QtdProd;
        $Preco[] = $PrecoProd;
    }
    #Variavel para saber o tamanho do array
    $tamanho = count($Cod);
    
    #Mostrar os conteudos dos arrays
    echo "Usuário logado: " . $Usuario . "\n";
    echo "\n";
    
    echo "Codigos: \n";
    for($i=0; $i<$tamanho;$i++){
      echo $Cod[$i] . "\n";
    }
    
    echo "\n";
    
    echo "Nomes: \n";
    for($i=0; $i<$tamanho;$i++){
      echo $Nome[$i] . "\n";
    }
    
    echo "\n";
    
    echo "Quantidades: \n";
    for($i=0; $i<$tamanho;$i++){
      echo $Qtd[$i] . "\n";
    }
    
    echo "\n";
    
    echo "Preços: \n";
    for($i=0; $i<$tamanho;$i++){
      echo $Preco[$i] . "\n";
    }
    
    } else {
        echo "0 results";
    }
    


$result->free();
  mysqli_close($conn);
?>
