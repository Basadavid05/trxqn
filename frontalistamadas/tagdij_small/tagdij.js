document.addEventListener('DOMContentLoaded', () => {
    console.log('DOM loaded');
    const nev = document.getElementById('nev');
    const szuldatum = document.getElementById('szuldatum');
    const irszam = document.getElementById('irszam');
    const orsz = document.getElementById('orsz');
    const hozzaadGomb = document.getElementById('hozzaad');
    const apiURl = 'http://localhost/api/index.php/?ugyfel';
    const ugyfelekCards = document.getElementById('ugyfelek');

    async function getAllUgyfel(){
        let result = await fetch(apiURl);
        let ugyfelek = await result.json();
        showCards(ugyfelek);
    }
    function showCards(adatok){
            ugyfelekCards.innerHTML = '';
            let cards = "";
            adatok.forEach(ugyfel => {
                cards += `<div class="card col-lg-2 col-md-3 col-sm-12 m-2">
                        <h4 class="card-header">${ugyfel.nev}</h4>
                        <div class="card-body">
                        <p class="card-text">${ugyfel.szuldatum}</p>
                        <p class="card-text">${ugyfel.irszam}</p>
                        <p class="card-text">${ugyfel.orsz}</p>
                        </div>
                    </div>`;
            });
            ugyfelekCards.innerHTML = cards;
    }
    getAllUgyfel();
});