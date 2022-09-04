import React from "react";


var SendString = (function() {
    var searchString = "";
  
    var getString = function() {
      return searchString;    // Or pull this from cookie/localStorage
    };
  
    var setString = function(str) {
        searchString = str;     
      // Also set this in cookie/localStorage
    };
  
    return {
      getString: getString,
      setString: setString
    }
  
  })();
  
  export default SendString;