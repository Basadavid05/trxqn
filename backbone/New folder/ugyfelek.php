<?php
require_once "./conn.php";
switch($_SERVER["REQUEST_METHOD"]){
    case "GET":
        $response = $con->query("SELECT * FROM `ugyfel`");
        $ugyfelek = [];
        while($row = mysqli_fetch_array($response)){
            $ugyfelek[] = array(
                "azon" => $row["azon"],
                "nev" => $row["nev"] ,
                "szuldatum" => $row["szuldatum"] ,
                "irszam" => $row["irszam"] ,
                "orsz" => $row["orsz"] 
            );
        }
        http_response_code(200);
        echo json_encode($ugyfelek);
        break;
    
    case "POST":
        $azon = $_POST["azon"];
        $nev = $_POST["nev"];
        $szuldatum = $_POST["szuldatum"];
        $irszam = $_POST["irszam"];
        $orsz = $_POST["orsz"];
        $sql = "INSERT INTO `ugyfel`(`azon`, `nev`, `szuldatum`, `irszam`, `orsz`) VALUES (?,?,?,?,?);";
        $stmt = $con->prepare($sql);
        $stmt->bind_param("issis", $azon, $nev, $szuldatum, $irszam, $orsz);
        $stmt->execute();
        http_response_code(200);
        header("Location: index.html");
        break;

    case "PUT":
        $input = json_decode(file_get_contents('php://input'), true);
        $nev = $input["nev"];
        $szuldatum = $input["szuldatum"];
        $irszam = $input["irszam"];
        $orsz = $input["orsz"];
        $sql = "UPDATE `ugyfel` SET `nev`= ?,`szuldatum`= ?,`irszam`= ?,`orsz`= ? WHERE `azon` = ?";
        $stmt = $mysqli->prepare($sql);
        $stmt->bind_param("ssisi", $nev, $szuldatum, $irszam, $orsz, $azon);
        $stmt->execute();
        http_response_code(200);
        break;
}
?>