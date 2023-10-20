/*function afficherTableauPointage() {

    fetch(urlJour)
    .then(res => res.json())
    .then(data => {
        let infosPointJour = '';
        console.log(data);
        for (let item of data) {
            // infos += `<tr><td>${item.PointageJour}</td><td>${item.PointageHeureEntree}</td><td>${item.PointageHeureSortie} </td><td>${item.EmployeNom} ${item.EmployePrenom}</td><td>${item.EmployeTelephone}</td></tr>`;
            infosPointJour += `<tr><td>${formatComplet(item.PointageJour)}</td><td>${formatHeure(item.PointageHeureEntree)}</td><td>${formatHeure(item.PointageHeureSortie)}</td><td>${diffBetweenDates(item.PointageHeureEntree,item.PointageHeureSortie)}</td></tr>`;                            }
            document.getElementById('corpsPoint').innerHTML = infosPointJour;
        });


    var paragraphe = document.getElementById("demo");
    paragraphe.textContent = "Contenu du tableau : " + fruits.join(", ");
  }
  
  afficherTableau();
  */