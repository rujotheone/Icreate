import React, { Component } from "react";
import ReactDOM from "react-dom";
import axios from 'axios';

class ViewIdea extends Component {     

      constructor(props) 
      {
         super(props);
         
         this.state = {
            
              data:[]
         }
         this.performGetRequest = this.performGetRequest.bind(this);
      };

      
    performGetRequest() 
    {
        var that=this;

      axios.get('http://localhost:18323/idea/3',{ responseType: 'json' })
      .then(function(response){
         console.log(typeof(response.data))
         that.setState({data:response.data}); 
         console.log(that.state.data)
      })
      .catch(function (error) {
         console.log(error);
      });

     }

     componentDidMount(){
      this.performGetRequest()
     }   


   render() {
      return (
         <div className='container' id='innermain'>
            <div className='row'>
            <div className='col-md-7 col-lg-7' id='view-idea'>
            <div className="view-ideabox">
            <h2>Idea details</h2>

            <button onClick = {this.performGetRequest}>View Idea</button>
            
            <div>
               <table>
                  <tbody>
                  <tr>
                     <td>{this.state.data.name}</td>
                  </tr>
                  <tr>
                     <td>{this.state.data.ideastatus}</td>
                  </tr>                     
                  </tbody>
               </table>
            </div>
            
         </div>
         </div>
         </div>
        </div>
      );
   }
}
export default ViewIdea;