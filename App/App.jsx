import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Switch, Route, Link,Redirect,IndexRoute, HashRouter } from 'react-router-dom';
import axios from 'axios';
import Home from './Home';
import Login from './Login';
import CreateIdea from './CreateIdea';
import ViewIdea from './ViewIdea';
import ScoreIdea from './ScoreIdea';
import CreateMetric from './CreateMetric';
import ViewPendingIdea from './ViewPendingIdea';
 

class App extends Component {
   
render() {
      return (
         <Router>
         <div>
            <div className='sidenav' >  
               <div id=''>             
                  <ul>
                     <li><Link to={'/'}>Home</Link></li>
                     <li><Link to={'/Login'}>Login</Link></li>
                     <li><Link to={'/CreateIdea'}>Create an idea</Link></li>
                     <li><Link to={'/ViewIdea'}>View Ideas</Link></li>
                     <li><Link to={'/ScoreIdea'}>Review an idea</Link></li>                     
                     <li><Link to={'/ViewPendingIdea'}>Ideas for review</Link></li>
                     <li><Link to={'/CreateMetric'}>Create a Metric</Link></li>
                  </ul>
               </div>
            </div>           
                  
                  <Switch>
                  <Route  exact path='/' component={Home} />
                  <Route exact path='/Login' component={Login} />
                  <Route  exact path='/CreateIdea' component={CreateIdea} />
                  <Route  exact path='/ViewIdea' component={ViewIdea} /> 
                  <Route  exact path='/ScoreIdea' component={ScoreIdea} />  
                  <Route  exact path='/ViewPendingIdea' component={ViewPendingIdea} />  
                  <Route  exact path='/CreateMetric' component={CreateMetric} />  
                  </Switch>  
         </div>
         </Router>
      );
   }
}
export default App;
