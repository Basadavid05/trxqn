<?php
require_once "./conn.php";
switch($_SERVER["REQUEST_METHOD"]){
    case "GET":
        $response = $con->query("SELECT * FROM `befiz`");
        $befizet = [];
        while($row = mysqli_fetch_array($response)){
            $befizet[] = array(
                "azon" => $row["azon"],
                "datum" => $row["datum"] ,
                "osszeg" => $row["osszeg"] 
            );
        }
        http_response_code(200);
        echo json_encode($befizet);
        break;
    
    case "POST":
        $azon = $_POST["azon"];
        $datum = $_POST["datum"];
        $osszeg = $_POST["osszeg"];
        $sql = "INSERT INTO `befiz`(`azon`, `datum`, `osszeg`) VALUES (?,?,?)";
        $stmt = $con->prepare($sql);
        $stmt->bind_param("isi", $azon, $datum, $osszeg);
        $stmt->execute();
        http_response_code(200);
        header("Location: index.html");
        break;
}
?>