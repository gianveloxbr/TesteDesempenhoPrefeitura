<template>
  <v-app class="flagStyle">
    <v-container
      fill-height
      fluid
      grid-list-xl
    >
      <v-layout wrap>
        <v-flex
          xl12
          lg12
          md12
          sm12
          xs12
        >
          <material-card>
            <v-btn
              color="success"
              to="/create"
            >
              Novo Produto
            </v-btn>
            <v-spacer />
            <v-data-table
              :headers="headers"
              :items="listData"
              :footer-props="{
                showFirstLastPage: true,
                itemsPerPageText: 'Quantidade por Página'
              }"
              dark

              style="background-color: #463B4B; color: white"
              sort-by="nome"
              class="elevation-1"
            >
              <template>
                <div>
                  <v-icon color="warning">mdi-crown</v-icon>
                </div>
              </template>
              <template v-slot:item.update="{ item }">
                <v-btn
                  color="primary"
                  :to="`/update/${item.id}`"
                >
                  Atualizar
                </v-btn>
              </template>
              <template v-slot:item.delete="{ item }">
                <v-btn
                  color="error"
                  @click="deleteProduto(item.id)"
                >
                  Excluir
                </v-btn>
              </template>
              <template v-slot:no-data>
                  <br>
                <v-alert
                  :value="true"
                  color="error"
                  icon="mdi-alert"
                >Nenhum produto cadastrado.</v-alert>
              </template>
            </v-data-table>
          </material-card>
        </v-flex>
      </v-layout>
    </v-container>
  </v-app>
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
        { text: 'Atualizar', value: 'update' },
        { text: 'Excluir', value: 'delete'}
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
        .then((_) => {
          this.listarProdutos()
        })
        .catch((err) => {
          console.log(err)
        })
    }
  }
}
</script>
