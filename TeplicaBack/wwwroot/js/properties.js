var ctx = document.getElementById('myChart').getContext('2d');
var aArray = []
document.querySelectorAll('#values').forEach((key) => {
    aArray.push(key.textContent);
});
var bArray = []
document.querySelectorAll('#keys').forEach((key) => {
    bArray.push(parseInt(key.textContent));
});

new Chart(ctx, {
    type: 'line',
    data: {
        labels: aArray,
        datasets: [{
            label: document.querySelector('#controllertype').textContent,
            backgroundColor: ['red'],
            borderColor: 'rgb(255, 99, 132)',
            data: bArray,
            borderWidth: 1
        }]
    },
    options:
    {
    }
});

