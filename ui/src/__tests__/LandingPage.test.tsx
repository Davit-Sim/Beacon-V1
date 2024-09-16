// src/__tests__/LandingPage.test.tsx
import { render, screen } from '@testing-library/react';
import LandingPage from '../pages/LandingPage';

describe('Landing Page', () => {
  test('renders correctly', () => {
    render(<LandingPage />);
    expect(screen.getByText(/new experiences and friends/i)).toBeInTheDocument();
  });
});
