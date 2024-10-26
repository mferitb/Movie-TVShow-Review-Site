document.addEventListener('DOMContentLoaded', function () {
    const starRating = document.getElementById('star-rating');
    const userRatingInput = document.getElementById('user-rating');

    starRating.addEventListener('click', function (e) {
        if (e.target.classList.contains('fa-star')) {
            const rating = e.target.getAttribute('data-rating');
            updateStars(rating);
            userRatingInput.value = rating;
        }
    });

    starRating.addEventListener('mouseover', function (e) {
        if (e.target.classList.contains('fa-star')) {
            const rating = e.target.getAttribute('data-rating');
            updateStars(rating);
        }
    });

    starRating.addEventListener('mouseout', function () {
        updateStars(userRatingInput.value);
    });

    function updateStars(rating) {
        const stars = starRating.querySelectorAll('.fa-star');
        stars.forEach((star, index) => {
            if (index < rating) {
                star.classList.remove('far');
                star.classList.add('fas', 'active');
            } else {
                star.classList.remove('fas', 'active');
                star.classList.add('far');
            }
        });
    }
});