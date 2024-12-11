
async function fetchVehicles() {
    try {
        const response = await fetch('/Logistics/GetVehiclesForRepairment');
        const data = await response.json();
        const expiringLicenses = data.expiringLicenses || [];

        const ctx = document.getElementById('vehiclesChart').getContext('2d');

        if (expiringLicenses.length === 0) {
            new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: ['No vehicles for repairment'],
                    datasets: [{
                        data: [1],
                        backgroundColor: ['#00aa87'],
                        borderColor: ['#7f8c8d'],
                        borderWidth: 1
                    }]
                },
                options: {
                    plugins: {
                        tooltip: {
                            callbacks: {
                                label: function () {
                                    return 'No vehicles for repairment soon';
                                }
                            }
                        },
                        legend: {
                            display: true,
                            position: 'top',
                            labels: {
                                color: '#333',
                                font: { size: 14 }
                            }
                        }
                    }
                }
            });
            return;
        }

        const labels = expiringLicenses.map(vehicle => vehicle.Name);
        const values = expiringLicenses.map(vehicle => {
            const expirationDate = new Date(vehicle.ExpirationDate);
            return Math.ceil((expirationDate - new Date()) / (1000 * 60 * 60 * 24));
        });

        new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: labels,
                datasets: [{
                    data: values,
                    backgroundColor: ['#FF6384', '#00aa87', '#ffe135', '#9ee37d', '#45a29e'],
                    borderColor: '#34495e',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    tooltip: {
                        callbacks: {
                            label: function (tooltipItem) {
                                return `${tooltipItem.raw} Days until maintenance`;
                            }
                        }
                    },
                    legend: {
                        position: 'top',
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching vehicles data:', error);
    }
}

async function renderTopVehiclesChart() {
    try {
        const response = await fetch('/Logistics/GetTopVehiclesWithMostDeliveries');
        if (!response.ok) {
            console.error(`Failed to fetch top vehicles: ${response.status}`);
            throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const data = await response.json();
        const vehicleNames = Object.keys(data);
        const deliveryCounts = Object.values(data);

        const ctx = document.getElementById('topVehiclesChart').getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: vehicleNames,
                datasets: [{
                    label: 'Number of Deliveries',
                    data: deliveryCounts,
                    backgroundColor: '#FF6384',
                    borderColor: '#FF6384',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true,
                        title: { display: true, text: 'Number of Deliveries' }
                    },
                    x: {
                        title: { display: true, text: 'Vehicle' }
                    }
                },
                plugins: {
                    tooltip: {
                        callbacks: {
                            label: function (tooltipItem) {
                                return `Deliveries: ${tooltipItem.raw}`;
                            }
                        }
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error rendering Top Vehicles Chart:', error);
    }
}

async function renderTopVehiclesByAdditionalCostsChart() {
    try {
        const response = await fetch('/Logistics/GetTopVehiclesByAdditionalCosts');
        if (!response.ok) {
            console.error(`Failed to fetch top vehicles by additional costs: ${response.status}`);
            throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const data = await response.json();
        const vehicleNames = Object.keys(data);
        const additionalCosts = Object.values(data);

        const ctx = document.getElementById('topVehiclesByCostChart').getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: vehicleNames,
                datasets: [{
                    label: 'Additional Costs ($)',
                    data: additionalCosts,
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
                        title: { display: true, text: 'Total Additional Cost ($)' }
                    },
                    x: {
                        title: { display: true, text: 'Vehicles' }
                    }
                },
                plugins: {
                    tooltip: {
                        callbacks: {
                            label: function (tooltipItem) {
                                return `Cost: $${tooltipItem.raw.toFixed(2)}`;
                            }
                        }
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error rendering Top Vehicles by Additional Costs Chart:', error);
    }
}

async function renderTopVehiclesByKilometersChart() {
    try {
        const response = await fetch('/Logistics/GetTopVehiclesByKilometers');
        if (!response.ok) {
            console.error(`Failed to fetch top vehicles by kilometers: ${response.status}`);
            throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const data = await response.json();
        const vehicleNames = Object.keys(data);
        const kilometers = Object.values(data);

        const ctx = document.getElementById('topVehiclesByKilometersChart').getContext('2d');
        new Chart(ctx, {
            type: 'pie',
            data: {
                labels: vehicleNames,
                datasets: [{
                    label: 'Kilometers Driven',
                    data: kilometers,
                    backgroundColor: ['#FF6384', '#00aa87', '#ffe135', '#9ee37d', '#45a29e'],
                    borderColor: '#34495e',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    tooltip: {
                        callbacks: {
                            label: function (tooltipItem) {
                                return `${tooltipItem.label}: ${tooltipItem.raw.toFixed(2)} km`;
                            }
                        }
                    },
                    legend: { position: 'top' }
                }
            }
        });
    } catch (error) {
        console.error('Error rendering Top Vehicles by Kilometers Chart:', error);
    }
}

async function renderTopVehiclesDueForMaintenanceChart() {
    try {
        const response = await fetch('/Logistics/GetTopVehiclesDueForMaintenance');
        if (!response.ok) {
            console.error(`Failed to fetch top vehicles due for maintenance: ${response.status}`);
            throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const data = await response.json();
        const vehicleNames = Object.keys(data);
        const daysUntilMaintenance = Object.values(data);

        const ctx = document.getElementById('topVehiclesDueForMaintenanceChart').getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: vehicleNames,
                datasets: [{
                    label: 'Days Until Maintenance',
                    data: daysUntilMaintenance,
                    backgroundColor: '#FF6384',
                    borderColor: '#FF6384',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true,
                        title: { display: true, text: 'Days Until Maintenance' }
                    },
                    x: {
                        title: { display: true, text: 'Vehicles' }
                    }
                },
                plugins: {
                    tooltip: {
                        callbacks: {
                            label: function (tooltipItem) {
                                return `${tooltipItem.raw} Days`;
                            }
                        }
                    },
                    legend: { display: false }
                }
            }
        });
    } catch (error) {
        console.error('Error rendering Top Vehicles Due for Maintenance Chart:', error);
    }
}
async function renderTopVehiclesClosestToKilometersChart() {
    try {
        const response = await fetch('/Logistics/GetTopVehiclesClosestToKilometers');
        if (!response.ok) {
            console.error(`Failed to fetch top vehicles: ${response.status}`);
            console.error(await response.text());
            throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const data = await response.json();

        const vehicleNames = Object.keys(data);
        const kilometersDifference = Object.values(data);

        const ctx = document.getElementById('topVehiclesClosestToKilometersChart').getContext('2d');
        new Chart(ctx, {
            type: 'pie',
            data: {
                labels: vehicleNames,
                datasets: [
                    {
                        label: 'Kilometers to Change Parts',
                        data: kilometersDifference,
                        backgroundColor: [
                            '#FF6384', '#00aa87', '#ffe135', '#9ee37d', '#45a29e'
                        ],
                        borderColor: '#34495e',
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
                                return `${tooltipItem.label}: ${tooltipItem.raw} km`;
                            }
                        }
                    },
                    legend: {
                        position: 'top',
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error rendering Top Vehicles Closest to Kilometers Chart:', error);
    }
}
async function initializeCharts() {
    await renderTopVehiclesChart();
    await fetchVehicles();
    await renderTopVehiclesByAdditionalCostsChart();
    await renderTopVehiclesByKilometersChart();
    await renderTopVehiclesDueForMaintenanceChart();
    await renderTopVehiclesClosestToKilometersChart();
}

initializeCharts();
