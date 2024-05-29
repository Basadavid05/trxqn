document.addEventListener('DOMContentLoaded',()=>{
    console.log("loaded");
    const link="http://localhost/api/index.php?levesek";
    const place=document.getElementById("valami");


    async function GetAll(){
        let result=await fetch(link);
        let levesek=await result.json();
        CustomFunction(levesek); 
    }

    function CustomFunction(leves){

        place.innerHTML=" ";
        let datas="";

        // Creating the table header with 7 columns
        datas += '<table>';
        // Looping through the leves array and creating table rows dynamically
        leves.forEach(element => {
            datas += `<tr>
                <td>${element.megnevezes}</td>
                <td>${element.kaloria}</td>
                <td>${element.feherje}</td>
                <td>${element.zsir}</td>
                <td>${element.szenhidrat}</td>
                <td>${element.hamu}</td>
                <td>${element.rost}</td>
            </tr>`;
        });

        datas += '</table>';

        // Adding the generated table to the innerHTML of the place element
        place.innerHTML = datas;
    }

        GetAll();
});

/*
     //'<td>' + element.megnevezes + '</td>' +

*/