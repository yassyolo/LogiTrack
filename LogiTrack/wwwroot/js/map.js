function initMap(containerId, latitude, longitude, title) {
    const mapContainer = document.getElementById(containerId);

    if (!mapContainer) {
        console.error(`Map container with ID "${containerId}" not found.`);
        return;
    }

    const location = { lat: parseFloat(latitude), lng: parseFloat(longitude) };

    const map = new google.maps.Map(mapContainer, {
        zoom: 12,
        center: location,
    });

    new google.maps.Marker({
        position: location,
        map: map,
        title: title,
    });
}

async function fetchLocation(lat, long, outputContainerId) {
    const apiKey = 'AIzaSyDfA3_DsCdEYZeSpUwLBSenw1Gyp1VGIp4';
    const url = `https://maps.googleapis.com/maps/api/geocode/json?latlng=${lat},${long}&key=${apiKey}`;

    try {
        const response = await fetch(url);
        const data = await response.json();

        if (data.results && data.results.length > 0) {
            const address = data.results[0].formatted_address;
            document.getElementById(outputContainerId).textContent = address;
        } else {
            document.getElementById(outputContainerId).textContent = "Unable to retrieve location.";
        }
    } catch (error) {
        console.error("Error fetching location:", error);
        document.getElementById(outputContainerId).textContent = "Error fetching location.";
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const pickupMapContainer = document.getElementById('pickupMap');
    const deliveryMapContainer = document.getElementById('deliveryMap');

    if (pickupMapContainer) {
        const pickupLat = pickupMapContainer.dataset.latitude;
        const pickupLng = pickupMapContainer.dataset.longitude;

        initMap('pickupMap', pickupLat, pickupLng, 'Pickup Location');
        fetchLocation(pickupLat, pickupLng, 'pickupAddress');
    }

    if (deliveryMapContainer) {
        const deliveryLat = deliveryMapContainer.dataset.latitude;
        const deliveryLng = deliveryMapContainer.dataset.longitude;

        initMap('deliveryMap', deliveryLat, deliveryLng, 'Delivery Location');
        fetchLocation(deliveryLat, deliveryLng, 'deliveryAddress');
    }
});