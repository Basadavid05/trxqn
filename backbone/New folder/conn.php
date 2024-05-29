<?php
$con = new mysqli("localhost", "root", "", "tagdij");
if($con->errno){
    die("Nincs adatbazis!");
}
$con->set_charset("utf8mb4");
?>