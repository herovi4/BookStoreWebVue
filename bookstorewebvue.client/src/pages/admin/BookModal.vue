<template>
    <div class="modal">
        <div class="modal-content">
            <h2>�������������� �����</h2>
            <form @submit.prevent="saveBook">
                <label>��������:</label>
                <input type="text" v-model="editedBook.title">
                <label>�����:</label>
                <input type="text" v-model="editedBook.author">
                <label>����:</label>
                <input type="number" v-model="editedBook.price">
                <button type="submit">���������</button>
            </form>
            <button @click="closeModal">�������</button>
        </div>
    </div>
</template>

<script>
export default {
  props: ['book'],
  data() {
    return {
      editedBook: { ...this.book }
    }
  },
  methods: {
    saveBook() {
      // ��������� ������ ����������������� ����� �� ������
      this.$emit('save', this.editedBook);
      // ������� ��������� ����
      this.closeModal();
    },
    closeModal() {
      this.$emit('close');
    }
  }
}
</script>