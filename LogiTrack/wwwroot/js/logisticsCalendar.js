
    $(document).ready(function () {
        $.ajax({
            url: '/Logistics/GetCalendarEvents',
            type: 'GET',
            success: function (events) {
                events = events || [];

                var calendarEl = document.getElementById('calendar');
                var calendar = new FullCalendar.Calendar(calendarEl, {
                    initialView: 'dayGridMonth',
                    headerToolbar: {
                        left: 'prev,next today',
                        center: 'title',
                        right: 'dayGridMonth,timeGridWeek,timeGridDay'
                    },
                    events: events.map(function (event) {
                        return {
                            id: event.id,
                            title: event.title,
                            start: event.date.split("T")[0],
                            backgroundColor: getColor(event.type)
                        };
                    }),
                    dateClick: function (info) {
                        var dateEvents = events.filter(event => event.date.split("T")[0] === info.dateStr);
                        if (dateEvents.length > 0) {
                            $('#event-details').html('<h4 class="event-details">Events on ' + info.dateStr + ':</h4><ul>' +
                                dateEvents.map(e => '<li>' + e.title + '</li>').join('') +
                                '</ul>');
                        } else {
                            $('#event-details').html('<h4>No events on ' + info.dateStr + '.</h4>');
                        }
                    }
                });

                calendar.render();

                if (events.length === 0) {
                    $('#event-details').html('<p>No events available for this calendar.</p>');
                }
            },
            error: function (xhr, status, error) {
                console.error('Error fetching calendar events:', error);
                $('#calendar').html('<p>Error loading calendar events. Please try again later.</p>');
            }
        });

    function getColor(type) {
            switch (type) {
                case 'Delivered':
    return 'green';
    case 'Pickup':
    return 'blue';
    case 'Paid':
    return '#00aa87';
    default:
    return 'gray';
            }
        }
    });
