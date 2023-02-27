import React from 'react'
import ReactDOM from 'react-dom'


  const Button = ({onClick, text}) => {
    return (
      <button onClick={onClick}>{text}</button>
    )
  }
  
  const Statistics = (props) => {
    if (props.tila.good === 0 && props.tila.neutral === 0 && props.tila.bad === 0) {
      return (
        <tbody><tr><td>ei yhtään palautetta annettu</td></tr></tbody>
      )
    }
    else {
      var count = (props.tila.good + props.tila.neutral + props.tila.bad)
      var goodprocentage = (100*props.tila.good/count) + ' %'
      var average = ((props.tila.good - props.tila.bad)/count )
      
      return(
        
        <tbody>
          <Statistic label='Hyvä:' value={props.tila.good} />
          <Statistic label='Neutraali:' value={props.tila.neutral} />
          <Statistic label='Huono:' value={props.tila.bad} />
          <Statistic label='Keskiarvo:' value={average} />
          <Statistic label='Positiivisia:' value={goodprocentage}/>
        </tbody>
      )
    }
  }
  
  
  const Statistic = (props) => {
    return (
      <tr><td>{props.label}</td><td>{props.value}</td></tr>
    )
  }
  
  class App extends React.Component {
    constructor() {
      super()
      this.state = {
        good: 0,
        neutral: 0,
        bad:0
      }
    }		
    
    addGood = () => () => {this.setState({good: this.state.good + 1})}
    addNeutral = () => () => {this.setState({neutral: this.state.neutral + 1})}
    addBad = () => () => {this.setState({bad: this.state.bad + 1})}
    
    render() {
    return (
      <div className="App">
      <div className="buttons">
        <h1>Anna palautetta</h1>
        <Button onClick={this.addGood()} text='hyvä' />
        <Button onClick={this.addNeutral()} text='neutraali' />
        <Button onClick={this.addBad()} text='huono' />
      </div>
      <div className="Stats">
      <h1>Statistiikka</h1>
        <table>
          <Statistics tila={this.state} />
        </table>
      </div>	
      </div>
    );
  }
  }

ReactDOM.render(
  <App />,
  document.getElementById('root')
)