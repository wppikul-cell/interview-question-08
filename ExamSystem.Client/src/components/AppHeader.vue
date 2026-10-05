
<script setup>
defineProps({
  title: {
    type: String,
    required: true
  }
})
</script>

<template>
  <div class="header">
    {{ title }}
  </div>
</template>

