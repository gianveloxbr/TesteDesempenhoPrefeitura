<template>
  <v-app style="background: rgba(0,0,0,0)">
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
            <h1 class="text-xl text-center" style="color:white;">Bem-vindo(a) ao gSHOP!</h1>
             <v-dialog v-model="dialog" persistent max-width="600px">
      <template v-slot:activator="{ on }">
        <v-btn color="primary" dark v-on="on" @click.stop="dialog = true">Novo Produto</v-btn>
      </template>
      <v-card>
        <v-card-title>
          <span class="headline">Adicionar Produto</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12" sm="6" md="4">
                <v-text-field v-model="Nome" label="Nome" required />
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field v-model="Descricao" label="Descrição" required />
              </v-col>
              <v-col cols="12" sm="6" md="4">               
                <v-text-field v-model="Preco" label="Preço" type="number" required />
              </v-col>
              <v-col cols="12">                
                <v-text-field v-model="Categoria" label="Categoria" required />
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="addProduto()">Adicionar</v-btn>
          <v-btn color="blue darken-1" text @click="dialog = false">Fechar</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
            <v-spacer />
            <h1 class="text-xl text-center" style="color:white;">Lista de Produtos</h1>
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
                <v-btn color="primary" :to="`/update/${item.id}`"> Atualizar </v-btn>
              </template>
              <template v-slot:item.delete="{ item }">
                <v-dialog v-model="dialogDelete" persistent max-width="290">
                  <template v-slot:activator="{ on }">
                    <v-btn color="error" dark v-on="on">Excluir</v-btn>
                  </template>
                  <v-card>
                    <v-card-title class="headline">Excluir Produto</v-card-title>
                    <v-card-text>Deseja excluir este produto?</v-card-text>
                    <v-card-actions>
                      <v-spacer></v-spacer>
                      <v-btn color="green darken-1" text @click="deleteProduto(item.id)">Sim</v-btn>
                      <v-btn color="green darken-1" text @click="dialogDelete = false">Não</v-btn>
                    </v-card-actions>
                  </v-card>
                </v-dialog>
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
      dialog: false,
      dialogDelete: false,
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
      ],
      id: '',
      Nome: '',
      Descricao: '',
      Preco: '',
      Categoria: ''
    }
  },
  mounted() {
    this.id = this.$route.params.id
    this.listarProdutos()
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
          this.dialog = false
          this.listarProdutos()
        })
        .catch((err) => {
          console.log(err)
        })
    },
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
          this.dialogDelete = false
          this.listarProdutos()
        })
        .catch((err) => {
          console.log(err)
        })
    }
  }
}
</script>