
    document.addEventListener("DOMContentLoaded", function () {
        fetch('/Logistics/GetTop10DriversByDeliveries')
            .then(response => response.json())
            .then(data => {
                const labels = Object.keys(data);
                const values = Object.values(data);

                const ctx = document.getElementById('topDriversChart').getContext('2d');
                new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: labels,
                        datasets: [{
                            label: 'Deliveries Completed',
                            data: values,
                            backgroundColor: '#FF6384',
                            borderColor: '#FF6384',
                            borderWidth: 1
                        }]
                    },
                    options: {
                        responsive: true,
                        plugins: {
                            legend: { display: false },
                            title: { display: true, text: 'Top 10 Drivers by Deliveries Completed' }
                        },
                        scales: {
                            x: { title: { display: true, text: 'Drivers' } },
                            y: {
                                title: { display: true, text: 'Number of Deliveries' },
                                beginAtZero: true
                            }
                        }
                    }
                });
            })
            .catch(error => console.error('Error fetching data:', error));
    });
    document.addEventListener("DOMContentLoaded", function () {
        fetch('/Logistics/GetLicenseExpirationOverview')
            .then(response => response.json())
            .then(data => {
                const labels = Object.keys(data);
                const values = Object.values(data);

                const ctx = document.getElementById('licenseExpirationChart').getContext('2d');
                new Chart(ctx, {
                    type: 'pie',
                    data: {
                        labels: labels,
                        datasets: [{
                            label: 'License Expirations',
                            data: values,
                            backgroundColor: [
                                '#00aa87',
                                '#FF6384',
                                'rgba(255, 206, 86, 0.7)'
                            ],
                            borderColor: [
                                '#00aa87',
                                '#FF6384',
                                'rgba(255, 206, 86, 1)'
                            ],
                            borderWidth: 1
                        }]
                    },
                    options: {
                        responsive: true,
                        plugins: {
                            legend: { display: true },
                            title: { display: true, text: 'License Expiration Overview' }
                        }
                    }
                });
            })
            .catch(error => console.error('Error fetching data:', error));
    });
    document.addEventListener("DOMContentLoaded", function () {
        fetch('/Logistics/GetDriverAvailability')
            .then(response => response.json())
            .then(data => {
                const labels = Object.keys(data);
                const values = Object.values(data);

                const ctx = document.getElementById('driverAvailabilityChart').getContext('2d');
                new Chart(ctx, {
                    type: 'pie',
                    data: {
                        labels: labels,
                        datasets: [{
                            label: 'Driver Availability',
                            data: values,
                            backgroundColor: ['#00aa87', '#FF6384'],
                            hoverOffset: 4
                        }]
                    },
                    options: {
                        responsive: true,
                        plugins: {
                            legend: {
                                display: true,
                                position: 'top'
                            },
                            title: {
                                display: true,
                                text: 'Driver Availability'
                            }
                        }
                    }
                });
            })
            .catch(error => console.error('Error fetching data:', error));
    });
    fetch('/Logistics/GetTopDriversWithInternationalDeliveries')
        .then(response => response.json())
        .then(data => {
            const labels = Object.keys(data);
    const values = Object.values(data);

    const ctx = document.getElementById('internationalDriversChart').getContext('2d');
    new Chart(ctx, {
        type: 'bar',
    data: {
        labels: labels,
    datasets: [{
        label: 'International Deliveries',
    data: values,
    backgroundColor: '#00aa87',
    borderColor: '#00aa87',
    borderWidth: 1
                    }]
                },
    options: {
        responsive: true,
    plugins: {
        legend: {display: false },
    tooltip: {enabled: true }
                    },
    scales: {
        y: {
        beginAtZero: true,
    title: {
        display: true,
    text: 'Delivery Count'
                            }
                        },
    x: {
        title: {
        display: true,
    text: 'Driver Name'
                            }
                        }
                    }
                }
            });
        })
        .catch(error => console.error('Error fetching data:', error));
    fetch('/logistics/GetTopDriversByExperience')
        .then(response => response.json())
        .then(data => {
            const labels = Object.keys(data);
    const values = Object.values(data);

    const ctx = document.getElementById('experienceDriversChart').getContext('2d');
    new Chart(ctx, {
        type: 'bar',
    data: {
        labels: labels,
    datasets: [{
        label: 'Experience (Months)',
    data: values,
    backgroundColor: '#00aa87',
    borderColor: 'rgba(255, 99, 132, 1)',
    borderWidth: 1
                    }]
                },
    options: {
        responsive: true,
    plugins: {
        legend: {display: false },
    tooltip: {enabled: true }
                    },
    scales: {
        y: {
        beginAtZero: true,
    title: {
        display: true,
    text: 'Experience (Months)'
                            }
                        },
    x: {
        title: {
        display: true,
    text: 'Driver Name'
                            }
                        }
                    }
                }
            });
        })
        .catch(error => console.error('Error fetching data:', error));
