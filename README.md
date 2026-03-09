# Bowling League - Mission 10

IS 413 Assignment - A website that displays bowler contact information from the Bowling League Database for Marlins and Sharks teams.

## Project Structure

- **backend/** - ASP.NET 10 Web API
- **frontend/** - React + TypeScript app

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (or .NET 9)
- Node.js 18+
- npm

## Running the Application

### 1. Start the Backend API

```bash
cd backend
dotnet restore
dotnet run
```

The API runs at `http://localhost:5000`. The `api/bowlers` endpoint returns bowlers from Marlins and Sharks teams.

### 2. Start the Frontend

```bash
cd frontend
npm install
npm start
```

The React app runs at `http://localhost:3000` and consumes the backend API.

## Code Formatting (Prettier)

The frontend uses Prettier for code formatting. To format all files:

```bash
cd frontend
npm run format
```

## Database

The app uses SQLite with seeded sample data by default. If you have the Bowling League Database from the BYU Box download, you can:

1. Export the Bowlers and Teams tables to CSV or SQLite
2. Update the connection string in `backend/appsettings.json`
3. Adjust the model property names to match your schema if different (e.g., `BowlerFirstName` vs `FirstName`)

## API Endpoints

| Method | Endpoint       | Description                          |
| ------ | -------------- | ------------------------------------ |
| GET    | /api/bowlers   | List bowlers from Marlins & Sharks   |
