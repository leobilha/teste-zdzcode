<template>
  <v-container fluid>
    <v-form ref="form" v-model="valid" lazy-validation>
      <v-text-field
        v-model="matricula"
        :rules="matriculaRules"
        label="Matrícula"
        required
      ></v-text-field>

      <v-btn :disabled="!valid" color="success" class="mr-4" @click="submit">
        Consultar Carteira
      </v-btn>

      <div id="alertSucess">
        <v-alert id="v-alert" dismissible type="success"
          >Sua carteira está logo abaixo!</v-alert
        >
      </div>

      <div id="alertError">
        <v-alert id="v-alert" dismissible type="error"
          ><span v-html="data"></span
        ></v-alert>
      </div>

      <br />

      <div
        id="app"
        class="d-flex flex-column justify-space-between align-center"
      >
        <img v-bind:src="Image" />
      </div>
    </v-form>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    data: "",
    Image: "",
    width: 300,
    valid: true,
    matricula: "",
    matriculaRules: [(v) => !!v || "Matricula é obrigatório"],
  }),

  methods: {
    async submit() {
      try {
        var response = await this.$axios({
          method: "GET",
          url: "https://localhost:7178/CarteiraEstudante/" + this.matricula,
        });
        this.Image = response.data.imagemCarteira;
        document.getElementById("alertSucess").style.display = "block";
      } catch (error) {
        this.data = error.response.data.message;
        document.getElementById("alertError").style.display = "block";
      }
    },
  },
};
</script>

<style>
#alertSucess {
  margin-top: 20px;
  margin-bottom: 20px;
  display: none;
}

#alertError {
  margin-top: 20px;
  margin-bottom: 20px;
  display: none;
}
</style>
