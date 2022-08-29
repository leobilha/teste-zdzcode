<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
      <v-card class="logo py-4 d-flex justify-center">
        <vuetify-logo />
      </v-card>
      <v-card>
        <v-card-title class="headline">
          Seja Bem Vindo
        </v-card-title>
        <v-card-text>
          <p>Sistema feito para teste e aprimoramento de conhecimento.</p>
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn
            color="primary"
            nuxt
            to="/inspire"
          >
            Continue
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import NuxtLogo from '../components/NuxtLogo.vue'
import VuetifyLogo from '../components/VuetifyLogo.vue'
export default {
  components: { NuxtLogo, VuetifyLogo },
  name: 'IndexPage'
}
</script>
