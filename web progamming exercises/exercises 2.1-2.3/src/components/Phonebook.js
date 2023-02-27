import React from 'react'

const Phonebook = (props) => {
    const {phonebook} = props;
    const kontaktit = () => phonebook.contacts.map(contact => <ul key = {contact.id}>Name: {contact.name} Number: {contact.phonenumber} </ul>)
    return (
      <div>
        <h1>{phonebook.name}</h1>
          <ul>{kontaktit()} </ul>
          <ul>Total number of entries: {phonebook.contacts.length} </ul>
      </div>
    )
  }

  export default Phonebook