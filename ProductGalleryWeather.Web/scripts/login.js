// Function to show messages
function showMessage(message, isError = false) {
    const messageDiv = document.getElementById('message');
    messageDiv.style.color = isError ? 'red' : 'green'; // Change color based on success or error
    messageDiv.textContent = message;
    messageDiv.style.display = 'block';

    // Optional: Clear the message after a few seconds
    setTimeout(() => {
        messageDiv.textContent = '';
    }, 5000); // Clear after 5 seconds
}

// Sign up form submission
document.getElementById('signup-form').addEventListener('submit', function(event) {
    event.preventDefault();  

    const username = event.target.username;
    const email = event.target.email;
    const password = event.target.password;

    if (!username.value) {
        username.setCustomValidity("Please enter your username.");
    } else {
        username.setCustomValidity(""); 
    }

    if (!email.value) {
        email.setCustomValidity("Please enter your email address.");
    } else {
        email.setCustomValidity(""); 
    }

    if (!password.value) {
        password.setCustomValidity("Please enter your password.");
    } else {
        const passwordRequirements = /^(?=.*[!@#$%^&*(),.?":{}|<>])(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d!@#$%^&*(),.?":{}|<>]{8,}$/;
        if (!passwordRequirements.test(password.value)) {
            password.setCustomValidity("Password must be at least 8 characters long and contain at least one letter, one number, and one special character.");
        } else {
            password.setCustomValidity("");
        }
    }

    if (event.target.checkValidity()) {
        const signupData = {
            username: username.value,
            email: email.value,
            password: password.value
        };

        fetch('/api/auth/register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(signupData)
        })
        .then(response => response.text())
        .then(data => {
            if (data) {
                showMessage(data);
            } else {
                showMessage('Registration failed.', true);
            }
        })
        .catch((error) => {
            console.error('Error:', error);
            showMessage('An error occurred during registration.', true);
        });
    } else {
        event.target.reportValidity();  
    }
});

// Login form submission
document.getElementById('login-form').addEventListener('submit', function(event) {
    event.preventDefault();

    const username = event.target.username; // Change from email to username
    const password = event.target.password;

    // Username validation
    if (!username.value) {
        username.setCustomValidity("Please enter your username."); // Adjusted message for username
    } else {
        username.setCustomValidity("");
    }

    // Password validation
    if (!password.value) {
        password.setCustomValidity("Please enter your password.");
    } else {
        const passwordRequirements = /^(?=.*[!@#$%^&*(),.?":{}|<>])(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d!@#$%^&*(),.?":{}|<>]{8,}$/;
        if (!passwordRequirements.test(password.value)) {
            password.setCustomValidity("Password must be at least 8 characters long and contain at least one letter, one number, and one special character.");
        } else {
            password.setCustomValidity("");
        }
    }

    // If form is valid, proceed with login
    if (event.target.checkValidity()) {
        const loginData = {
            username: username.value, // Use username in the login data
            password: password.value
        };

        fetch('/api/auth/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(loginData)
        })
        .then(response => response.json())
        .then(data => {
            if (data.token) {
                localStorage.setItem('jwtToken', data.token);
                window.location.href = 'index.html';
            } else {
                showMessage(data.message || 'Login failed.', true);
            }
        })
        .catch((error) => {
            console.error('Error:', error);
            showMessage('An error occurred during login.', true);
        });
    } else {
        event.target.reportValidity();
    }
});