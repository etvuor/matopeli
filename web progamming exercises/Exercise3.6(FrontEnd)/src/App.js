import React from 'react'
import axios from 'axios'

import Reminders from './components/Reminders.js'
import Form from './components/Form.js'


class App extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      reminders: [
        {
          name: '',
          timestamp: ''
        }
      ],
      newName: '',
	  newTime: ''
    }
  }
 
  componentDidMount() {
    axios.get('http://localhost:3001/api/reminders')
      .then(response => {
        this.setState({ reminders: response.data })
      })
  }
 
  addReminder = (event) => {
	event.preventDefault()

	const newObject = {
	  name: this.state.newName,
	  timestamp: this.state.newTime
	}
	
	if (this.state.reminders.some(reminder => reminder.name === newObject.name)) {
		alert(`${newObject.name} - Not added. Reminder is already on the list`);
	} else {
		
		axios.post('http://localhost:3001/api/reminders', newObject)
			.then(response => {
			  this.setState({
				reminders: this.state.reminders.concat(response.data),
				newName: '',
				newTime: ''
			  })
			})
	  }
	}
	
  handleNameChange = (event) => {
	this.setState({newName: event.target.value})
  }
  
  handleTimeChange = (event) => {
	this.setState({newTime: event.target.value})
  }
  
  deleteReminder = (id) => {  
	  return () => {
		axios.delete(`http://localhost:3001/api/reminders/${id}`)
		  .then(response => {
			const reminders = this.state.reminders.filter(n => n.id !== id)
			this.setState({
			  reminders: reminders
			})
		  })
		  .catch(error => {
			alert(`Muistiinpano on jo poistettu palvelimelta`)
		  })
	  }
	}

  render() {
    return (	  
	  <div>
	  <h2>Reminders App</h2>
		<div>
			{<Form addReminder={this.addReminder} valueName={this.state.newName} handleNameChange={this.handleNameChange} valueTime={this.state.newTime} handleTimeChange={this.handleTimeChange} />}
	    </div>
        
		<h3>Reminders</h3>
        <Reminders reminders={this.state.reminders} deleteReminder={this.deleteReminder} />
			
      </div>
	)
  }
}

export default App