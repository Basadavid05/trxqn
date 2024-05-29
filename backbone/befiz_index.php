<?php

header('Content-Type: application/json; charset=utf-8');
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Headers: *");

    $conn = new mysqli("localhost","root","","tagdij");
    
    if($conn->errno){
        echo json_encode(array("hiba"=>"ismeretlenhiba")); 
        die();
    }

    
    $server=filter_input(INPUT_SERVER, "QUERY_STRING");
    $req= explode("/", $server);
    
switch ($req[0]) 
{
    case "befiz":{
        
            switch (filter_input(INPUT_SERVER, "REQUEST_METHOD")){
                
                case "GET": 
                    
                    $sql="Select * from befiz";
                    
                    $result= $conn->query($sql);
                    
                    if($result){
                                    
                        http_response_code(201);
                        
                        $befiz=$result->fetch_all(MYSQLI_ASSOC);
                        
                        echo json_encode($befiz);
                    }
                    else{
                        http_response_code(401);
                        echo json_encode(array("hiba"=>"ismeretlenhiba")); 
                    }
                    
                    break;

                
                case "POST":{
                    $datum= filter_input(INPUT_POST, "datum");
                    $osszeg= filter_input(INPUT_POST, "osszeg");
                    
                    $sqli="INSERT INTO `befiz`(`azon`, `datum`, `osszeg`) VALUES (null,?,?)";
                    
                    $stmt=$conn->prepare($sqli);
                    
                    $stmt->bind_param("ii",$datum,$osszeg);
                    
                    if($stmt->execute()==true){
                        http_response_code(201);
                        echo 'Updated';
                    }
                    else{
                        http_response_code(401);
                        echo 'Failed';
                    }
                    
                    break;

                }
                default : break;
            }
        
            break;
        }
         default : http_response_code(401);
            break;
}

            
           
