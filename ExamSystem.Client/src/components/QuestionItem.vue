
<script setup>
defineProps({
  question: {
    type: Object,
    required: true
  },

  index: {
    type: Number,
    required: true
  }
})

const emit = defineEmits([
  'delete'
])
</script>

<template>

  <div class="question-block">

    <div class="question-title">

      {{ index + 1 }}.
      {{ question.questionText }}

      <button
        class="btn btn-red"
        @click="emit('delete', question.id)"
      >
        ลบ
      </button>

    </div>

    <label
      v-for="choice in question.choices"
      :key="choice.id"
      class="choice"
    >

      <input
        type="radio"
        :name="'question-' + question.id"
        :value="choice.id"
        disabled
      />

      <span>
        {{ choice.choiceText }}
      </span>

    </label>

  </div>

</template>

