
    async function fetchRequestStatusDistribution() {
        try {
            const response = await fetch('/Clients/GetRequestStatusDistribution');
    const data = await response.json();

    const labels = Object.keys(data.statusCounts);
    const counts = Object.values(data.statusCounts);

    const ctx = document.getElementById('requestStatusChart').getContext('2d');
    new Chart(ctx, {
        type: 'doughnut',
    data: {
        labels: labels,
    datasets: [{
        data: counts,
    backgroundColor: [
    '#00aa87', '#FF6384', '#3498db', '#f1c40f', '#9b59b6'
    ],
                    }]
                },
    options: {
        responsive: true,
    plugins: {
        legend: {
        position: 'bottom'
                        }
                    }
                }
            });
        } catch (error) {
        console.error('Error fetching request status distribution:', error);
        }
    }

    async function fetchAverageResponseTime() {
        try {
            const response = await fetch('/Logistics/GetAverageResponseTime');
    const data = await response.json();

    const ctx = document.getElementById('responseTimeGauge').getContext('2d');
    new Chart(ctx, {
        type: 'doughnut',
    data: {
        labels: ['Average Response Time (Hours)'],
    datasets: [{
        data: [data.averageResponseTime, 24 - data.averageResponseTime],
    backgroundColor: ['#00aa87', '#e0e0e0'],
    hoverOffset: 4
                    }]
                },
    options: {
        responsive: true,
    rotation: -90,
    circumference: 180,
    plugins: {
        tooltip: {
        callbacks: {
        label: function (tooltipItem) {
                                    return `Average Response Time: ${data.averageResponseTime.toFixed(2)} hours`;
                                }
                            }
                        }
                    }
                }
            });
        } catch (error) {
        console.error('Error fetching average response time:', error);
        }
    }

    async function renderHeatMap() {
        try {
            const response = await fetch('/Clients/GetMonthlyRequestPatterns');
    const data = await response.json();

    const daysInMonth = new Date(new Date().getFullYear(), new Date().getMonth() + 1, 0).getDate();
    const dailyCounts = Array(daysInMonth).fill(0);

    for (const [day, count] of Object.entries(data.data)) {
                const dayIndex = parseInt(day, 10) - 1;
                if (dayIndex >= 0 && dayIndex < daysInMonth) {
        dailyCounts[dayIndex] = count;
                }
            }

            const heatmapData = dailyCounts.map((count, index) => ({
        x: index + 1,
    y: count,
    v: count
            }));

    new Chart(document.getElementById('heatMapChart'), {
        type: 'scatter',
    data: {
        datasets: [{
        label: 'Requests per Day',
    data: heatmapData,
    pointStyle: 'rect',
    pointRadius: 10,
    backgroundColor(context) {
                            const value = context.raw.v;
    const colorIntensity = Math.min(value * 15, 255);
    return `#FF6384`;
                        },
                    }]
                },
    options: {
        responsive: true,
    scales: {
        x: {
        type: 'linear',
    position: 'bottom',
    title: {display: true, text: 'Day of the Month' },
    ticks: {
        stepSize: 1,
    min: 1,
    max: daysInMonth
                            }
                        },
    y: {
        title: {display: true, text: 'Request Count' },
    beginAtZero: true,
    ticks: {
        stepSize: 1,
    callback: function (value) { return Number.isInteger(value) ? value : null; }
                            }
                        }
                    },
    plugins: {
        tooltip: {
        callbacks: {
        label: function (context) {
                                    return `Day ${context.raw.x}: ${context.raw.y} request(s)`;
                                }
                            }
                        }
                    }
                }
            });
        } catch (error) {
        console.error('Error fetching heat map data:', error);
        }
    }

    window.onload = async function () {
        await fetchRequestStatusDistribution();
    await fetchAverageResponseTime();
    await renderHeatMap();
    };
