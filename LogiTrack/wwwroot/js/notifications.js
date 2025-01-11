window.onload = function () {
    const notificationsCount = document.getElementById('notificationsCount');

    function getNotificationsCount() {
        fetch('/Home/GetNotificationsCount')
            .then(response => response.json())
            .then(data => {
                if (notificationsCount) {
                    notificationsCount.innerText = data;
                }
            })
            .catch(error => console.log("Error fetching notifications count:", error));

        console.log(notificationsCount);
    }

    getNotificationsCount();
};