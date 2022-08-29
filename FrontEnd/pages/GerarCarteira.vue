<template>
  <v-card>
    <v-toolbar color="white" flat>
      <v-toolbar-title class="grey--text text--darken-4">
        Informações do Estudante
      </v-toolbar-title>
    </v-toolbar>

    <v-container fluid>
      <v-form ref="form" v-model="valid" lazy-validation>
        <v-text-field
          v-model="estudante.nome"
          :rules="nameRules"
          label="Nome do Aluno"
          required
        ></v-text-field>

        <v-text-field
          v-model="estudante.instituicao"
          :rules="instituicaoRules"
          label="Instituição de Ensino"
          required
        ></v-text-field>

        <v-text-field
          v-model="estudante.curso"
          :rules="cursoRules"
          label="Curso"
          required
        ></v-text-field>

        <v-text-field
          v-model="estudante.matricula"
          :rules="matriculaRules"
          label="Matrícula"
          required
        ></v-text-field>

        <v-file-input
          v-model="foto"
          :rules="fotoRules"
          required
          accept="image/*"
          prepend-icon="mdi-camera"
          label="Sua Foto"
          @change="onload"
        ></v-file-input>

        <v-btn :disabled="!valid" color="success" class="mr-4" @click="submit">
          Gerar Carteira
        </v-btn>

        <div id="alertSucess">
          <v-alert id="v-alert" dismissible type="success"
            >Carteira de Estudante Digital gerada com sucesso!</v-alert
          >
        </div>

        <div id="alertError">
          <v-alert id="v-alert" dismissible type="error"
            ><span v-html="data"></span
          ></v-alert>
        </div>
      </v-form>
    </v-container>
  </v-card>
</template>

<script>
export default {
  data: () => ({
    valid: true,
    data: "",
    foto: "",
    estudante: {
      nome: "",
      matricula: "",
      curso: "",
      instituicao: "",
      foto: "",
    },
    nameRules: [(v) => !!v || "Nome é obrigatório"],
    instituicaoRules: [(v) => !!v || "Instituição é obrigatório"],
    cursoRules: [(v) => !!v || "Curso é obrigatório"],
    matriculaRules: [(v) => !!v || "Matricula é obrigatório"],
    fotoRules: [
      (value) =>
        !value ||
        value.size < 2000000 ||
        "O tamanho da imagem deve ser menor que 2 MB!",
    ],
  }),

  methods: {
    onload(e) {
      const reader = new FileReader();

      reader.onloadend = () => {
        this.estudante.foto = reader.result != null ? reader.result : null;
      };

      reader.readAsDataURL(e);
    },

    async submit() {
      try {
        var response = await this.$axios({
          method: "POST",
          url: "https://localhost:7178/CarteiraEstudante",
          data: this.estudante,
        });
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
