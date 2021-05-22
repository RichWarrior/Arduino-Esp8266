<template>
  <v-container fluid fill-height>
    <v-row class="card-action-row">
      <v-col class="col-md-3 col-xs-12 col-sm-6">
        <v-card class="mx-auto my-12" elevation="12">
          <v-card-actions>
            <v-col class="col-md-12">
              <!-- Logo Field !-->
              <v-row class="card-action-row">
                <v-icon size="64" class="mb-2">fas fa-robot</v-icon>
              </v-row>
              <!-- Logo Field !-->
              <v-form v-model="formValid">
                <!-- Title Field !-->
                <v-row class="card-action-row mt-2">
                  <h1 class="title text-center">Arduino App</h1>
                </v-row>
                <!-- Title Field !-->
                <!-- Email Field !-->
                <v-row
                  v-if="
                    $vuetify.breakpoint.xsOnly || $vuetify.breakpoint.smOnly
                  "
                  class="row_text_field__xs__sm"
                >
                  <v-text-field
                    v-model="user.Email"
                    :rules="validations.email"
                    label="Email"
                    :counter="100"
                  ></v-text-field>
                </v-row>
                <v-row v-else class="row_text_field__md__lg">
                  <v-text-field
                    v-model="user.Email"
                    :rules="validations.email"
                    label="Email"
                    :counter="100"
                  ></v-text-field>
                </v-row>
                <!-- Email Field !-->
                <!-- Password Field !-->
                <v-row
                  v-if="
                    $vuetify.breakpoint.xsOnly || $vuetify.breakpoint.smOnly
                  "
                  class="row_text_field__xs__sm"
                >
                  <v-text-field
                    v-model="user.Password"
                    :rules="validations.password"
                    label="Password"
                    :counter="50"
                    :append-icon="
                      passwordFieldType == 'password'
                        ? 'fa fa-eye'
                        : 'fa fa-eye-slash'
                    "
                    :type="passwordFieldType"
                    @click:append="
                      passwordFieldType =
                        passwordFieldType == 'password' ? 'text' : 'password'
                    "
                  ></v-text-field>
                </v-row>
                <v-row v-else class="row_text_field__md__lg">
                  <v-text-field
                    v-model="user.Password"
                    :rules="validations.password"
                    label="Password"
                    :counter="50"
                    :append-icon="
                      passwordFieldType == 'password'
                        ? 'fa fa-eye'
                        : 'fa fa-eye-slash'
                    "
                    :type="passwordFieldType"
                    @click:append="
                      passwordFieldType =
                        passwordFieldType == 'password' ? 'text' : 'password'
                    "
                  ></v-text-field>
                </v-row>
                <!-- Password Field !-->
                <!-- Login Button !-->
                <v-row
                  class="card-action-row row_text_field__xs__sm"
                  v-if="
                    $vuetify.breakpoint.xsOnly || $vuetify.breakpoint.smOnly
                  "
                >
                  <v-btn
                    :disabled="!formValid"
                    block
                    class="gradient white--text"
                    @click="logIn"
                  >
                    LogIn
                  </v-btn>
                </v-row>
                <v-row class="card-action-row row_text_field__md__lg" v-else>
                  <v-btn
                    :disabled="!formValid"
                    block
                    class="gradient white--text"
                    @click="logIn"
                  >
                    LogIn
                  </v-btn>
                </v-row>
                <!-- Login Button !-->
                <!-- Sign Up !-->
                <v-row
                  class="card-action-row mt-5"
                  @click="$router.push({ path: '/auth/register' })"
                >
                  <span class="caption link">Sign Up</span>
                </v-row>
                <!-- Sign Up !-->
              </v-form>
            </v-col>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import logInDTO from "../../dto/request/auth/LogIn";
import { LOGIN } from "../../store/modules/auth/actions.type";
import { ShowErrorMessage } from "../../common/Alerts";
export default {
  data: () => ({
    formValid: true,
    user: Object.assign({}, new logInDTO()),
    validations: {
      email: [
        (v) => !!v || "This field is required",
        (v) => /.+@.+/.test(v) || "Email must be valid",
      ],
      password: [(v) => !!v || "This field is required"],
    },
    passwordFieldType: "password",
  }),
  methods: {
    logIn() {
      this.$store
        .dispatch(LOGIN, this.user)
        .then(() => {
          window.location.reload();
        })
        .catch((err) => {
          ShowErrorMessage(err.message);
        });
    },
  },
};
</script>

<style scope>
.card-action-row {
  align-content: center;
  justify-content: center;
}
.row_text_field__xs__sm {
  margin-left: 16px;
  margin-right: 16px;
}
.row_text_field__md__lg {
  margin-left: 32px;
  margin-right: 32px;
}
.link {
  cursor: pointer;
}
</style>