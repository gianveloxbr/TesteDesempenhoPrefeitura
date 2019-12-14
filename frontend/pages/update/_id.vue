<template>
  <v-layout column justify-center align-center>
    <v-flex xs12 sm8 md6>
      <v-card width="400px">
        <v-card-title class="headline">
          Atualizar Produto
        </v-card-title>
        <v-card-text>
          <form @submit.prevent="updateProduto(id)">
            <v-text-field v-model="Nome" label="Nome" required />
            <v-text-field v-model="Descricao" label="Descrição" required />
            <v-text-field v-model="Preco" label="Preço" required />
            <v-text-field v-model="Categoria" label="Categoria" required />
            <v-btn type="submit">
              Atualizar Produto
            </v-btn>
            <v-btn to="/">
              Voltar
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
      id: '',
      Nome: '',
      Descricao: '',
      Preco: '',
      Categoria: ''
    }
  },
  mounted() {
    this.id = this.$route.params.id
    this.listarProduto(this.id)
  },
  methods: {
    listarProduto(id) {
      const URL = `https://localhost:5001/api/produtos/${id}`
      this.$axios({
        method: 'get',
        url: URL,
        headers: {
          'Content-Type': 'application/json'
        }
      })
        .then((res) => {
          const { Id, Nome, Descricao, Preco, Categoria } = res.data
          this.Id = id
          this.Nome = Nome
          this.Descricao = Descricao
          this.Preco = Preco
          this.Categoria = Categoria
        })
        .catch((err) => {
          console.log(err)
        })
    },
    updateProduto(id) {
      const { Id, Nome, Descricao, Preco, Categoria } = this
      const data = { Id, Nome, Descricao, Preco, Categoria }
      const URL = `https://localhost:5001/api/produtos/${id}`
      this.$axios({
        method: 'put',
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
