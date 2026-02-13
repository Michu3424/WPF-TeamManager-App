# WPF-TeamManager-App
Desktop application designed for football team management, allowing users to track player statistics, manage squad selections, and simulate match events.

## Key Features
* **Squad Management:** Add, edit, and organize player profiles with detailed statistics.
* **Match Module:** Dedicated interface for handling match-day events (`MeczWindow`).
* **Health & Recovery:** Specialized tracking for player injuries and recovery sessions (`RegeneracjaWindow`).
* **Data Persistence:** Integrated XML-based data handling for saving team progress.
* **Unit Testing:** Includes a dedicated test project (`DruzynaPilka.Tests`) ensuring core logic reliability.

## Tech Stack
* **Language:** C#
* **Framework:** WPF (.NET)
* **Architecture:** Object-Oriented Programming (OOP) with clear separation between Business Logic and UI.
* **Data Format:** XML

## Screenshots
<img width="1109" height="622" alt="image" src="https://github.com/user-attachments/assets/a3994f00-fb38-4649-b1c3-eb4360c4ff99" />
<img width="502" height="632" alt="image" src="https://github.com/user-attachments/assets/3e8f8456-3287-48bb-927d-0f776964a670" />
<img width="495" height="760" alt="image" src="https://github.com/user-attachments/assets/fe8eda86-bf50-4092-bca2-79a9533e54d0" />
<img width="485" height="583" alt="image" src="https://github.com/user-attachments/assets/3a1953a6-c190-41bf-8d11-323f66890696" />
<img width="993" height="615" alt="image" src="https://github.com/user-attachments/assets/7688eccb-fe39-4768-affb-725f6f2e6a89" />

## How to run:
1. Open `DruzynaPilkawpf.sln` in Visual Studio.
2. Build and Run the project (F5).


## Project Structure
* **DP**: Core business logic and data models.
* **DPWPF**: User interface components and XAML layouts.
* **DruzynaPilka.Tests**: Unit tests for the application's engine.
