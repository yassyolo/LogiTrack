
document.addEventListener("DOMContentLoaded", async () => {
    await renderCashRegisterTypesDistribution();
    await renderAdditionalCostChart();
    await renderTotalAdditionalCostsByDeliveryType();
    await renderDistanceCostScatterChart();
    await renderTop10DeliveriesBarChart();
});

async function renderCashRegisterTypesDistribution() {
    try {
        const response = await fetch('/Accountant/GetCashRegisterTypesDistribution');
        if (!response.ok) throw new Error('Failed to fetch data');
        const data = await response.json();

        const types = Object.keys(data);
        const counts = Object.values(data);

        const ctx = document.getElementById('cashRegisterChart').getContext('2d');
        new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: types,
                datasets: [{
                    data: counts,
                    backgroundColor: ['#FF6384', '#00aa87', '#FFCE56'],
                    hoverBackgroundColor: ['#FF6384', '#00aa87', '#FFCE56']
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: { display: true, position: 'bottom' },
                    tooltip: {
                        callbacks: {
                            label: function (tooltipItem) {
                                return `${types[tooltipItem.dataIndex]}: ${counts[tooltipItem.dataIndex]}`;
                            }
                        }
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching cash register types data:', error);
    }
}

async function renderAdditionalCostChart() {
    try {
        const response = await fetch('/Accountant/AdditionalCostsForCashRegisters');
        const data = await response.json();

        const maxCost = data.maxAdditionalCost;
        const avgCost = data.averageAdditionalCost;

        const ctx = document.getElementById('additionalCostChart').getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ['Max additional cost', 'Average additional cost'],
                datasets: [{
                    label: 'Additional Cost',
                    data: [maxCost, avgCost],
                    backgroundColor: ['#FF6384', '#00aa87'],
                    borderColor: ['#FF6384', '#00aa87'],
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true,
                        ticks: { stepSize: 1 }
                    }
                },
                plugins: {
                    legend: { display: false },
                    tooltip: {
                        callbacks: {
                            label: function (tooltipItem) {
                                return `${tooltipItem.label}: $${tooltipItem.raw.toFixed(2)}`;
                            }
                        }
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching additional cost data:', error);
    }
}

async function renderTotalAdditionalCostsByDeliveryType() {
    try {
        const response = await fetch('/Accountant/GetTotalAdditionalCostsByDeliveryType');
        const data = await response.json();

        const types = Object.keys(data);
        const costs = Object.values(data);

        const ctx = document.getElementById('totalCostChart').getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: types,
                datasets: [{
                    label: 'Total additional cost',
                    data: costs,
                    backgroundColor: ['#FF6384', '#00aa87'],
                    borderColor: ['#FF6384', '#00aa87'],
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: { display: false },
                    tooltip: {
                        callbacks: {
                            label: function (tooltipItem) {
                                return `${tooltipItem.label}: $${tooltipItem.raw.toFixed(2)}`;
                            }
                        }
                    }
                },
                scales: {
                    y: { beginAtZero: true }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching total additional costs by delivery type:', error);
    }
}

async function renderDistanceCostScatterChart() {
    try {
        const response = await fetch('/Logistics/GetDistanceAdditionalCostData');
        const data = await response.json();

        const scatterData = Object.entries(data).map(([distance, cost]) => ({
            x: parseFloat(distance),
            y: parseFloat(cost)
        }));

        const ctx = document.getElementById('distanceCostScatter').getContext('2d');
        new Chart(ctx, {
            type: 'scatter',
            data: {
                datasets: [{
                    label: 'Distance vs. Additional Cost',
                    data: scatterData,
                    backgroundColor: '#00aa87',
                    borderColor: '#00aa87',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    title: { display: true, text: '' },
                    tooltip: {
                        callbacks: {
                            label: function (context) {
                                return `Distance: ${context.raw.x} km, Cost: $${context.raw.y}`;
                            }
                        }
                    }
                },
                scales: {
                    x: {
                        type: 'linear',
                        position: 'bottom',
                        title: { display: true, text: 'Distance (km)' }
                    },
                    y: {
                        title: { display: true, text: 'Additional Cost ($)' }
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching distance and cost data:', error);
    }
}

async function renderTop10DeliveriesBarChart() {
    try {
        const response = await fetch('/logistics/gettop10deliveriesbyadditionalcost');
        const data = await response.json();

        const labels = Object.keys(data);
        const values = Object.values(data);

        const ctx = document.getElementById('top10DeliveriesBarChart').getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Additional Cost ($)',
                    data: values,
                    backgroundColor: 'rgba(255, 99, 132, 0.6)',
                    borderColor: 'rgba(255, 99, 132, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    title: { display: true, text: 'Top 10 Deliveries with the Highest Additional Costs' },
                    tooltip: {
                        callbacks: {
                            label: function (context) {
                                return `Additional Cost: $${context.raw}`;
                            }
                        }
                    }
                },
                scales: {
                    x: { title: { display: true, text: 'Delivery' } },
                    y: {
                        title: { display: true, text: 'Additional Cost ($)' },
                        beginAtZero: true
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching top 10 deliveries data:', error);
    }
}
