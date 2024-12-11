
document.addEventListener("DOMContentLoaded", async () => {
    try {
        const charts = document.querySelectorAll('.chart');
        for (const chart of charts) {
            const modelId = chart.dataset.modelId;
            const chartId = chart.id;

            switch (chartId) {
                case 'deliveryChart':
                    await fetchDeliveryCounts(modelId);
                    break;
                case 'monthlyDeliveryChart':
                    await fetchMonthlyDeliveries(modelId);
                    break;
                case 'revenueBarChart':
                    await fetchRevenueData(modelId);
                    break;
                case 'singleClientConversionChart':
                    await fetchSingleClientConversionRate(modelId);
                    break;
                case 'deliveryCostChart':
                    await fetchClientDeliveryCostStatistics(modelId);
                    break;
                case 'priceDifferenceChart':
                    await renderPriceDifferenceChart(modelId);
                    break;
                case 'successRateChart':
                    await fetchDeliverySuccessRate(modelId);
                    break;
                default:
                    console.warn(`No function mapped for chart with ID: ${chartId}`);
            }
        }
    } catch (error) {
        console.error("Error during chart rendering:", error);
    }
});
async function fetchSingleClientConversionRate(modelId) {
    try {
        const response = await fetch(`/Logistics/GetClientRequestToDeliveryConversionRate/${modelId}`);
        if (!response.ok) {
            console.error("Failed to fetch conversion rate data.");
            return;
        }

        const data = await response.json();

        const deliveries = parseInt(data.deliveries, 10) || 0;
        const requests = parseInt(data.requests, 10) || 0;

        const remainingRequests = Math.max(0, requests - deliveries);


        const ctx = document.getElementById('singleClientConversionChart').getContext('2d');
        new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: ['Deliveries', 'Remaining Requests'],
                datasets: [{
                    data: [deliveries, remainingRequests],
                    backgroundColor: ['#00aa87', '#FF6384']
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        position: 'top'
                    },
                    title: {
                        display: true,
                        text: 'Client Request-to-Delivery Conversion Rate'
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching client conversion rate:', error);
    }
}
async function fetchDeliveryCounts(modelId) {
    try {
        const response = await fetch(`/Logistics/GetDeliveryTypes/${modelId}`);
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
        const response = await fetch(`/Logistics/GetDeliveryCountsForCompany/${modelId}`);
        const data = await response.json();

        while (data.deliveries.length < data.months.length) {
            data.deliveries.push(0);
        }

        const ctx = document.getElementById('monthlyDeliveryChart').getContext('2d');
        new Chart(ctx, {
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
                    x: {
                        ticks: { autoSkip: false },
                        title: { display: true, text: 'Months' }
                    },
                    y: {
                        beginAtZero: true,
                        ticks: { stepSize: 1 },
                        title: { display: true, text: 'Deliveries' }
                    }
                },
                plugins: {
                    legend: { display: false },
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

async function fetchRevenueData(modelId) {
    try {
        const response = await fetch(`/Logistics/GetRevenueDataForCompany/${modelId}`);
        const data = await response.json();
        console.log("Fetched data:", data);

        let totalRevenue = data.totalRevenue;

        if (typeof totalRevenue === 'string') {
            totalRevenue = parseFloat(totalRevenue);
        }

        if (isNaN(totalRevenue)) {
            totalRevenue = 0;
            console.warn("Total Revenue is not a valid number, defaulting to 0.");
        }

        console.log("Total Revenue after conversion:", totalRevenue);

        const canvas = document.getElementById('revenueBarChart');
        if (!canvas) {
            console.error("Canvas element with ID 'revenueBarChart' not found.");
            return;
        }

        const ctx = canvas.getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ['Total Revenue'],
                datasets: [{
                    label: 'Revenue',
                    data: [totalRevenue],
                    backgroundColor: ['#00aa87'],
                    borderColor: ['#00aa87'],
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                indexAxis: 'y',
                scales: {
                    x: {
                        beginAtZero: true,
                        title: {
                            display: true,
                            text: 'Revenue ($)'
                        }
                    },
                    y: {
                        title: {
                            display: true,
                            text: 'Category'
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
                                return `${tooltipItem.label}: $${tooltipItem.raw.toFixed(2)}`;
                            }
                        }
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching revenue data:', error);
    }
}
async function fetchClientDeliveryCostStatistics(modelId) {
    try {
        const response = await fetch(`/Logistics/GetClientDeliveryCostStatistics/${modelId}`);

        if (!response.ok) {
            throw new Error("Failed to fetch delivery cost statistics.");
        }

        const data = await response.json();
        console.log("Fetched data:", data);

        const maxCost = parseFloat(data.maxCost) || 0;
        const avgCost = parseFloat(data.avgCost) || 0;

        console.log("Max Cost:", maxCost, "Avg Cost:", avgCost);

        const ctx = document.getElementById("deliveryCostChart").getContext("2d");
        new Chart(ctx, {
            type: "bar",
            data: {
                labels: ["Max Cost", "Avg Cost"],
                datasets: [{
                    label: "Delivery Costs",
                    data: [maxCost, avgCost],
                    backgroundColor: ["#FF6384", "#00aa87"],
                    borderColor: ["#FF6384", "#00aa87"],
                    borderWidth: 1,
                }],
            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        display: false,
                    },
                    tooltip: {
                        callbacks: {
                            label: (context) => `Cost: ${context.raw.toFixed(2)} USD`,
                        },
                    },
                },
                scales: {
                    y: {
                        beginAtZero: true,
                        title: {
                            display: true,
                            text: "Cost (USD)",
                        },
                    },
                },
            },
        });
    } catch (error) {
        console.error("Error fetching delivery cost statistics:", error.message);
    }
}


async function renderPriceDifferenceChart(modelId) {
    try {
        const response = await fetch(`/Logistics/GetRequestPriceDifferences/${modelId}`);
        if (!response.ok) {
            console.error(`Fetch failed with status: ${response.status}`);
            console.error(await response.text());
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();
        console.log('API Response:', data);


        const labels = data.map(item => item.offerReference || 'Unknown');
        const approxPrices = data.map(item => item.approximatePrice || 0);
        const finalPrices = data.map(item => item.finalPrice || 0);

        const ctx = document.getElementById('priceDifferenceChart').getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [
                    {
                        label: 'Approximate Price',
                        data: approxPrices,
                        backgroundColor: '#FF6384',
                        borderColor: '#FF6384',
                        borderWidth: 1
                    },
                    {
                        label: 'Final Price',
                        data: finalPrices,
                        backgroundColor: '#00aa87',
                        borderColor: '#00aa87',
                        borderWidth: 1
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
                            text: 'Price ($)'
                        }
                    }
                },
                plugins: {
                    legend: {
                        position: 'top'
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error rendering Price Difference Chart:', error);
    }
}
async function fetchDeliverySuccessRate(modelId) {
    try {
        const response = await fetch(`/Logistics/GetDeliveryTimes/${modelId}`);
      
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
