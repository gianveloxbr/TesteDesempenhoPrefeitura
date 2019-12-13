<template>
  <v-layout column justify-center align-center>
    <v-flex xs12 sm8 md6>
      <v-card width="400px">
        <v-card-title class="headline">
          Adicionar Produto
        </v-card-title>
        <v-card-text>
          <form @submit.prevent="addProduto">
            <v-text-field v-model="Nome" label="Nome" required />
            <v-text-field v-model="Descricao" label="Descrição" required />
            <v-text-field v-model="Preco" label="Preço" required />
            <v-text-field v-model="Categoria" label="Categoria" required />
            <v-btn type="submit">
              Adicionar Produto
            </v-btn>
          </form>
        </v-card-text>
      </v-card>
    </v-flex>
  </v-layout>
</template>
<script>
export default {
  data() {
    return {
      Nome: '',
      Descricao: '',
      Preco: '',
      Categoria: ''
    }
  },
  methods: {
    addProduto() {
      const { Nome, Descricao, Preco, Categoria } = this
      const data = { Nome, Descricao, Preco, Categoria }
      const URL = 'https://localhost:5001/api/produtos'
      this.$axios({
        method: 'post',
        url: URL,
        headers: {
          'Content-Type': 'application/json'
        },
        data
      })
        .then((_) => {
          this.$router.push('/')
        })
        .catch((err) => {
          console.log(err)
        })
    }
  }
}
</script>
