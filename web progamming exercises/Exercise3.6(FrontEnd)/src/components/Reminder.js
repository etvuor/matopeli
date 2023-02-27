import React from 'react'

const Reminder = (props) => {
  return (
    <li>{new Date(props.data.timestamp).toLocaleString()} {props.data.name} <button onClick={props.deleteReminder(props.data.id)}>Delete</button></li>
  )
}

export default Reminder