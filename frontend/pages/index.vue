<template>
  <v-layout column justify-center align-center>
    <v-data-table :headers="headers" :items="listData" class="elevation-0">
      <template slot="items" slot-scope="props">
        <tr>
          <td>{{ props.item.id }}</td>
          <td>{{ props.item.Nome }}</td>
          <td>{{ props.item.Descricao }}</td>
          <td>{{ props.item.Preco }}</td>
          <td>{{ props.item.Categoria }}</td>
          <v-btn color="primary" :to="`/update/${props.item.id}`">Atualizar</v-btn>
          <v-btn color="error" @click="deleteProduto(props.item.id)">Remover</v-btn>
        </tr>
      </template>
    </v-data-table>
  </v-layout>
</template>
<script>
export default {
  data() {
    return {
      listData: [],
      headers: [
        {
          text: 'Nome',
          value: 'Nome'
        },
        { text: 'Descrição', value: 'Descricao' },
        { text: 'Preço', value: 'Preco' },
        { text: 'Categoria', value: 'Categoria' },
        { text: 'Atualizar', value: 'atualizar' },
        { text: 'Remover', value: 'remover' }
      ]
    }
  },
  mounted() {
    this.listarProdutos()
  },
  methods: {
    listarProdutos() {
      const URL = 'https://localhost:5001/api/produtos'
      this.$axios({
        method: 'get',
        url: URL,
        headers: {
          'Content-Type': 'application/json'
        }
      })
        .then((res) => {
          this.listData = res.data
        })
        .catch((err) => {
          console.log(err)
        })
    },
    deleteProduto(id) {
      const URL = `https://localhost:5001/api/produtos/${id}`
      this.$axios({
        method: 'delete',
        url: URL,
        headers: {
          'Content-Type': 'application/json'
        }
      })
        .then(_ => {
          this.listarProdutos()
        })
        .catch(err => {
          console.log(err)
        })
    }
  }
}
</script>
