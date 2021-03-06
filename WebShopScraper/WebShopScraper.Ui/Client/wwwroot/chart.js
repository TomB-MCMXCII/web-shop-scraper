﻿export function createChart(result) {
    var ctx = document.getElementById('myChart').getContext('2d');
    var ff = JSON.parse(result);
    console.log(ff);
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['1A', '220', /*'Yellow', 'Green', 'Purple', 'Orange'*/],
            datasets: [{
                label: 'Price changed for Cpu\'s',
                data: [ff[0].TimesAddedSum, ff[1].TimesAddedSum],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    //'rgba(255, 206, 86, 0.2)',
                    //'rgba(75, 192, 192, 0.2)',
                    //'rgba(153, 102, 255, 0.2)',
                    //'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    //'rgba(255, 206, 86, 1)',
                    //'rgba(75, 192, 192, 1)',
                    //'rgba(153, 102, 255, 1)',
                    //'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true,
                        min: 0,
                        max: 2000,
                        stepSize: 100,
                    }
                }]
            }
        }
    });
}
