import React, { useEffect, useState } from "react"

const CreatorDetails = () => {
  const [creators, setCreators] = useState([])

  const fetchData = async () => {
    const response = await fetch("https://localhost:7224/api/Creator/CreatorList")
    const data = await response.json()
    setCreators(data)
  }

  useEffect(() => {
    fetchData()
  }, [])

  return (
    <div>
      {creators.length > 0 && (
        <ul>
          {creators.map(creator => (
            <li key={creator.creatorId}>{creator.displayname}</li>
          ))}
        </ul>
      )}
    </div>
  )
}

export default CreatorDetails