import React from 'react'

const Form = ({ addReminder, valueName, handleNameChange, valueTime, handleTimeChange }) => {
  return (
	<form onSubmit={addReminder}> 
		<h3>Add new reminder</h3>   
		<div>
			<p>Name:
			<input
				value={valueName} 
				onChange={handleNameChange}
			/></p>
		</div>
			  
		<div>
		    <p>
			<i>Use date format: yyyy-mm-ddThh:mm:00.000Z</i><br/>
			Date:
			<input
				value = {valueTime}
				onChange={handleTimeChange} 
			/></p>
		</div>
		
		<div>
			<button type="submit">Add</button>
		</div>
	</form>
  )
}

export default Form