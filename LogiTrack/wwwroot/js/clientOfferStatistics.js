
    async function fetchAndRenderOfferAcceptanceBarChart(apiUrl, elementId) {
        try {
            const response = await fetch(apiUrl);
    if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
    const data = await response.json();

    let accepted = data.accepted || 0;
    let rejected = data.rejected || 0;

    const labels = [];
    const dataset = [];

            if (accepted > 0) {
        labels.push("Accepted");
    dataset.push(accepted);
            }

            if (rejected > 0) {
        labels.push("Rejected");
    dataset.push(rejected);
            }

    if (labels.length === 0) {
        labels.push("No Data");
    dataset.push(1);
            }

    const offerData = {
        labels: labels,
    datasets: [
    {
        data: dataset,
    backgroundColor: ["#00aa87", "#ff4d4d"],
    borderColor: ["#00aa87", "#ff4d4d"],
    borderWidth: 1
                    }
    ]
            };

    const offerConfig = {
        type: "bar",
    data: offerData,
    options: {
        responsive: true,
    maintainAspectRatio: false,
    plugins: {
        legend: {display: false },
    tooltip: {
        callbacks: {
        label: function (tooltipItem) {
                                    const label = offerData.labels[tooltipItem.dataIndex];
    const value = offerData.datasets[0].data[tooltipItem.dataIndex];
    return `${label}: ${value}`;
                                }
                            }
                        }
                    },
    scales: {
        y: {
        beginAtZero: true,
    title: {
        display: true,
    text: 'Count'
                            }
                        }
                    }
                }
            };

    const ctx = document.getElementById(elementId).getContext("2d");
    new Chart(ctx, offerConfig);
        } catch (error) {
        console.error("Error fetching or rendering the chart:", error);
        }
    }
    async function fetchAndRenderDualAxisChart(apiUrl, chart) {
        try {
            const response = await fetch(apiUrl);
    if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
    const data = await response.json();

    chart.data.labels = data.offers;
    chart.data.datasets[0].data = data.clientPrices;
    chart.data.datasets[1].data = data.companyPrices;

    chart.update();
        } catch (error) {
        console.error('Error fetching data for dual axis chart:', error);
        }
    }

    async function fetchAndRenderCargoRatioChart(apiUrl, chart) {
        try {
            const response = await fetch(apiUrl);
    if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
    const data = await response.json();

    chart.data.datasets[0].data = [data.standardCount, data.nonStandardCount];
    chart.update();
        } catch (error) {
        console.error('Error fetching data for cargo ratio chart:', error);
        }
    }

document.addEventListener('DOMContentLoaded', async function() {
        try {
        await fetchAndRenderOfferAcceptanceBarChart("/Clients/GetOffersAcceptanceRate", "offerAcceptanceRateChart");

    const dualAxisCtx = document.getElementById('dualAxisChart').getContext('2d');
    const dualAxisChart = new Chart(dualAxisCtx, {
        type: 'bar',
    data: {
        labels: [],
    datasets: [
    {
        label: 'Approximate prices',
    data: [],
    backgroundColor: '#FF6384',
    borderColor: '#FF6384',
    borderWidth: 1,
    yAxisID: 'y-axis-client'
                        },
    {
        label: 'Final prices',
    data: [],
    backgroundColor: '#00aa87',
    borderColor: '#00aa87',
    borderWidth: 1,
    yAxisID: 'y-axis-company'
                        }
    ]
                },
    options: {
        responsive: true,
    scales: {
        y: {beginAtZero: true },
    'y-axis-client': {
        type: 'linear',
    position: 'left',
    title: {display: true, text: 'Approximate prices' }
                        },
    'y-axis-company': {
        type: 'linear',
    position: 'right',
    title: {display: true, text: 'Final prices' }
                        }
                    }
                }
            });
    await fetchAndRenderDualAxisChart('/Clients/GetDifferencesInOfferPrices', dualAxisChart);

    const cargoRatioCtx = document.getElementById('cargoRatioChart').getContext('2d');
    const cargoRatioChart = new Chart(cargoRatioCtx, {
        type: 'bar',
    data: {
        labels: ['Standard Cargo', 'Non-Standard Cargo'],
    datasets: [
    {
        label: 'Cargo Count',
    data: [],
    backgroundColor: ['#00aa87', '#FF6384'],
    borderColor: ['rgba(75, 192, 192, 1)', 'rgba(255, 159, 64, 1)'],
    borderWidth: 1
                        }
    ]
                },
    options: {
        responsive: true,
    scales: {
        y: {
        beginAtZero: true,
    title: {display: true, text: 'Count' }
                        }
                    }
                }
            });
    await fetchAndRenderCargoRatioChart('/Clients/GetCargoRatios', cargoRatioChart);
        } catch (error) {
        console.error("Error during chart initialization:", error);
        }
});
