import React, { Component } from "react";
import ReactDOM from "react-dom";
import axios from 'axios';

class ViewPendingIdea extends Component {
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

      axios.get('http://localhost:18323/idea/pendingforreview',{ responseType: 'json' })
      .then(function(response){
         //console.log(typeof(response.data))
         that.setState({data:response.data}); 
         //console.log(that.state.data)
      })
      .catch(function (error) {
         //console.log(error);
      });

     }

     componentDidMount(){
      this.performGetRequest()
     }

   render() {
      return (            
       	<div className='container' id='innermain'>
      		<div className='row'>
        		<div className='col-md-9 col-lg-9'>
        			<h2>Pending Ideas</h2>
              <table>
                <tbody>
                  {
                    this.state.data.map(val=>{
                    return val.name     
                    })                   
                  }
                </tbody>
              </table>
        		</div>
        	</div>
        </div>
      );
   }
}
export default ViewPendingIdea;