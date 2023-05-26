import React from 'react'
import './App.css'
import {Route, Routes} from 'react-router-dom'
import { Box } from '@mui/material'
import Home from './Pages/Home.js'
import Navbar from './components/Navbar.js'
import Footer from './components/Footer.js'
import CreatorPage from './Pages/CreatorPage'
import PlayerPage from './Pages/PlayerPage'
import GamePage from './Pages/GamePage'
import ReviewPage from './Pages/ReviewPage'
import AdminSignIn from './Pages/AdminSignIn'

const App = () => {
  return (
    <Box width='400px' sx={{width: {xl:'1488px'}}}m='Auto'>
        <Navbar />
        <Routes>
            <Route path="/" element={<Home />}/>
            <Route path="/creators/" element={<CreatorPage />}/>
            <Route path="/players/" element={<PlayerPage />}/>
            <Route path="/games/" element={<GamePage />}/>
            <Route path="/reviews/" element={<ReviewPage />}/>
            <Route path="/AdminSignIn/" element={<AdminSignIn />}/>
        </Routes>
        <Footer />
    </Box>
  )
}

export default App