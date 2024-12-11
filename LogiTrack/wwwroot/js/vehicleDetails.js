document.addEventListener('DOMContentLoaded', function () {
    async function fetchVehicleCosts(vehicleId) {
        try {
            const response = await fetch(`/Logistics/GetVehicleCostsDataForVehicle/${vehicleId}`);
            if (!response.ok) {
                throw new Error('Failed to fetch vehicle costs data.');
            }

            const data = await response.json();
            console.log('Fetched vehicle costs data:', data);

            const totalCosts = data.totalCosts || 0;
            const numDeliveries = data.numDeliveries || 1;
            const avgCostPerDelivery = totalCosts / numDeliveries;

            const ctx = document.getElementById('vehicleCostsChart').getContext('2d');
            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ['Total Costs', 'Average Cost per Delivery'],
                    datasets: [{
                        label: 'Vehicle Costs',
                        data: [totalCosts, avgCostPerDelivery],
                        backgroundColor: ['#00aa87', '#FF6384'],
                        borderColor: ['#00aa87', '#FF6384'],
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    scales: {
                        y: {
                            beginAtZero: true,
                            title: {
                                display: true,
                                text: 'Costs (in currency)'
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
                                    return `${tooltipItem.dataset.label}: ${tooltipItem.raw}`;
                                }
                            }
                        }
                    }
                }
            });
        } catch (error) {
            console.error('Error fetching vehicle costs data:', error);
        }
    }

    async function fetchDistanceAndDeliveriesData(vehicleId) {
        try {
            const response = await fetch(`/Logistics/GetDistanceAndDeliveriesForVehicle/${vehicleId}`);
            if (!response.ok) {
                throw new Error('Failed to fetch distance and deliveries data.');
            }

            const data = await response.json();
            console.log('Fetched distance and deliveries data:', data);

            const labels = data.months || [];
            const totalDistance = data.totalDistance || 0;
            const totalDeliveries = data.totalDeliveries || 0;

            const ctx = document.getElementById('distanceDeliveriesChart').getContext('2d');
            new Chart(ctx, {
                type: 'line',
                data: {
                    labels: labels,
                    datasets: [
                        {
                            label: 'Total Distance Travelled (km)',
                            data: labels.map((_, index) => (index === 4 ? totalDistance : 0)),
                            borderColor: '#3498db',
                            backgroundColor: '#00aa87',
                            fill: true,
                            tension: 0.4
                        },
                        {
                            label: 'Total Deliveries',
                            data: labels.map((_, index) => (index === 4 ? totalDeliveries : 0)),
                            borderColor: '#e74c3c',
                            backgroundColor: '#FF6384',
                            fill: true,
                            tension: 0.4
                        }
                    ]
                },
                options: {
                    responsive: true,
                    scales: {
                        y: {
                            beginAtZero: true,
                            title: {
                                display: true,
                                text: 'Values'
                            }
                        },
                        x: {
                            title: {
                                display: true,
                                text: 'Months'
                            }
                        }
                    },
                    plugins: {
                        legend: {
                            display: true,
                            position: 'top'
                        },
                        tooltip: {
                            callbacks: {
                                label: function (tooltipItem) {
                                    return `${tooltipItem.dataset.label}: ${tooltipItem.raw}`;
                                }
                            }
                        }
                    }
                }
            });
        } catch (error) {
            console.error('Error fetching distance and deliveries data:', error);
        }
    }

   
        const chartContainer = document.querySelector('.chart-container canvas');
        const modelId = chartContainer ? chartContainer.dataset.modelId : null;
        
    if (modelId) {
        console.log("Found vehicleId:", modelId);
        fetchVehicleCosts(modelId);
        fetchDistanceAndDeliveriesData(modelId);
        } else {
            console.error('No vehicleId found in data attributes.');
        }
  
});
