const express = require('express')
const app = express()
const bodyParser = require('body-parser')

const cors = require('cors')

app.use(cors())

app.use(bodyParser.json())

let reminders = [
  {
    name: 'Buy some eggs',
    timestamp: '2021-11.10T13:00:00.141Z',
    id: 1
  },

  
  {
    name: 'Make an omelette',
    timestamp: '2021-11-11T08:00:00.141Z',
    id: 2
  },
  {
    name: 'Wash dishes',
    timestamp: '2021-11-11T09:00:00.000Z',
    id: 3
  },
  {
    name: 'Buy more eggs',
    timestamp: '2021-11-11T13:00:00.000Z',
    id: 4
  }
]

app.get('/api/reminders', (req, res) => {
  res.json(reminders)
})

app.get('/api/reminders/:id', (request, response) => {
  const id = Number(request.params.id)
  const reminder = reminders.find(reminder => reminder.id === id)

  if ( reminder ) {
    response.json(reminder)
  } else {
    response.status(404).end()
  }
})


app.delete('/api/reminders/:id', (request, response) => {
  const id = Number(request.params.id)
  reminders = reminders.filter(reminder => reminder.id !== id)

  response.status(204).end()
})

const generateId = () => {
const randomId = Math.floor(Math.random()*1001)
  return randomId
}

app.post('/api/reminders', (request, response) => {
  const body = request.body

  if(body.name===undefined){
    return response.status(400).json({ 
      error: 'content(name/task) missing' 
    })
  }
  
  if(body.timestamp===undefined){
    return response.status(400).json({ 
      error: 'content(timestamp) missing' 
    })
  }
  
  if (reminders.some(m => m.name === body.name)) {
    return response.status(400).json(
      {error:'name must be unique'})
  }

  const reminder = {
    name: body.name,
    timestamp: body.timestamp,
    id: generateId()
  }

  reminders = reminders.concat(reminder)

  response.json(reminder)
})

const port = 3001
app.listen(port)
console.log(`Server running on port ${port}`)

