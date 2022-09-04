import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { LoginMenu } from './api-authorization/LoginMenu';
import './NavMenu.css';


export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
  
    return (
      <header>
        <Navbar className="navbar-expand">
          <Container className="containter">
            <NavbarBrand tag={Link} to="/">MVCReact</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav ">
                <NavItem className="nav-item">
                  <NavLink tag={Link} className="nav-links" to="/">Home</NavLink>
                </NavItem>
                <NavItem className="nav-item">
                  <NavLink tag={Link} className="nav-links" to="/settings">Ustawienia</NavLink>
                </NavItem>
                <NavItem className="nav-item">
                    <NavLink tag={Link} className="nav-links" to="/prodList">Produkty</NavLink>
                </NavItem>
              
                <LoginMenu>
                </LoginMenu>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
