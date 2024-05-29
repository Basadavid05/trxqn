<?php
header("Content-type: application/json; charset=utf-8");
//$_SERVER["REQUEST_METHOD"]
$keresSzoveg = $_SERVER["QUERY_STRING"];
$keresek = explode('/', $keresSzoveg); 
switch ($keresek[0]) {
    case "ugyfelek":
        require_once './ugyfelek.php';
        break;
    case "befizetes":
        require_once './befizetes.php';
        break;
    default:
        http_response_code(404);
        break;
}
?>
