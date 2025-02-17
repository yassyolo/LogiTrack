﻿
    async function fetchDeliveryCounts() {
        try {
            const response = await fetch('/Clients/GetDeliveryTypes');
    const data = await response.json();

    const domesticCount = data.domestic ?? 0;
    const internationalCount = data.international ?? 0;

    const ctx = document.getElementById('deliveryChart').getContext('2d');
    const deliveryChart = new Chart(ctx, {
        type: 'pie',
    data: {
        labels: ['Domestic', 'International'],
    datasets: [{
        label: 'Deliveries',
    data: [domesticCount, internationalCount],
    backgroundColor: ['#00aa87', '#FF6384'],
    hoverOffset: 4
                    }]
                },
    options: {
        responsive: true,
    plugins: {
        legend: {
        position: 'bottom',
                        }
                    }
                }
            });

        } catch (error) {
        console.error('Error fetching delivery counts:', error);
        }
    }
    async function fetchMonthlyDeliveries() {
        try {
            const response = await fetch('/Clients/GetDeliveryCounts');
    const data = await response.json();

    console.log('Fetched data:', data);

    const ctx = document.getElementById('monthlyDeliveryChart').getContext('2d');
    const monthlyDeliveryChart = new Chart(ctx, {
        type: 'bar',
    data: {
        labels: data.months,
    datasets: [{
        label: 'Deliveries per Month',
    data: data.deliveries,
    backgroundColor: '#00aa87',
    borderColor: '#00aa87',
    borderWidth: 1
                    }]
                },
    options: {
        responsive: true,
    scales: {
        y: {
        beginAtZero: true,
    ticks: {
        stepSize: 1
                            }
                        }
                    },
    plugins: {
        legend: {
        display: false
                        },
    tooltip: {
        callbacks: {
        label: function (tooltipItem) {
                                    return 'Deliveries: ' + tooltipItem.raw;
                                }
                            }
                        }
                    }
                }
            });
        } catch (error) {
        console.error('Error fetching monthly deliveries:', error);
        }
    }
    async function fetchDeliverySuccessRate() {
        try {
            const response = await fetch('/Clients/GetDeliveryTimes');
    const data = await response.json();

    const successRate = data.successRate || 0;
    const failureRate = 100 - successRate;
    const averageDelay = data.averageDelay || 0;

    const ctx = document.getElementById('successRateChart').getContext('2d');
    new Chart(ctx, {
        type: 'radar',
    data: {
        labels: ['Success', 'Failure'],
    datasets: [{
        label: 'Delivery Rates',
    data: [successRate, failureRate],
    backgroundColor: '#FF6384',
    borderColor: '#FF6384',
    borderWidth: 2
                    }]
                },
    options: {
        responsive: true,
    scales: {
        r: {
        angleLines: {
        display: true
                            },
    beginAtZero: true
                        }
                    },
    plugins: {
        legend: {
        position: 'top',
                        }
                    }
                }
            });

    document.getElementById('averageDelay').innerText =
    `Average delay time: ${averageDelay.toFixed(2)} hrs`;

        } catch (error) {
        console.error('Error fetching delivery success rate:', error);
        }
    }
    document.addEventListener('DOMContentLoaded', async function () {
        console.log('DOM fully loaded and parsed');
        await fetchDeliverySuccessRate();
        await fetchMonthlyDeliveries();
        await fetchDeliveryCounts();
    });

