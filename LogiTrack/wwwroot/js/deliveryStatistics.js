
    async function fetchDeliveryCounts() {
        try {
            const response = await fetch('/Logistics/GetDestinationTypes');
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
            const response = await fetch('/Logistics/GetDeliveryCounts');
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
    backgroundColor: '#FF6384',
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
            const response = await fetch('/Logistics/GetDestinationTypes');
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
    backgroundColor: '#00aa87',
    borderColor: '#00aa87',
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
    async function renderPopularCitiesHeatmap() {
        try {
            const response = await fetch('/Logistics/GetPopularDeliveryCities');
    if (!response.ok) {
        console.error(`Failed to fetch popular cities: ${response.status}`);
    console.error(await response.text());
    throw new Error(`HTTP error! Status: ${response.status}`);
            }

    const data = await response.json();

            const cities = data.map(item => item.city || 'Unknown');
            const deliveryCounts = data.map(item => item.deliveryCount || 0);

    const ctx = document.getElementById('popularCitiesChart').getContext('2d');
    new Chart(ctx, {
        type: 'bar',
    data: {
        labels: cities,
    datasets: [
    {
        label: 'Delivery Count',
    data: deliveryCounts,
                            backgroundColor: deliveryCounts.map(count => `#00aa87`),
    borderColor: '#00aa87',
    borderWidth: 1
                        }
    ]
                },
    options: {
        responsive: true,
    plugins: {
        tooltip: {
        callbacks: {
        label: function (tooltipItem) {
                                    return `Deliveries: ${tooltipItem.raw}`;
                                }
                            }
                        }
                    },
    scales: {
        y: {
        beginAtZero: true,
    title: {
        display: true,
    text: 'Number of Deliveries'
                            }
                        },
    x: {
        title: {
        display: true,
    text: 'Cities'
                            }
                        }
                    }
                }
            });
        } catch (error) {
        console.error('Error rendering Popular Cities Heatmap:', error);
        }
    }
    async function renderDeliveryRatingsChart() {
        try {
            const response = await fetch('/Logistics/GetDeliveryRatingsDistribution');
    if (!response.ok) {
        console.error(`Failed to fetch delivery ratings: ${response.status}`);
    console.error(await response.text());
    throw new Error(`HTTP error! Status: ${response.status}`);
            }

    const data = await response.json();

            const ratings = data.map(item => `Rating ${item.rating} Stars`);
            const counts = data.map(item => item.count);

    const canvas = document.getElementById('deliveryRatingsChart');
    if (!canvas) {
        console.error('Canvas element with ID "deliveryRatingsChart" not found.');
    return;
            }
    const ctx = canvas.getContext('2d');

    new Chart(ctx, {
        type: 'pie',
    data: {
        labels: ratings,
    datasets: [
    {
        label: 'Number of Deliveries',
    data: counts,
    backgroundColor: [
    '#FF6384', '#00aa87', '#ffe135', '#9ee37d', '#45a29e'
    ],
    borderColor: '#ffffff',
    borderWidth: 1
                        }
    ]
                },
    options: {
        responsive: true,
    plugins: {
        legend: {
        display: true,
    position: 'top'
                        },
    tooltip: {
        callbacks: {
        label: function (tooltipItem) {
                                    return `${tooltipItem.label}: ${tooltipItem.raw} Deliveries`;
                                }
                            }
                        }
                    }
                }
            });
        } catch (error) {
        console.error('Error rendering Delivery Ratings Chart:', error);
        }
    }
    fetchDeliverySuccessRate();
    fetchMonthlyDeliveries();
    fetchDeliveryCounts();
    renderPopularCitiesHeatmap();
    renderDeliveryRatingsChart();
