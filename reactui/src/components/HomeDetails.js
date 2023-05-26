import React from 'react'
import { Box, Stack, Typography } from '@mui/material';

const HomeDetails = () => {
    return (
    <Box sx={{ mt: { lg: '212px', xs: '70px' }, ml: { sm: '50px' } }} position="relative" p="20px">
    <Typography color="#FF2625" fontWeight="600" fontSize="26px">BAB Gaming</Typography>
    <Typography fontWeight={700} sx={{ fontSize: { lg: '44px', xs: '40px' } }} mb="23px" mt="30px">
      Welcome to the Gaming Website DataBase
    </Typography>
    <Typography fontSize="22px" fontFamily="Alegreya" lineHeight="35px">
      Explore the categories on the navbar above to find out what this app can do!
    </Typography>
    <Typography fontWeight={600} color="#FF2625" sx={{ opacity: '0.1', display: { lg: 'block', xs: 'none' }, fontSize: '200px' }}>
      BAB Gaming
    </Typography>
  </Box>
    )
}

export default HomeDetails