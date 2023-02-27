import React from 'react'
import Reminder from './Reminder'

const Reminders = (props) => {
  return (
     <ul>    
     {props.reminders.map((item) => <Reminder key={item.id} data={item} deleteReminder={props.deleteReminder}/>)}
     </ul>
  )
}

export default Reminders