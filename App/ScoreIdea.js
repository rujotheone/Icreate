import React, { Component } from "react";
import ReactDOM from "react-dom";
import axios from 'axios';

class ScoreIdea extends Component {

   constructor(props) 
      {
         super(props);
         
         this.state = {
            
              data:{
               idea:[],
               metric:[]
              }
         }
         this.performGetRequest = this.performGetRequest.bind(this);
         
      };
      
    performGetRequest() 
    {
        var that=this;

      axios.get('http://localhost:18323/reviewidea/3',{ responseType: 'json' })
      .then(function(response){
         //console.log(typeof(response.data))
         that.setState({data:response.data}); 
         console.log(that.state.data.idea)
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
               <div className='col-md-7 col-lg-7' id='score-form'>
                  <div className="score-formbox">
                  <h3>Review an Idea</h3>             

                  <div>

                     <table>
                     <tbody>
                     <tr>
                        <td>{this.state.data.idea.id}</td>
                     </tr>
                     <tr>
                        <td>{this.state.data.idea.name}</td>
                     </tr>
                     <tr>
                        <td>{this.state.data.idea.title}</td>
                     </tr> 
                     <tr>
                        <td>{this.state.data.idea.owner}</td>
                     </tr> 
                     <tr>
                        <td>{this.state.data.idea.description}</td>
                     </tr> 
                     <tr>
                        <td>{this.state.data.idea.notification}</td>
                     </tr>                      
                     </tbody>
                     </table>                     

                     <div className='form-group'>
                     <label htmlFor="Attachment">Download Atachment</label>
                     <input type="file" name="attachment"/>
                     </div>
                  </div>            
               
               </div>
            </div>
            

            <Review/>

         </div>
        </div>
      );
   }
}

class Review extends Component {
   render() {
      return (
         <div className='col-md-5 col-lg-5'>
            <span>Score this idea</span>
            </div>
      );
   }
}

export default ScoreIdea;