import React, { Component } from 'react';
import axios from 'axios';
import './Product.css';
import SendString from './SendString';
import { withRouter } from 'react-router';
import { Button } from 'reactstrap/lib/Button';
import { Link } from 'react-router-dom';
import Phones from './Product';
import { Chart } from 'chart.js';


class ProdDetail extends React.Component {

    constructor(props) {
        super(props);
        this.state = { phones: [], loading: true, stringSearch: "" };
        console.log("constructor ", props);

    }
    static renderTable(phones) {

        return (
            console.log(" render test this.state", this.state),
            console.log("process cena= ", phones.Cena),
            <div>
                
                <table>
                    <tr>
                        <th>Cena</th>
                        <th>Data</th>
                        <th>Sklep</th>
                    </tr>
                {phones.map(phones =>
                    <tr>{phones.SklepID == 1 &&
                              <>
                                <td>{phones.Cena}</td>
                                <td>{phones.Data.substring(0, 10)}</td>
                                <td>{phones.SklepID == 1 && "Media Expert"}
                                    {phones.SklepID == 2 && "Avans"}</td>                
                                    </>
                    } </tr>    
                )}
                </table>
                <br></br>
                <table>
                    <tr>
                        <th>Cena</th>
                        <th>Data</th>
                        <th>Sklep</th>
                    </tr>
                {phones.map(phones =>
                    <tr>{phones.SklepID == 2 &&
                              <>
                                <td>{phones.Cena}</td>
                                <td>{phones.Data.substring(0, 10)}</td>
                                <td>{phones.SklepID == 1 && "Media Expert"}
                                    {phones.SklepID == 2 && "Avans"}</td>                
                                    </>
                    } </tr>    
                )}
                </table>
                <br></br>
                <Link to="/prodList">
                    <button>Powrót</button>
                </Link>

            </div>
        );
    }


    componentDidMount() {
        const { Id } = this.props.history.location;
        var xyz = this.props.history.location;
        console.log('history location search' + this.props.history.location.search);
        console.log('history location ' + this.props.history.location);
        console.log('xyz ' + xyz);
        console.log('Id ' + Id);

        console.log(`test/Details` + this.props.history.location.search);
        console.log(`id = ` + Id);

        axios.get(`/process/Details` + this.props.history.location.search).then(res => {
            this.setState({ phones: res.data, loading: false });

        });
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ProdDetail.renderTable(this.state.phones);

        return (
            <div>
                {contents}
            </div>
        );
    }

}


export default withRouter(ProdDetail);
/*
      
*/
