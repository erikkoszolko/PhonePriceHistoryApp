import React from "react";
import { useState } from "react";
import axios from 'axios';



function SearchPhone(MYphones){
    const [searchTerm , setSearchTerm] = useState("");

    
   return(
    <div>
        <input 
        type="text"
        placeholder="Zacznij wyszukiwanie..."
        onChange={(event) => {
            setSearchTerm(event.target.value);
        }}
        />
        {MYphones.filter((val) => {
            if(searchTerm = ""){
                return val
            } else if(val.Title.toLowerCase().includes(searchTerm.toLocaleLowerCase())){
                return val
            }
        }).map((val,key)=> {
            return(
                <p>{val.Title}</p>
            );
        })

        }
    </div>
   );
}
export default SearchPhone;