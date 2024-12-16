
    document.addEventListener('DOMContentLoaded', async function () {
        try {
        await Promise.all([
            renderInvoiceStatusDistribution(),
            renderTotalSpendingChart(),
            renderPriceDifferenceChart()
        ]);
        } catch (error) {
        console.error('Error initializing charts:', error);
        }
    });

    async function renderInvoiceStatusDistribution() {
        try {
            const response = await fetch('/Clients/GetInvoicesStatusDistribution');
    if (!response.ok) throw new Error(`HTTP error! Status: ${response.status}`);
    const data = await response.json();

    const statuses = Object.keys(data.statusCounts || { });
    const counts = Object.values(data.statusCounts || { });

    if (!statuses.length) {
        console.warn('No data available for Invoice Status Distribution');
    return;
            }

    const ctx = document.getElementById('invoiceStatusChart').getContext('2d');
    new Chart(ctx, {
        type: 'doughnut',
    data: {
        labels: statuses,
    datasets: [{
        data: counts,
    backgroundColor: ['#4CAF50', '#00aa87', '#FF6384'],
                    }]
                },
    options: {
        responsive: true,
    plugins: {
        legend: {
        display: true,
    position: 'bottom'
                        },
    tooltip: {
        callbacks: {
        label: (tooltipItem) => `${statuses[tooltipItem.dataIndex]}: ${counts[tooltipItem.dataIndex]}`
                            }
                        }
                    }
                }
            });
        } catch (error) {
        console.error('Error rendering Invoice Status Distribution:', error);
        }
    }

    async function renderTotalSpendingChart() {
        try {
            const response = await fetch('/Clients/GetTotalSpending');
    if (!response.ok) throw new Error(`HTTP error! Status: ${response.status}`);
    const data = await response.json();

    const totalSpent = data.totalSpent || 0;

    const ctx = document.getElementById('totalSpendingChartContainer').getContext('2d');
    new Chart(ctx, {
        type: 'bar',
    data: {
        labels: ['Total Money Spent'],
    datasets: [{
        label: 'Money Spent ($)',
    data: [totalSpent],
    backgroundColor: ['#00aa87'],
    borderColor: ['#00aa87'],
    borderWidth: 1
                    }]
                },
    options: {
        responsive: true,
    plugins: {
        legend: {
        display: false
                        },
    tooltip: {
        callbacks: {
        label: (tooltipItem) => `$${tooltipItem.raw.toFixed(2)}`
                            }
                        }
                    },
    scales: {
        y: {
        beginAtZero: true,
    title: {
        display: true,
    text: 'Amount ($)'
                            }
                        }
                    }
                }
            });
        } catch (error) {
        console.error('Error rendering Total Spending Chart:', error);
        }
    }

    async function renderPriceDifferenceChart() {
        try {
            const response = await fetch('/Clients/GetRequestPriceDifferences');
    if (!response.ok) throw new Error(`HTTP error! Status: ${response.status}`);
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
    backgroundColor: '#00aa87',
    borderColor: '#00aa87',
    borderWidth: 1
                        },
    {
        label: 'Final Price',
    data: finalPrices,
    backgroundColor: '#FF6384',
    borderColor: '#FF6384',
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