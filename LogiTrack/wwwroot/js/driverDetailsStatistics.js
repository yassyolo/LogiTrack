document.addEventListener("DOMContentLoaded", async () => {
    try {
        const chartContainer = document.querySelector('.chart-container canvas');
        const modelId = chartContainer ? chartContainer.dataset.modelId : null;

        if (modelId) {
            await fetchDeliveryCounts(modelId);
            await fetchMonthlyDeliveries(modelId);
            await fetchDeliverySuccessRate(modelId);
        } else {
            console.error('No modelId found in data attributes.');
        }
    } catch (error) {
        console.error("Error during chart rendering:", error);
    }
});

async function fetchDeliveryCounts(modelId) {
    try {
        const response = await fetch(`/Logistics/GetDeliveryTypesForDriver/${modelId}`);
        const data = await response.json();

        const domesticCount = data.domestic ?? 0;
        const internationalCount = data.international ?? 0;

        const ctx = document.getElementById('deliveryChart').getContext('2d');
        new Chart(ctx, {
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

async function fetchMonthlyDeliveries(modelId) {
    try {
        const response = await fetch(`/Logistics/GetDeliveryCountsForDriver/${modelId}`);
        const data = await response.json();

        while (data.deliveries.length < data.months.length) {
            data.deliveries.push(0);
        }

        if (window.monthlyDeliveryChart && typeof window.monthlyDeliveryChart.destroy === 'function') {
            window.monthlyDeliveryChart.destroy();
        }

        const ctx = document.getElementById('monthlyDeliveryChart').getContext('2d');
        window.monthlyDeliveryChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: data.months,
                datasets: [{
                    label: 'Deliveries per Month',
                    data: data.deliveries,
                    backgroundColor: '#00aa87',
                    borderColor: '#00aa87',
                    borderWidth: 1,
                    borderSkipped: false
                }]
            },
            options: {
                responsive: true,
                scales: {
                    x: {
                        ticks: {
                            autoSkip: false
                        },
                        title: {
                            display: true,
                            text: 'Months'
                        }
                    },
                    y: {
                        beginAtZero: true,
                        min: 0,
                        max: 1,
                        ticks: {
                            stepSize: 1
                        },
                        title: {
                            display: true,
                            text: 'Deliveries'
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

async function fetchDeliverySuccessRate(modelId) {
    try {
        const response = await fetch(`/Logistics/GetDeliveryTimesForDriver/${modelId}`);
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