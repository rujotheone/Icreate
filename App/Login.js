import React, { Component } from 'react';
import ReactDOM from 'react-dom';

class Login extends Component {
   render() {
      return (
         <div className='container' id='innermain'>
            <div className='row'>
            <div className='col-md-7 col-lg-7' id='form'>
            <div className="formbox">
            <h3>Enter your credentials</h3>
            <form  className="form-horizontal"role="form">

               <div className='form-group'>
               <label htmlFor="Name">Email</label>
               <input type="text" className="form-control" name="name" />
               </div>               

               <div className='form-group'>
               <label htmlFor="Weight">Password</label>
               <input type="password" className="form-control" name="weight"/>
               </div>               

               <div className='form-group'>
               <button type="submit" className="btn btn-default">Submit</button>
               </div>

            </form>
         </div>
         </div>
         </div>
        </div>
      );
   }
}
export default Login;