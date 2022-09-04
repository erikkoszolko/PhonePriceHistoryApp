import React, { Component } from "react";
import {
  EntryPageContainer,
  SuspensePageWrapper,
  SuspensePageAnimation,
} from "./AnimationLoader.styles.js";

export class AnimationLoader extends Component {
  static displayName = AnimationLoader.name;

  render() {
    return (
      <EntryPageContainer>
        <SuspensePageWrapper>
          <SuspensePageAnimation>
            <div></div>
            <div></div>
            <div></div>
            <div></div>
          </SuspensePageAnimation>
        </SuspensePageWrapper>
      </EntryPageContainer>
    );
  }
}
