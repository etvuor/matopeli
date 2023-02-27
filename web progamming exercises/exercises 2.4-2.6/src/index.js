import React from 'react';
import ReactDOM from 'react-dom';

class App extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      reminders: [
        {
          name: 'Buy some eggs',
          date: '11.11.2018 08:00',
          timestamp: "2018-11-10T13:00:00.141Z",
        }
      ],
      newName: ''
    }
  }
  addReminder = (event) => {
    event.preventDefault()
    var i
    var alive
    for (i=0; i < this.state.reminders.length; i++) {
    if (this.state.reminders[i].name === this.state.newName) {
      alive = true
  }
}
  if (alive) {
    console.log('Already alive')
    return false;
  }
  if (alive!==true) {
    const RemainderExample = {
      name: this.state.newName,
      date: this.state.date
    }

    const reminders = this.state.reminders.concat(RemainderExample)

    this.setState({
      reminders,
      newName: '',
      date: ''
    })
  }
  
}

 
  reminderChange = (event) => {
    console.log(event.target.value)
    this.setState({newName: event.target.value})
  }

  dateChange = (event) => {
    console.log(event.target.value)
    this.setState({date: event.target.value})
  }

  render() {
    return (
      <div>
        
        <h2>Add reminder</h2>
        
        <form onSubmit={this.addReminder}>
          <div>
            Name: <input value={this.state.newName} onChange={this.reminderChange} 
            />
          </div>
          <div>
            Date: <input value={this.state.date} onChange={this.dateChange}
            />
          </div>

          <div>
            <button type="submit">Add</button>
          </div>
        </form>
        <h2>Reminders</h2>
        <ul>
          {this.state.reminders.map(remind=> <ul key = {remind.timestamp}>{remind.date} {remind.name} </ul>)}
        </ul>
        debug: {this.state.newName}
        date: {this.state.timestamp}
      </div>
    )
  }
}

export default App

ReactDOM.render(
    <App />,
  document.getElementById('root')
);

