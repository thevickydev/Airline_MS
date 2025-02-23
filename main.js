
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" >
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" >

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

// Form Validation and Handling
document.addEventListener('DOMContentLoaded', function() {
    // Flight Search Form
    const flightSearchForm = document.getElementById('flightSearchForm');
    if (flightSearchForm) {
        flightSearchForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            // Get form values
            const fromCity = document.getElementById('fromCity').value;
            const toCity = document.getElementById('toCity').value;
            const departureDate = document.getElementById('departureDate').value;
            
            // Validate cities are different
            if (fromCity === toCity) {
                alert('Departure and arrival cities must be different');
                return;
            }
            
            // Show flight results
            showFlightResults();
        });
    }

    // Booking Form
    const bookingForm = document.getElementById('bookingForm');
    if (bookingForm) {
        bookingForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            // Simulate booking confirmation
            alert('Booking confirmed! A confirmation email will be sent shortly.');
            window.location.href = 'index.html';
        });
    }

    // Comment Form
    const commentForm = document.getElementById('commentForm');
    if (commentForm) {
        commentForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            const email = document.getElementById('email').value;
            const comment = document.getElementById('comment').value;
            
            // Add comment to the list
            addComment(email, comment);
            
            // Clear form
            commentForm.reset();
        });
    }

    // Login Form
    const loginForm = document.getElementById('loginForm');
    if (loginForm) {
        loginForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            // Simulate login
            alert('Login successful!');
            
            // Close modal
            const modal = bootstrap.Modal.getInstance(document.getElementById('loginModal'));
            modal.hide();
        });
    }

    // Signup Form
    const signupForm = document.getElementById('signupForm');
    if (signupForm) {
        signupForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            // Simulate signup
            alert('Account created successfully! Please login.');
            
            // Close modal
            const modal = bootstrap.Modal.getInstance(document.getElementById('signupModal'));
            modal.hide();
        });
    }
});

// Function to display mock flight results
function showFlightResults() {
    const resultsDiv = document.getElementById('flightResults');
    const flightList = document.querySelector('.flight-list');
    
    if (resultsDiv && flightList) {
        // Clear previous results
        flightList.innerHTML = '';
        
        // Add mock flight results
        const flights = [
            {
                airline: 'SkyWings Airlines',
                departure: '09:00',
                arrival: '11:30',
                price: '$299',
                duration: '2h 30m'
            },
            {
                airline: 'SkyWings Airlines',
                departure: '13:00',
                arrival: '15:30',
                price: '$349',
                duration: '2h 30m'
            },
            {
                airline: 'SkyWings Airlines',
                departure: '18:00',
                arrival: '20:30',
                price: '$279',
                duration: '2h 30m'
            }
        ];
        
        flights.forEach(flight => {
            const flightCard = document.createElement('div');
            flightCard.className = 'flight-card';
            flightCard.innerHTML = `
                <div class="row align-items-center">
                    <div class="col-md-3">
                        <h5>${flight.airline}</h5>
                    </div>
                    <div class="col-md-3">
                        <p class="mb-0">Departure: ${flight.departure}</p>
                        <p class="mb-0">Arrival: ${flight.arrival}</p>
                    </div>
                    <div class="col-md-2">
                        <p class="mb-0">Duration: ${flight.duration}</p>
                    </div>
                    <div class="col-md-2">
                        <h4 class="mb-0">${flight.price}</h4>
                    </div>
                    <div class="col-md-2">
                        <a href="booking.html" class="btn btn-primary">Select</a>
                    </div>
                </div>
            `;
            flightList.appendChild(flightCard);
        });
        
        resultsDiv.style.display = 'block';
    }
}

// Function to add a comment
function addComment(email, comment) {
    const commentsList = document.getElementById('commentsList');
    const commentElement = document.createElement('div');
    commentElement.className = 'card mb-3';
    commentElement.innerHTML = `
        <div class="card-body">
            <h6 class="card-subtitle mb-2 text-muted">${email}</h6>
            <p class="card-text">${comment}</p>
            <small class="text-muted">${new Date().toLocaleDateString()}</small>
        </div>
    `;
    commentsList.prepend(commentElement);
}

// Date validation
const departureDateInput = document.getElementById('departureDate');
const returnDateInput = document.getElementById('returnDate');

if (departureDateInput && returnDateInput) {
    // Set minimum date to today
    const today = new Date().toISOString().split('T')[0];
    departureDateInput.min = today;
    returnDateInput.min = today;
    
    // Ensure return date is after departure date
    departureDateInput.addEventListener('change', function() {
        returnDateInput.min = this.value;
    });
}