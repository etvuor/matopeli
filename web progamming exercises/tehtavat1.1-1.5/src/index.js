import React from 'react'
import ReactDOM from 'react-dom'


const Entry = (props) => (
  <p>{props.name} {props.phonenumber}</p>
)

const Contents = (props) => {
  return (
    <div>
      <Entry name={props.contacts[0].name} phonenumber={props.contacts[0].phonenumber}/>
      <Entry name={props.contacts[1].name} phonenumber={props.contacts[1].phonenumber}/>
      <Entry name={props.contacts[2].name} phonenumber={props.contacts[2].phonenumber}/>
    </div>
  )
}

const Header = (props) => {
  return (
    <div>
      <h1>{props.title}</h1>
    </div>
  )
}


const App = () => {
  const phonebookapp = {
    title: 'Superadvanced web phonebook app',
    contacts: [
    {
      name: 'John Doe',
      phonenumber: '358401234567'
    },
    {
      name: 'Jane Doe',
      phonenumber: '44551234567'
    },
    {
      name: 'Foo bar',
      phonenumber: '000'
    }
    ]
  }
  return (
    <div>
      <Header title={phonebookapp.title} />
      <Contents contacts={phonebookapp.contacts} />
    </div>
  )
}

ReactDOM.render(
  <App />,
  document.getElementById('root')
)