<?php 

header('Content-Type: application/json; charset=utf-8');
header('Access-Control-Allow-Origin: *');
header("Access-Control-Allow-Headers: *");

$conn = new mysqli("localhost", "root", "","levesek");


if ($conn->connect_error) {
  echo json_encode(array("hiba"=>"ismeretlenhiba"));   
  die();
}

$linker=filter_input(INPUT_SERVER,"QUERY_STRING");
$origin= explode("?", $linker);
switch ($origin[0])
{
    case "levesek":
         http_response_code(201);
         switch (filter_input(INPUT_SERVER, "REQUEST_METHOD")){
            case "GET":
                $selecter="select * from levesek";
                $result = $conn->query($selecter);
                if($result){
                    http_response_code(201);
                    $levesek=$result->fetch_all(MYSQLI_ASSOC);
                    echo json_encode($levesek);
                }
                break;

            case "POST":
                    
                $name= filter_input(INPUT_POST, "name");
                $kaloria= filter_input(INPUT_POST, "kaloria");
                $feher= filter_input(INPUT_POST, "feher");
                $zsir= filter_input(INPUT_POST, "zsir");
                $szen=filter_input(INPUT_POST, "szen");
                $hamu=filter_input(INPUT_POST, "hamu");
                $rost=filter_input(INPUT_POST, "rost");
                
                $sql="INSERT INTO `levesek`(`megnevezes`, `kaloria`, `feherje`, `zsir`, `szenhidrat`, `hamu`, `rost`) VALUES (?,?,?,?,?,?,?)";
                $stmt=$conn->prepare($sql);
                
                $stmt->bind_param("siddddd", $name,$kaloria,$feher,$zsir,$szen,$hamu,$rost);
                
                if($stmt->execute()==true){
                    http_response_code(201);
                    echo 'Uploaded';
                    break;
                }
                else{
                    http_response_code(401);
                    echo 'Failed';
                    break;
                }
                break;

         }
         
        break;
    
    default : 
        echo '<a href="http://localhost/index.php?levesek">levesek</a>';
        break;
    
}