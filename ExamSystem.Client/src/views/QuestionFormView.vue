
<script setup>
import { ref } from 'vue'

import { useRouter } from 'vue-router'

import AppHeader
  from '../components/AppHeader.vue'

import {
  createQuestion
} from '../services/questionService'

const router = useRouter()

const questionText = ref('')

const choices = ref([
  {
    choiceText: '',
    isCorrect: false
  },
  {
    choiceText: '',
    isCorrect: false
  },
  {
    choiceText: '',
    isCorrect: false
  },
  {
    choiceText: '',
    isCorrect: false
  }
])


function save() {

  if (!questionText.value.trim()) {

    alert('กรุณากรอกคำถาม')

    return

  }


  const validChoices =
    choices.value.filter(
      x => x.choiceText.trim()
    )


  if (validChoices.length < 2) {

    alert('กรุณากรอกตัวเลือกอย่างน้อย 2 ข้อ')

    return

  }


  if (
    !validChoices.some(
      x => x.isCorrect
    )
  ) {

    alert('กรุณาเลือกคำตอบที่ถูกต้อง')

    return

  }


  createQuestion({

    questionText:
      questionText.value,

    choices:
      validChoices

  })
  .then(() => {

    alert('บันทึกสำเร็จ')

    router.push('/questions')

  })
  .catch(error => {

    console.error(error)

    alert('บันทึกข้อมูลไม่สำเร็จ')

  })
}


function cancel() {

  router.push('/questions')

}


function selectCorrect(index) {

  choices.value.forEach(
    (choice, i) => {

      choice.isCorrect =
        i === index

    }
  )

}
</script>


<template>

  <div class="screen">

    <AppHeader title="IT 08-2" />

    <div class="form-container">

      <!-- Question -->

      <div class="form-row">

        <label>
          คำถาม
        </label>

        <input
          v-model="questionText"
          class="text-input"
          type="text"
        />

      </div>


      <!-- Choices -->

      <div
        v-for="(choice, index) in choices"
        :key="index"
        class="form-row"
      >

        <label>
          คำตอบ {{ index + 1 }}
        </label>

        <input
          v-model="choice.choiceText"
          class="text-input"
          type="text"
        />


        <label class="correct">

          <input
            type="radio"
            name="correct"
            :checked="choice.isCorrect"
            @change="selectCorrect(index)"
          />

          เฉลย

        </label>

      </div>


      <!-- Buttons -->

      <div class="form-buttons">

        <button
          class="btn btn-blue"
          @click="save"
        >
          บันทึก
        </button>

        <button
          class="btn btn-red"
          @click="cancel"
        >
          ยกเลิก
        </button>

      </div>

    </div>

  </div>

</template>

