<template>
  <v-app style="background:rgba(0,0,0,0);">
    <v-app-bar :clipped-left="clipped" fixed app>
      <v-btn text to="/"><v-toolbar-title v-text="title" /></v-btn>
    </v-app-bar>
    <v-content>
      <v-container>
        <nuxt />
      </v-container>
    </v-content>
    <v-footer :fixed="fixed" app>
      <span>&copy; 2019 <a id="linkgit" href="https://github.com/gianveloxbr" target="_blank">Gian Michel</a></span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      clipped: false,
      drawer: false,
      fixed: false,
      items: [
        {
          icon: 'mdi-apps',
          title: 'Welcome',
          to: '/'
        },
        {
          icon: 'mdi-chart-bubble',
          title: 'Inspire',
          to: '/inspire'
        }
      ],
      miniVariant: false,
      right: true,
      rightDrawer: false,
      title: 'gShop'
    }
  }
}
</script>
<style>
  body{
  background-image:url('../static/bkg.png');
  background-repeat: repeat;
  }
  #linkgit{
    color:white;
    background-color: transparent;
  }
</style>