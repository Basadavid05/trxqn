document.addEventListener("DOMContentLoaded", () => {
    const apiURL = "http://localhost/dolgozok/index.php?dolgozok";
    const dolgozokLista = document.getElementById("dolgozok-lista");
    const dolgozokTabla = document.getElementById("dolgozok-table");
    const hozzaad = document.getElementById("hozzaad");
    const nevInput = document.getElementById("nev");
    const nemeInput = document.getElementById("neme");
    const reszlegInput = document.getElementById("reszleg");
    const belepesevInput = document.getElementById("belepesev");
    const berInput = document.getElementById("ber");


    async function getallDolgozo(){
        let result = await fetch(apiURL);
        let dolgoz = await result.json();
        showCard(dolgoz);
        dolgozokTablaFriss(dolgoz);
    }

    function showCard(dolgozok) 
    {
        dolgozokLista.innerHTML = "";
        let card = "";
        dolgozok.forEach(dolgozo => {
            card += `<div class="card col-lg-2 col-md-3 col-sm-12 m-2">
                    <div class="card-header">${dolgozo.nev}</div>
                    <div class="card-body">
                        <p class="card-text">Neme: ${dolgozo.neme}</p>
                        <p class="card-text">Reszleg: ${dolgozo.reszleg}</p>
                        <p class="card-text">Belepesev: ${dolgozo.belepesev}</p>
                        <p class="card-text">Ber: ${dolgozo.ber}</p>
                    </div>
                </div>`;
        });
        dolgozokLista.innerHTML = card;
    }

    function dolgozoSor(dolgozo){
        let tr = `<tr>
                    <td>${dolgozo.nev}</td>
                    <td>${dolgozo.neme}</td>
                    <td>${dolgozo.reszleg}</td>
                    <td>${dolgozo.belepesev}</td>
                    <td>${dolgozo.ber}</td>
                </tr>`;
            return tr;
    }


    function dolgozokTablaFriss(dolgozok){
        dolgozokTabla.innerHTML = "";
        var table = `<table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col">Nev</th>
                    <th scope="col">Neme</th>
                    <th scope="col">Reszleg</th>
                    <th scope="col">Belepesev</th>
                    <th scope="col">Ber</th>
                </tr>
            </thead>
            <tbody>`;

            dolgozok.forEach(dolgozo =>{
                table += dolgozoSor(dolgozo);
            });
            dolgozokTabla.innerHTML = table + "</tbody></table>";
        }
    getallDolgozo();


//new
    
    hozzaad.addEventListener('click', addDolgozo);
    async function addDolgozo(){
        const nev = nevInput.value;
        const neme = nemeInput.value;
        const reszleg = reszlegInput.value;
        const belepesev = belepesevInput.value;
        const ber = berInput.value;

        try{
            const response = await fetch(apiURL, {
                method: "POST",
                headers: {'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                nev: nev,
                neme: neme,
                reszleg: reszleg,
                belepesev: belepesev,
                ber: ber
            })
        });
        if(response.ok){
            const newDolgozo = await response.json();
            console.log("Sikeres adatbevitel!", newDolgozo);
            await getallDolgozo();
        }
        else{
            console.error("Hiba történt!")
        }
        }catch(error){
            console.error('Hiba történt!', error);

        }
    }
});