
import { apiRequest } from './api'

export function getQuestions() {
  return apiRequest('/questions')
}

export function getQuestion(id) {
  return apiRequest(`/questions/${id}`)
}

export function createQuestion(question) {
  return apiRequest('/questions', {
    method: 'POST',
    body: JSON.stringify(question)
  })
}

export function deleteQuestion(id) {
  return apiRequest(`/questions/${id}`, {
    method: 'DELETE'
  })
}

