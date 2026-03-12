import React, { useEffect, useState } from 'react';

export interface Bowler {
  bowlerName: string;
  teamName: string;
  address: string;
  city: string;
  state: string;
  zip: string;
  phoneNumber: string;
}

const API_URL = '/api/bowlers';

const BowlerTable: React.FC = () => {
  const [bowlers, setBowlers] = useState<Bowler[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchBowlers = async () => {
      try {
        const response = await fetch(API_URL);
        const data = await response.json().catch(() => ({}));
        if (!response.ok) {
          const msg = (data as { error?: string })?.error ?? data?.detail ?? response.statusText;
          throw new Error(msg);
        }
        setBowlers(Array.isArray(data) ? data : []);
      } catch (err) {
        const message =
          err instanceof Error ? err.message : 'An error occurred';
        setError(message);
      } finally {
        setLoading(false);
      }
    };

    fetchBowlers();
  }, []);

  if (loading) return <p>Loading bowlers...</p>;
  if (error) return <p className="error">Error: {error}</p>;
  if (bowlers.length === 0) return <p>No bowlers found.</p>;

  return (
    <div className="table-container">
      <table className="bowler-table">
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((bowler, index) => (
            <tr key={index}>
              <td>{bowler.bowlerName}</td>
              <td>{bowler.teamName}</td>
              <td>{bowler.address}</td>
              <td>{bowler.city}</td>
              <td>{bowler.state}</td>
              <td>{bowler.zip}</td>
              <td>{bowler.phoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default BowlerTable;
