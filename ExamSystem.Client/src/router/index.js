
import {
  createRouter,
  createWebHistory
} from 'vue-router'

import QuestionListView
  from '../views/QuestionListView.vue'

import QuestionFormView
  from '../views/QuestionFormView.vue'

const routes = [
  {
    path: '/',
    redirect: '/questions'
  },

  {
    path: '/questions',
    name: 'questions',
    component: QuestionListView
  },

  {
    path: '/questions/new',
    name: 'question-new',
    component: QuestionFormView
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router

