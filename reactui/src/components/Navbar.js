import React from 'react'
import { Link } from 'react-router-dom'
import { Stack, Button } from '@mui/material'

const Navbar = () => (
  <Stack direction="row" justifyContent="space-around" sx={{ gap: { sm: '123px', xs: '40px' }, mt: { sm: '32px', xs: '20px' }, justifyContent: 'none'}} px="20px">
    <Stack
      direction="row"
      gap="40px"
      fontFamily="Alegreya"
      fontSize="24px"
      alignItems="flex-end"
    >
      <Link to="/" style={{ textDecoration: 'none', color: '#3A1212', borderBottom: '3px solid #FF2625' }}>Home</Link>
      <a href="creators" style={{ textDecoration: 'none', color: '#3A1212' }}>Creators</a>
      <a href="players" style={{ textDecoration: 'none', color: '#3A1212' }}>Players</a>
      <a href="games" style={{ textDecoration: 'none', color: '#3A1212' }}>Games</a>
      <a href="reviews" style={{ textDecoration: 'none', color: '#3A1212' }}>Reviews</a>
      <a href="adminsignin" style={{ textDecoration: 'none', color: '#3A1212' }}>Admin Login</a>
    </Stack>
  </Stack>
);

export default Navbar