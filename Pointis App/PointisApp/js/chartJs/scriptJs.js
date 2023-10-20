

var idsoc = sessionStorage.getItem('idSociete');
//console.log(idsoc);

var lien1 = 'https://face.activactions.net/api/Pointage/AbsenceJourSoc/' + idsoc;
var lien2 = 'https://face.activactions.net/api/Pointage/LateWeek/' + idsoc;



fetch(lien1)
    .then(res => res.json())
    .then(data1 => {
        console.log(data1)
        fetch(lien2)
            .then(res => res.json())
            .then(data2 => {
                console.log(data2);
                var ctx = document.getElementById("myChart").getContext("2d");

                var donnees = {
                    labels: data1.Jour,
                    datasets: [
                        {
                            label: "Retard",
                            backgroundColor: "#8dc63f",
                            data: data2
                        },
                        {
                            label: "Absence",
                            backgroundColor: "green",
                            data: data1.Total
                        }
                        /*{
                            label: "Green",
                            backgroundColor: "green",
                            data: [7,2,6]
                        }*/
                    ]
                }

                var myBarChart = new Chart(ctx, {
                    type: 'bar',
                    data: donnees,
                    options: {
                        barValueSpacing: 20,
                        scales: {
                            yAxes: [{
                                ticks: {
                                    min: 0,
                                }
                            }]
                        }
                    }
                });
            })
    });


var ctxx = document.getElementById("myChartEquipe").getContext("2d");

var donnees = {
    labels: ["Lundi", "Mardi", "Mercredi"],
    datasets: [
        {
            label: "Retard",
            backgroundColor: "#8dc63f",
            data: [2, 3, 5]
        },
        {
            label: "Absence",
            backgroundColor: "green",
            data: [4, 5, 3]
        }
        /*{
            label: "Green",
            backgroundColor: "green",
            data: [7,2,6]
        }*/
    ]
}

var myBarChart = new Chart(ctxx, {
    type: 'bar',
    data: donnees,
    options: {
        barValueSpacing: 20,
        scales: {
            yAxes: [{
                ticks: {
                    min: 0,
                }
            }]
        }
    }
});


// Chart 1

/*var xValues = ["LUN", "MAR", "MER", "JEU", "VEN", "SAM", "DIM"];
var yValues = [15, 5, 10, 15, 25, 15, 20];
var barColors = ["#8dc63f", "#6ba63c", "#8dc63f", "#6ba63c", "#8dc63f", "#6ba63c","#8dc63f" ];


new Chart("myChart", {
    type: "bar",
    data: {
        labels: xValues,
        datasets: [{
            backgroundColor: barColors,
            data: yValues
        }]
    },
    options: {
      legend: {display: true},
      title: {
        display: true,
        text: "Cette semaine"
      }
    }


});

// End Chart 1


// Chart 2

const xValues2 = [50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150];
const yValues2 = [7, 8, 8, 9, 9, 9, 10, 11, 14, 14, 15];

new Chart("myChartBord2", {
    type: "line",
    data: {
        labels: xValues2,
        datasets: [{
            fill: false,
            lineTension: 0,
            backgroundColor: "rgba(0,0,255,1.0)",
            borderColor: "rgba(0,0,255,0.1)",
            data: yValues2
        }]
    },
    options: {
        legend: { display: false },
        scales: {
            yAxes: [{ ticks: { min: 6, max: 16 } }],
        }
    }
});*/


// End Chart 2







