import React, { Component } from "react";
import ReactDOM from "react-dom";
import axios from 'axios';

class CreateMetric extends Component {

   constructor(props) 
      {
         super(props);
         
         this.state = {        
              
         }
         this.submitForm = this.submitForm.bind(this);
         this.handleInputChange = this.handleInputChange.bind(this);
      };

      submitForm(e){
         
         e.preventDefault();
         
         axios.post('http://localhost:18323/metric/',this.state,{ responseType: 'json' })
            .then(function (response) {
            console.log(response.status)            
            })
            .catch(function (error) {
            console.log(error)
            });
            
      }

       handleInputChange(event)
      {
          const target = event.target;
           
          this.setState({
            [target.name]:target.value
         });
          console.log(target.name);
          console.log(":  ");
          console.log(target.value);
      }

   render() {
      return (
         <div className='container' id='innermain'>
            <div className='row'>
            <div className='col-md-9 col-lg-9'>
            <h2>Create a Metric</h2>
            <form  className="form-horizontal"role="form" onSubmit = {this.submitForm}>

               <div className='form-group'>
               <label htmlFor="Name">Name:</label>
               <input type="text" className="form-control" name="name" value={this.state.name} onChange={this.handleInputChange}/>
               </div>               

               <div className='form-group'>
               <label htmlFor="Weight">Description:</label>
               <input type="text" className="form-control" name="weight" value={this.state.weight} onChange={this.handleInputChange}/>
               </div>               

               <div className='form-group'>
               <button type="submit" className="btn btn-default">Submit</button>
               </div>

            </form>
         </div>
         </div>
        </div>
      );
   }
}
export default CreateMetric;