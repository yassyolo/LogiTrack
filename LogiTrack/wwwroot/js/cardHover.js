
document.querySelectorAll('.item-card').forEach(card => {
    card.addEventListener('mouseenter', () => {
        const metrics = card.querySelector('.item-metrics');
        metrics.style.display = 'flex';
        metrics.style.width = `${card.clientWidth}px`;
    });

    card.addEventListener('mouseleave', () => {
        const metrics = card.querySelector('.item-metrics');
        metrics.style.display = 'none';
    });
});

