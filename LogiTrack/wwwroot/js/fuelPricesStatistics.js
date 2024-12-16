
    async function fetchFuelPrice() {
        try {
            const response = await fetch('/Speditor/MaxAndTodayPriceRatio');
    const data = await response.json();

    const currentPrice = data.currentPrice || 0;
    const maxPrice = data.maxPrice || 0;

    const ctx = document.getElementById('fuelPriceBarChart').getContext('2d');
    new Chart(ctx, {
        type: 'bar',
    data: {
        labels: ['Current Price', 'Max Price'],
    datasets: [{
        label: 'Fuel Price Comparison (BGN)',
    data: [currentPrice, maxPrice],
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
    text: 'Price (BGN)'
                            }
                        }
                    },
    plugins: {
        tooltip: {
        callbacks: {
        label: function (tooltipItem) {
                                    return `${tooltipItem.label}: ${tooltipItem.raw.toFixed(2)} BGN`;
                                }
                            }
                        }
                    }
                }
            });
        } catch (error) {
        console.error('Error fetching fuel prices:', error);
        }
    }

    async function fetchCurrentMonthFuelPrice() {
        try {
            const response = await fetch('/Speditor/GetMonthlyFuelPrices');
    const data = await response.json();

    const currentMonth = new Date().getMonth();
    const monthNames = [
    'January', 'February', 'March', 'April', 'May', 'June', 'July',
    'August', 'September', 'October', 'November', 'December'
    ];

    const currentMonthName = monthNames[currentMonth];
    const currentPrice = data[currentMonth] || 0;

    const ctx = document.getElementById('fuelPriceCurrentMonthChart').getContext('2d');
    new Chart(ctx, {
        type: 'bar',
    data: {
        labels: [currentMonthName],
    datasets: [{
        label: 'Fuel Price (BGN)',
    data: [currentPrice],
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
    title: {
        display: true,
    text: 'Price (BGN)'
                            }
                        },
    x: {
        title: {
        display: true,
    text: 'Month'
                            }
                        }
                    },
    plugins: {
        tooltip: {
        callbacks: {
        label: function (tooltipItem) {
                                    return `${tooltipItem.label}: ${tooltipItem.raw.toFixed(2)} BGN`;
                                }
                            }
                        }
                    }
                }
            });
        } catch (error) {
        console.error('Error fetching current month fuel price:', error);
        }
    }

    async function fetchFuelPricesForYear() {
        try {
            const response = await fetch('/Speditor/GetFuelPricesForYear');
    const data = await response.json();

    const months = Object.keys(data);
    const prices = Object.values(data);

    const ctx = document.getElementById('fuelPriceChart').getContext('2d');

    new Chart(ctx, {
        type: 'line',
    data: {
        labels: months,
    datasets: [{
        label: 'Fuel Price (BGN)',
    data: prices,
    borderColor: '#00aa87',
    backgroundColor: '#00aa87',
    fill: true,
    tension: 0.4
                    }]
                },
    options: {
        responsive: true,
    scales: {
        y: {
        beginAtZero: false,
    title: {
        display: true,
    text: 'Price (BGN)'
                            }
                        },
    x: {
        title: {
        display: true,
    text: 'Month'
                            }
                        }
                    },
    plugins: {
        tooltip: {
        callbacks: {
        label: function (tooltipItem) {
                                    return `${tooltipItem.label}: ${tooltipItem.raw.toFixed(2)} BGN`;
                                }
                            }
                        }
                    }
                }
            });
        } catch (error) {
        console.error('Error fetching fuel prices for the year:', error);
        }
    }

    fetchFuelPricesForYear();
    fetchCurrentMonthFuelPrice();
    fetchFuelPrice();
