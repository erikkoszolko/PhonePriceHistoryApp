import React, { Component, useEffect, useState } from 'react';
import { DOMElement } from 'react';
import axios from 'axios';
import './Product.css';
import { useHistory } from 'react-router';


export default function DownloadSettings() {
  const [allPhones, setAllPhones] = useState([])
  const [phones, setPhones] = useState([])
  const history = useHistory()
  useEffect(getPhones, [])

  function getPhones() {
    axios.get('/markas').then(onResolve);

    function onResolve({ data }) {
      setPhones([...data])
      setAllPhones([...data])

    }
  }
  return (
    <>
     
     <div class="container">
        <div class="row">
          <div class="col-sm">
          <table>
              <tr>

                <th>Nazwa</th>
                <th>Więcej</th>
              
              </tr>
              {phones.map(phones =>
                <tr>

                  <td>{phones.Nazwa}</td>
                  <td>
                    <button className="btn btn-danger" name={phones.Id} onClick={del(phones.Id)}>
                      Usuń
                    </button>
                  </td>
                  
                </tr>
              )}
            </table>
          </div>
          <div class="col-sm">
            <form>
              <h3>Dodaj nowego producenta</h3>
              <br></br>
              <input 
              type="text"
              placeholder="Podaj markę..."
              />
              <input
              type="submit" 
              value="Dodaj"
              />
            </form>
          </div>
          <div class="col-sm">
            <h3>Pobierz ceny</h3>
            <br/>
            <a className="btn btn-info" href='/download/expert'>Media Expert</a>
            <br/><br/>
            <a className="btn btn-info" href='/download/avans'>Avans</a>
            
            <br/>
            
          </div>
        </div>
      </div>
    
    </>
  );
  function del(Id) {
    return () => {
      axios.get(`/markas/delete?Id=`+Id);
      window.location.reload(false);
    }
  }

}

