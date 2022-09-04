import React, { Component, useEffect, useState } from 'react';
import { DOMElement } from 'react';
import axios from 'axios';
import './Product.css';
import { useHistory } from 'react-router';
import { AnimationLoader } from './AnimationLoader';

export default function Phones(props) {
  const [allPhones, setAllPhones] = useState([])
  const [phones, setPhones] = useState([])
  const [isLoading, setIsLoading] = useState(true)
  const [searchString, setSearchString] = useState("")
  const history = useHistory()
  useEffect(filterPhones, [searchString, allPhones])
  useEffect(getPhones, [])

  function getPhones() {
    axios.get('/process').then(onResolve);

    function onResolve({ data }) {
      setPhones([...data])
      setAllPhones([...data])
      setIsLoading(false)
    }
  }

  function filterPhones() {
    if (searchString)
      setPhones(phones => [...allPhones.filter(({ Nazwa }) => Nazwa.toLowerCase().includes(searchString.toLowerCase()))])
    else
      setPhones([...allPhones])
  }

  return (
    <>
      {
        isLoading ? <p><em><AnimationLoader></AnimationLoader></em></p> :
          <div>
            <div>
              <input
                type="text"
                name="searchString"
                placeholder="Type here..."
                onChange={e => setSearchString(e.target.value)}
                value={searchString}
              />
              <table>
                <tr>
                  <th>#</th>
                  <th>Nazwa</th>
                  <th>Więcej</th>
                </tr>
                {phones.map(phones =>
                  <tr>
                    <td>{phones.Id}</td>
                    <td>{phones.Nazwa}</td>
                    <td>
                      <button className="btn btn-primary"
                        onClick={prepareHandleMoreButtonClick(phones.Id)}>
                        Więcej
                      </button></td>
                  </tr>
                )}
              </table>
              <br></br>
              
            </div>
          </div>
      }
    </>
  )
  function prepareHandleMoreButtonClick(Id) {
    return () => {
      history.push(`/proddetail?Id=${Id}`);
    }
  }
}