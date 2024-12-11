
async function getCurrentLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition, showError);
    } else {
        document.getElementById('location').textContent = "Geolocation is not supported by this browser.";
    }
}

function showPosition(position) {
    const lat = position.coords.latitude;
    const long = position.coords.longitude;
    fetchLocation(lat, long);
}

async function fetchLocation(lat, long) {
    const apiKey = 'AIzaSyDfA3_DsCdEYZeSpUwLBSenw1Gyp1VGIp4';
    const url = `https://maps.googleapis.com/maps/api/geocode/json?latlng=${lat},${long}&key=${apiKey}`;

    try {
        const response = await fetch(url);
        const data = await response.json();

        if (data.results && data.results.length > 0) {
            const address = data.results[0].formatted_address;
            document.getElementById('location').textContent = address;
        } else {
            document.getElementById('location').textContent = "Unable to retrieve location.";
        }
    } catch (error) {
        console.error("Error fetching location:", error);
        document.getElementById('location').textContent = "Error fetching location.";
    }

    showCurrentTime();
}

function showError(error) {
    switch (error.code) {
        case error.PERMISSION_DENIED:
            document.getElementById('location').textContent = "User denied the request for Geolocation.";
            break;
        case error.POSITION_UNAVAILABLE:
            document.getElementById('location').textContent = "Location information is unavailable.";
            break;
        case error.TIMEOUT:
            document.getElementById('location').textContent = "The request to get user location timed out.";
            break;
        case error.UNKNOWN_ERROR:
            document.getElementById('location').textContent = "An unknown error occurred.";
            break;
    }
}

window.onload = getCurrentLocation;
