<template>
    <q-page class="container">
        <div class="row q-mt-lg">
            <div class="col-12 col-md-4 q-pa-md">
                <q-img 
                    :src="image"
                    spinner-color="white"
                    style="height: 250px; max-width: 100%"
                    class="rounded-borders" 
                />
            </div>
            <div class="col-12 col-md-8 q-pa-md">
                <div>
                    <p class="text-h4">{{book.name}}</p>
                </div>
                <div>
                    <p>edition: {{book.edition}}</p>
                    <p>author: {{book.author}}</p>
                    <p>price: {{book.price}} TL</p>
                </div>
                <div>
                    {{book.description}}
                </div>
            </div>
        </div>
    </q-page>
</template>

<style scoped>
.vertical-hr{
    border-left: 1px solid #666666;
}
.icons{
    font-size: 30px;
}
</style>

<script>
import axios from 'axios'
import { defineComponent , ref , computed} from 'vue';
import { useStore } from "vuex";
import { useRoute } from 'vue-router'

export default {
    setup() {
        const store = useStore();
        const route = useRoute()
        const image = ref(null)
        let book = ref({});
        //let bookId = localStorage.getItem("id"); 
        /*const place = computed(() => {
            return store.state.place;
        })
        console.log(place.value);*/
        const getBookInfo = () => {
            axios({
                url:"http://localhost:4000/api/book/" + route.params.id,
                method: 'get'
            })
            .then((res) => {
                book.value = res.data;
                image.value = "http://localhost:4000/image/" + book.value.image
                console.log(image.value);
            });
        } 
        getBookInfo();
        // placeInfo = place.value.place
        return{
            book,
            image
        } 
    },
}
</script>