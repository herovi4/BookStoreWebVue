<template>
    <div class="modal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title">Добавить книгу</h2>
                    <button type="button" class="close" @click="closeModal">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="addBook">
                        <div class="form-group">
                            <label for="coverImage">Обложка:</label>
                            <input type="file" class="form-control" id="coverImage" @change="handleCoverImageChange">
                        </div>
                        <div class="form-group">
                            <label for="title">Название:</label>
                            <input type="text" class="form-control" id="title" v-model="newBook.title">
                        </div>
                        <div class="form-group">
                            <label for="author">Автор:</label>
                            <input type="text" class="form-control" id="author" v-model="newBook.authorId">
                        </div>
                        <div class="form-group">
                            <label for="isbn13">ISBN-13:</label>
                            <input type="text" class="form-control" id="isbn13" v-model="newBook.isbn13">
                        </div>
                        <div class="form-group">
                            <label for="language">Язык:</label>
                            <input type="text" class="form-control" id="language" v-model="newBook.languageId">
                        </div>
                        <div class="form-group">
                            <label for="numPages">Количество страниц:</label>
                            <input type="number" class="form-control" id="numPages" v-model.number="newBook.numPages">
                        </div>
                        <div class="form-group">
                            <label for="publicationDate">Дата публикации:</label>
                            <input type="number" class="form-control" id="publicationDate" v-model="newBook.publicationDate">
                        </div>
                        <div class="form-group">
                            <label for="publisher">Издательство:</label>
                            <input type="text" class="form-control" id="publisher" v-model="newBook.publisherId">
                        </div>
                        <div class="form-group">
                            <label for="genre">Жанр:</label>
                            <input type="text" class="form-control" id="genre" v-model="newBook.genreId">
                        </div>
                        <div class="form-group">
                            <label for="price">Цена:</label>
                            <input type="number" class="form-control" id="price" v-model.number="newBook.price">
                        </div>
                    </form>
                    <div class="modal-footer">
                        <button type="submit" class="btn btn-primary" @click="addBook">Сохранить</button>
                        <button type="button" class="btn btn-secondary" @click="closeModal">Отмена</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import checkBook from './checkNewBook.js'

    export default {
        data() {
            return {
                newBook: {
                    title: '',
                    authorId: '',
                    isbn13: '',
                    languageId: '',
                    numPages: 0,
                    publicationDate: 0,
                    publisherId: '',
                    genreId: '',
                    price: 0
                },
                coverImage: null
            };
        },
        methods: {
            async addBook() {
                try {
                    const book = await checkBook(this.newBook);
                    const formData = new FormData();
                    // Добавляем каждое свойство объекта "Book" в FormData
                    Object.keys(book).forEach(key => {
                        formData.append(`Book.${key}`, book[key]);
                    });
                    formData.append('coverImage', this.coverImage)
                    this.$emit('add', formData);
                    this.closeModal();
                } catch (error) {
                    console.error(error);
                }
            },
            closeModal() {
                this.$emit('close');
            },
            handleCoverImageChange(event) {
                this.coverImage = event.target.files[0];
            },
        }
    };
</script>

<style>
    .modal {
        background-color: rgba(0, 0, 0, 0.5);
    }

    .modal-dialog {
        margin-top: 100px;
    }

    .modal-content {
        background-color: #fff;
        padding: 20px;
    }
    .modal-footer {
        border-top: 1px solid #dee2e6;
        padding: 15px;
    }
</style>
