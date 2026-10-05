
<script setup>
import { ref, onMounted } from 'vue'

import { useRouter } from 'vue-router'

import AppHeader
  from '../components/AppHeader.vue'

import QuestionItem
  from '../components/QuestionItem.vue'

import {
  getQuestions,
  deleteQuestion
} from '../services/questionService'

const router = useRouter()

const questions = ref([])

const loading = ref(false)

async function loadQuestions() {

  try {

    loading.value = true

    questions.value =
      await getQuestions()

  } catch (error) {

    console.error(error)

    alert('ไม่สามารถโหลดข้อมูลได้')

  } finally {

    loading.value = false

  }
}

async function removeQuestion(id) {

  const confirmDelete =
    confirm('ต้องการลบข้อสอบนี้หรือไม่?')

  if (!confirmDelete)
    return

  try {

    await deleteQuestion(id)

    await loadQuestions()

  } catch (error) {

    console.error(error)

    alert('ลบข้อมูลไม่สำเร็จ')
  }
}

function addQuestion() {

  router.push('/questions/new')

}

onMounted(() => {

  loadQuestions()

})
</script>


<template>

  <div class="screen">

    <AppHeader title="IT 08-1" />

    <div class="content">

      <button
        class="btn btn-green add-btn"
        @click="addQuestion"
      >
        เพิ่มข้อสอบ
      </button>


      <div v-if="loading">

        กำลังโหลดข้อมูล...

      </div>


      <QuestionItem
        v-for="(question, index) in questions"
        v-else
        :key="question.id"
        :question="question"
        :index="index"
        @delete="removeQuestion"
      />

    </div>

  </div>

</template>

