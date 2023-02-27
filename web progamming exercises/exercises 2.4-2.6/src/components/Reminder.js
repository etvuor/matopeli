import React from 'react'

const Reminder = (props) => {
    const {r} = props;
    return (
        <div>
        <ul>
        {r.map(remind=> <ul key = {remind.timestamp}>{remind.date} {remind.name} </ul>)}
      </ul> 
      </div>
    )
}

export default Reminder