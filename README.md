# Bicycle Rent System

## Introduction
The **Bicycle Rent System** is a comprehensive application designed to manage bicycle rental operations efficiently. This system offers a user-friendly interface for customers to rent bicycles and for administrators to manage rentals, track inventory, and handle customer information.

## Features
- **Customer Features:**
  - Rent bicycles by hour, day, or week.
  - Check available bicycles in real-time.
  - View and manage rental details.

- **Administrator Features:**
  - Add, update, or remove bicycles from inventory.
  - Track ongoing rentals and manage customer information.
  - Generate detailed rental reports.

## Technologies Used
- **Programming Language:** Python
- **Database:** SQLite
- **Frameworks/Libraries:**
  - Flask (for web application)
  - SQLAlchemy (for ORM)
  - Bootstrap (for responsive UI)

## Installation
To set up the project locally, follow these steps:

1. Clone the repository:
   ```bash
   git clone https://github.com/tugcantopaloglu/bicycle-rent-system.git
   ```

2. Navigate to the project directory:
   ```bash
   cd bicycle-rent-system
   ```

3. Create a virtual environment:
   ```bash
   python -m venv venv
   source venv/bin/activate  # On Windows: venv\Scripts\activate
   ```

4. Install the required dependencies:
   ```bash
   pip install -r requirements.txt
   ```

5. Initialize the database:
   ```bash
   python init_db.py
   ```

6. Run the application:
   ```bash
   python app.py
   ```

7. Open your browser and navigate to:
   ```
   http://localhost:5000
   ```

## Usage
- **Customers:**
  - Visit the homepage to view available bicycles.
  - Select the rental period and proceed to payment.

- **Administrators:**
  - Log in to access the admin dashboard.
  - Manage inventory and track ongoing rentals.

## Screenshots
### Homepage
![Homepage](screenshots/homepage.png)

### Admin Dashboard
![Admin Dashboard](screenshots/admin_dashboard.png)

## Future Enhancements
- Implement user authentication for customers.
- Add a mobile-friendly design.
- Enable online payment integration.
- Introduce a loyalty program for frequent renters.

## Contributing
We welcome contributions! To contribute:
1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. Commit your changes:
   ```bash
   git commit -m "Add your feature description"
   ```
4. Push to the branch:
   ```bash
   git push origin feature/your-feature-name
   ```
5. Submit a pull request.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact
For any questions or suggestions, please feel free to reach out:
- **Email:** [tugcantopaloglu@example.com](mailto:tugcantopaloglu@example.com)
- **GitHub:** [@tugcantopaloglu](https://github.com/tugcantopaloglu)
