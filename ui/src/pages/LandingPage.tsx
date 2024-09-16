// pages/LandingPage.tsx
import React from 'react';
import styled from 'styled-components';

const Container = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 20px;
  background-color: #faf0dc;
  height: 100vh;
  position: relative;
`;

const Header = styled.div`
  position: absolute;
  top: 20px;
  right: 20px;
`;

const Button = styled.button`
  margin-left: 10px;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  background-color: #FFD700;
`;

const SearchBarContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  margin-top: 20px;
  width: 40%; 
`;

const SearchInput = styled.input`
  padding: 10px;
  margin-right: 10px;
  width: 100%;
  border: 1px solid #ccc;
  border-radius: 5px;
`;

const InfoText = styled.div`
  margin-bottom: 10px;
  font-size: 14px;
  color: #333;
`;

const LandingPage = () => {
  return (
    <Container>
      <Header>
        <Button>Sign-up</Button>
        <Button>Sign-in</Button>
      </Header>
      <SearchBarContainer>
        <InfoText>New experiences and friends are around the corner</InfoText>
        <div style={{ display: 'flex', width: '100%' }}>
          <SearchInput type="text" placeholder="Search..." />
          <Button>Show all</Button>
        </div>
      </SearchBarContainer>
    </Container>
  );
}

export default LandingPage;
