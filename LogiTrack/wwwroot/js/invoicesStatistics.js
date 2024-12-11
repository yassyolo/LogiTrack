
async function fetchInvoiceStatusData() {
    try {
        const response = await fetch('/Accountant/GetInvoicesByStatus');
        if (!response.ok) throw new Error(`HTTP error! Status: ${response.status}`);

        const data = await response.json();
        console.log('Invoice status data:', data);

        const statuses = Object.keys(data);
        const counts = Object.values(data);

        const ctx = document.getElementById('invoiceStatusChart').getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: statuses,
                datasets: [{
                    label: 'Invoices by Status',
                    data: counts,
                    backgroundColor: ['#FF6384', '#00aa87', '#FFCE56'],
                    borderColor: ['#FF6384', '#00aa87', '#FFCE56'],
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
                }
            }
        });
    } catch (error) {
        console.error('Error fetching invoice status data:', error);
    }
}

async function fetchTop10OverdueClients() {
    try {
        const response = await fetch('/Accountant/GetTop10ClientsByOverdueAmount');
        if (!response.ok) throw new Error(`HTTP error! Status: ${response.status}`);

        const data = await response.json();
        console.log('Top 10 overdue clients data:', data);

        const companies = Object.keys(data);
        const amounts = Object.values(data);

        const ctx = document.getElementById('overdueAmountChart').getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: companies,
                datasets: [{
                    label: 'Total Overdue Amount',
                    data: amounts,
                    backgroundColor: '#FF6384',
                    borderColor: '#FF6384',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true
                    },
                    x: {
                        ticks: {
                            autoSkip: false,
                            maxRotation: 90,
                            minRotation: 45
                        }
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching overdue client data:', error);
    }
}

async function fetchLatePaymentsByClient() {
    try {
        const response = await fetch('/Accountant/GetLatePaymentsByClient');
        if (!response.ok) throw new Error(`HTTP error! Status: ${response.status}`);

        const data = await response.json();
        console.log('Late payments by client data:', data);

        const labels = Object.keys(data);
        const values = Object.values(data);

        const ctx = document.getElementById('latePaymentsChart').getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Overdue Amounts',
                    data: values,
                    backgroundColor: '#00aa87',
                    borderColor: '#C70039',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching late payments data:', error);
    }
}

$(document).ready(function () {
    fetchInvoiceStatusData();
    fetchTop10OverdueClients();
    fetchLatePaymentsByClient();
});
