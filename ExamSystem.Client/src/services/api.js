
const API_URL = 'https://localhost:44388/api'

export async function apiRequest(
  endpoint,
  options = {}
) {
  const response = await fetch(
    `${API_URL}${endpoint}`,
    {
      headers: {
        'Content-Type': 'application/json',
        ...options.headers
      },
      ...options
    }
  )

  if (!response.ok) {
    throw new Error(
      `API Error: ${response.status}`
    )
  }

  if (response.status === 204) {
    return null
  }

  return response.json()
}

