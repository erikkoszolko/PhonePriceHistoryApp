import styled from "styled-components";

export const EntryPageContainer = styled.div`
  display: flex;
  align-items: center;
  position: absolute;
  flex-direction: column;
  min-height: 100vh;
  background-color: #fbfbfb;
  top: 0px;
  width: 2500px;
  margin-left: -600x;
  box-sizing: border-box;
  background: white;
  background-size: 100% auto !important;
`;

export const SuspensePageWrapper = styled.div`
  width: 100%;
  margin-top: 130px;
  margin-top: 300px;
  min-height: 100vh;
  border-radius: 5px;
  padding: 50px;
  margin-bottom: 40px;
  box-shadow: 0 1px 3px 0 rgba (0, 0, 0, 0.1), 0 1px 2px 0 rgba(0, 0, 0, 0.06);
  text-align: center;
`;

export const SuspensePageAnimation = styled.div`
  display: inline-block;
  position: relative;
  width: 80px;
  height: 80px;

  div {
    box-sizing: border-box;
    display: block;
    position: absolute;
    width: 64px;
    height: 64px;
    margin: 8px;
    border: 8px solid #fff;
    border-radius: 50%;
    animation: lds-ring 1.2s cubic-bezier(0.5, 0, 0.5, 1) infinite;
    border-color: #fff transparent transparent transparent;
  }

  div:nth-child(1) {
    animation-delay: -0.45s;
  }

  div:nth-child(2) {
    animation-delay: -0.3s;
  }

  div:nth-child(3) {
    animation-delay: -0.15s;
  }

  @keyframes lds-ring {
    0% {
      transform: rotate(0deg);
    }
    100% {
      transform: rotate(360deg);
    }
  }
`;
