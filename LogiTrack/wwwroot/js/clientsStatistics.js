
    fetch('/Logistics/GetTop10Clients')
        .then(response => response.json())
        .then(data => {
            const labels = Object.keys(data);
    const payments = Object.values(data);

    new Chart(document.getElementById('topClientsChart'), {
        type: 'bar',
    data: {
        labels: labels,
    datasets: [{
        label: 'Total Payments',
    data: payments,
    backgroundColor: '#FF6384',
    borderColor: '#FF6384',
    borderWidth: 1
                    }]
                },
    options: {
        scales: {
        y: {
        title: {display: true, text: 'Total Payments' }
                        },
    x: {
        title: {display: true, text: 'Client Names' }
                        }
                    }
                }
            });
        })
        .catch(error => {
        console.error('Error fetching data:', error);
        });
    fetch('/Logistics/GetTop10ClientsByDeliveries')
        .then(response => response.json())
        .then(data => {
            const clientNames = Object.keys(data);
    const deliveryCounts = Object.values(data);

    new Chart(document.getElementById('topClientsByDeliveryVolumeChart'), {
        type: 'bar',
    data: {
        labels: clientNames,
    datasets: [{
        label: 'Delivery Volume',
    data: deliveryCounts,
    backgroundColor: '#00aa87',
    borderColor: '#00aa87',
    borderWidth: 1
                    }]
                },
    options: {
        scales: {
        y: {
        title: {display: true, text: 'Number of Deliveries' }
                        },
    x: {
        title: {display: true, text: 'Client Names' },
    ticks: {
        autoSkip: true,
    maxRotation: 45,
    minRotation: 0
                            }
                        }
                    }
                }
            });
        })
        .catch(error => {
        console.error('Error fetching data:', error);
        });
